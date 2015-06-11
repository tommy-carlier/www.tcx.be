public class MyClass
{
  private static readonly Destructor _destructor;

  static MyClass()
  {
    DestructorDelegate destructorMethod;
    destructorMethod = new DestructorDelegate(Destroy);
    _destructor = new Destructor(destructorMethod);
  }

  private static void Destroy()
  {
    // this is the static destructor-method
  }
}