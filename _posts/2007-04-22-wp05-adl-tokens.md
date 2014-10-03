---
layout: post
title: "Writing a parser: ADL tokens"
---

ADL only has 4 different tokens:

- **Word**: A word starts with a letter, followed by zero or more letters or numbers.<br>
  Examples: `x`, `abc`, `f2`, `else`.
- **Integer**: An integer is a sequence of one or more digits.<br>
  Examples: `1`, `42`, `3141592654`.
- **String**: A string is a sequence of characters enclosed in quotes.<br>
  Examples: `"x"`, `"abc"`, `"Quid pro quo."`.
- **Symbol**: A symbol is one of the following sequences:<br>
  `+ - * / ( ) , := == < > <> <= >=`

To identify tokens, we'll use an `enum` named `TokenType`:

```csharp
namespace TC.Adl
{
  public enum TokenType
  {
    None = 0,
    Word,
    Integer,
    String,
    Symbol,
  }
}
```

<small>(The value None is the default value and should not occur)</small>

A token has a type (of type `TokenType`) and a value (of type `string`). The value is the sequence of characters that represent the token.

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace TC.Adl
{
  public class Token
  {
    public Token(TokenType type, string value)
    {
      _type = type;
      _value = value;
    }

    private readonly TokenType _type;
    public TokenType Type { get { return _type; } }

    private readonly string _value;
    public string Value { get { return _value; } }

    public bool Equals(TokenType type, string value)
    {
      return _type == type && _value == value;
    }
  }
}
```

You may have noticed that there are no comments or argument validation code. This is just to make the code simpler and easier to understand at first sight. The code I’m writing in Visual Studio is fully commented and has all the necessary argument validation code. I’ll release the entire library afterwards.

Next time, we’ll write the tokenizer.