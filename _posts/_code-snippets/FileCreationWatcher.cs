public sealed class FileCreationWatcher : IDisposable
{
  private FileSystemWatcher _watcher;

  public FileCreationWatcher(string path, string filter)
  {
    Initialize(path, filter);
  }

  private void Initialize(string path, string filter)
  {
    _watcher = new FileSystemWatcher(path, filter);
    _watcher.Created += OnFileCreated;
    _watcher.Error += OnError;
  }

  private void OnFileCreated(object sender, FileSystemEventArgs e)
  {
    FileInfo file = new FileInfo(e.FullPath);
    if (file.Exists)
    {
      // schedule the processing on a different thread
      ThreadPool.QueueUserWorkItem(delegate
      {
        while(true)
        {
          // wait 100 milliseconds between attempts to read
          Thread.Sleep(TimeSpan.FromMilliseconds(100));
          try
          {
            // try to open the file
            file.OpenRead().Close();
            break;
          }
          catch(IOException)
          {
            // if the file is still locked, keep trying
            continue;
          }
        }

        // the file can be opened successfully: raise the event
        FileSystemEventHandler handler = Created;
        if (handler != null)
        {
          handler(this, e);
        }
      });
    }
  }

  private void OnError(object sender, ErrorEventArgs e)
  {
    // when an error occurs, the current FileSystemWatcher is disposed,
    // and a new one is created
    
    string path = _watcher.Path;
    string filter = _watcher.Filter;
    _watcher.Dispose();
    Initialize(path, filter);
  }

  public void Start()
  {
    _watcher.EnableRaisingEvents = true;
  }

  public void Stop()
  {
    _watcher.EnableRaisingEvents = false;
  }

  public event FileSystemEventHandler Created;

  public void Dispose()
  {
    _watcher.Dispose();
  }
}