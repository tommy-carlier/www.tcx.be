---
layout: post
title: Writing a parser: basic terminology
---

Programming code (or any code that should be parsed) is usually plain text. It’s just a sequence of characters. A **tokenizer** converts this sequence of characters into a sequence of tokens. A token is a group of characters that form a meaningful unit.

![Converting characters to tokens](http://www.tcx.be/assets/adl/chars-to-tokens.png)

The **parser** analyzes this sequence of tokens and transforms it into a tree of operators (primitive functions) and operands (the arguments of the operators).

![Transforming tokens into a tree](http://www.tcx.be/assets/adl/tokens-to-tree.png)
