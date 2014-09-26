---
layout: post
title: FileCreationWatcher
---

A few weeks ago, I received an e-mail from someone who asked me if I could give more details about a class I created at work, that is essentially a wrapper around the [FileSystemWatcher](http://msdn.microsoft.com/en-us/system.io.filesystemwatcher.aspx) class, and that detects the creation of files more reliably. I sent him an e-mail back, with a simplified version of the wrapper class, and because I think this could also be useful for other people, I decided to post it here.

```csharp
public class FileCreationWatcher : IDisposable
{
  FileSystemWatcher _watcher;

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

  void OnFileCreated(object sender, FileSystemEventArgs e)
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
    watcher.EnableRaisingEvents = false;
  }

  public event FileSystemEventHandler Created;

  #region IDisposable Members

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  ~FileCreationWatcher() 
  {
    Dispose(false);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (disposing)
    {
      _watcher.Dispose();
    }
  }

  #endregion
}
```