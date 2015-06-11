Assembly assembly = this.GetType().Assembly;
string resourceName = "MyCompany.MyApplication.file.txt";
string content = EmbeddedResourceReader.ReadString(assembly, resourceName);