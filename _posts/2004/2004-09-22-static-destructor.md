---
layout: post
title: Static destructor in C#
---

C# (and .NET in general) offers static constructors for classes, but why are there no **static destructors**? I needed such a static destructor for a class that had to clean up resources. So I created a little helper-class that adds *static destructor*-functionality to a class:

```csharp
public delegate void DestructorDelegate();
public class Destructor
{
    private DestructorDelegate destructorMethod;
    public Destructor(DestructorDelegate method)
    {
        destructorMethod = method;
    }

    ~Destructor()
    {
        if (destructorMethod != null) destructorMethod();
    }
}
```

Here's an example that shows how to use it:

```csharp
public class MyClass
{
    private static Destructor myDestructor;
    static MyClass()
    {
        DestructorDelegate destructorMethod;
        destructorMethod = new DestructorDelegate(this.Destroy);
        myDestructor = new Destructor(destructorMethod);
    }

    private static void Destroy()
    {
        // this is the static destructor-method
    }
}
```