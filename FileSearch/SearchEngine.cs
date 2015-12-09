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
            
        private const string DefaultInitialDitectory = "../../";
        private const string DefaultPattern = "text";

        public Action<string> OnFileFound;
        public Action<string> OnErrorOcured;
        public Action<long> OnMaxFileNumberChanged;
        public Action OnFileProcessed;

        private CancellationTokenSource _cancellationTokenSource;

        public SearchEngine()
            : this(DefaultInitialDitectory, DefaultPattern)
        {
        }


        public SearchEngine(string initialDirectory, string pattern)
        {
            InitialDirectory= initialDirectory;
            Pattern = pattern;
        }

        private void CountFiles(string currentDirectory)
        {
            _cancellationTokenSource.Token.ThrowIfCancellationRequested();
            try
            {
                string[] files = Directory.GetFiles(currentDirectory);
                if (OnMaxFileNumberChanged != null)
                {
                    OnMaxFileNumberChanged(files.Length);
                }
                foreach (var directory in Directory.GetDirectories(currentDirectory))
                    CountFiles(directory);
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
                        if (OnFileProcessed != null)
                        {
                            OnFileProcessed();
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
                    Find(directory);
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
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(() => CountFiles(InitialDirectory), _cancellationTokenSource.Token);
            await Task.Factory.StartNew(() => Find(InitialDirectory), _cancellationTokenSource.Token);
        }
    }
}
