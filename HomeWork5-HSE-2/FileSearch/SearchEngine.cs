using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FileSearch.Properties;

namespace FileSearch
{
    class SearchEngine
    {
        public string InitialDirectory { get; set; }
        public string Pattern { get; set; }
        public long FileNumber { get; private set; }
        public long ProcessedFileNumber { get; private set; }
            
        private const string DefaultInitialDitectory = "../../";
        private const string DefaultPattern = "text";

        public Action<string> OnFileFound;
        public Action<string> OnErrorOcured;
        public Action OnFileNumberFound;
        public Action<double> OnFileProcessed;

        private CancellationTokenSource _cancellationTokenSource;
        private Task _countFileTask;

        public SearchEngine()
            : this(DefaultInitialDitectory, DefaultPattern)
        {
        }


        public SearchEngine(string initialDirectory, string pattern)
        {
            InitialDirectory= initialDirectory;
            Pattern = pattern;
        }

        private void CountFiles(string initialDirectory)
        {
            FindFilesInDirectory(initialDirectory);

            if (OnFileNumberFound != null)
            {
                OnFileNumberFound();
            }
        }


        private void FindFilesInDirectory(string currentDirectory)
        {
            try
            {
                FileNumber += Directory.GetFiles(currentDirectory).Length;
                
                foreach (var directory in Directory.GetDirectories(currentDirectory))
                {
                    _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    FindFilesInDirectory(directory);
                }
            }


            catch (OperationCanceledException)
            {
                throw;
            }


            catch (Exception)
            {
                // ignored
            }
        }


        private void Find(string currentDirectory)
        {
            try
            {
                string[] files = Directory.GetFiles(currentDirectory);
                foreach (var file in files)
                {
                    _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    StreamReader sr = null;
                    try
                    {
                        ProcessedFileNumber += 1;
                        if (OnFileProcessed != null && _countFileTask.IsCompleted)
                        {
                            OnFileProcessed((double) ProcessedFileNumber / FileNumber);
                        }

                        sr = new StreamReader(file);
                        bool found = false;
                        while (!sr.EndOfStream && !found)
                        {
                            string line = sr.ReadLine();
                            if (line.Contains(Pattern))
                            {
                                found = true;
                                if (OnFileFound != null)
                                {
                                    OnFileFound(file);
                                }
                            }
                        }
                    }
                    catch
                    {
                        if (OnErrorOcured != null)
                        {
                            OnErrorOcured(string.Concat(Resources.SearchEngine_Find_Error_processing_file_message, file));
                        }
                    }
                    finally
                    {
                        if (sr != null)
                            sr.Close();
                    }
                }

                foreach (var directory in Directory.GetDirectories(currentDirectory))
                {
                    Find(directory);
                }
            }

            catch (OperationCanceledException)
            {
                throw;
            }

            catch
            {
                if (OnErrorOcured != null)
                {
                    OnErrorOcured(string.Concat(Resources.SearchEngine_Find_Error_directory_message, currentDirectory));
                }
            }
        }

        public void StopSearch()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        public async Task GetFilesAsync()
        {
            FileNumber = 0;
            ProcessedFileNumber = 0;

            _cancellationTokenSource = new CancellationTokenSource();
            _countFileTask = Task.Factory.StartNew(() => CountFiles(InitialDirectory), _cancellationTokenSource.Token);
            await Task.Factory.StartNew(() => Find(InitialDirectory), _cancellationTokenSource.Token);
        }
    }
}
