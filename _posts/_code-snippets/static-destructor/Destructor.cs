public delegate void DestructorDelegate();

public sealed class Destructor
{
  private readonly DestructorDelegate _destructorMethod;
  
  public Destructor(DestructorDelegate method)
  {
    _destructorMethod = method;
  }

  ~Destructor()
  {
    if (_destructorMethod != null)
    {
      _destructorMethod();
    }
  }
}