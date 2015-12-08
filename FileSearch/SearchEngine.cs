using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileSearch
{
    class SearchEngine
    {
        public string InitialDirectory { get; set; }
        public string Pattern { get; set; }
            
        private const string DefaultInitialDitectory = "../../";
        private const string DefaultPattern = "text";

        public Action<string> OnFileFound;
        private CancellationTokenSource _cancellationTokenSource;

        public SearchEngine()
            : this(DefaultInitialDitectory, DefaultPattern)
        {
        }


        public SearchEngine(string initialDirectory, string pattern)
        {
            InitialDirectory= initialDirectory;
            Pattern = pattern;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void Find(string currentDirectory)
        {
            try
            {
                _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                string[] files = Directory.GetFiles(currentDirectory);
                foreach (var file in files)
                {
                    StreamReader sr = null;
                    try
                    {
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
                    catch (Exception e)
                    {
                        Console.WriteLine("Error processing file {0}: {1}", file, e.Message);
                    }
                    finally
                    {
                        if (sr != null)
                            sr.Close();
                    }
                }
                // Now look through all directories inside the current (recursive call)
                foreach (var directory in Directory.GetDirectories(currentDirectory))
                    Find(directory);
            }

            catch (OperationCanceledException)
            {
                throw;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error directory {0}: {1}", currentDirectory, e.Message);
            }
        }

        public void StopSearch()
        {
            _cancellationTokenSource.Cancel();
        }

        public async Task GetFiles()
        {
            await Task.Factory.StartNew(() => Find(InitialDirectory), _cancellationTokenSource.Token);
        }
    }
}
