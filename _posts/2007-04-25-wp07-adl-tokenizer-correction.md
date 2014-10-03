---
layout: post
title: "Writing a parser: ADL Tokenizer: correction"
---

[Sushovan](https://www.blogger.com/profile/11160553154275818207) made a great remark on [my previous post]({% post_url 2007-04-24-wp06-adl-tokenizer %}). He asked me why I didn’t use the method [char.IsWhiteSpace()](http://msdn.microsoft.com/en-us/library/t809ektx.aspx) to test for white-space. The reason I didn’t, was ignorance: I was not aware that method existed. So it’s probably a good idea to change the method `SkipWhitespace` to this:

```csharp
private void SkipWhitespace()
{
  while (char.IsWhiteSpace(_currentChar))
  {
    ReadNextChar();
  }
}
```