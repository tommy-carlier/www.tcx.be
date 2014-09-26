---
layout: post
title: "Writing a parser"
---

Inspired by a thread about parsers on Channel 9, I’ve decided to start a series of blog posts on writing a parser. The parser I (and hopefully some of you) will write, will be able to parse a simple BASIC-like language with enough features to make it interesting, without being too complex.

The name of the language will be ADL, which stands for *Acronymic Demonstrational Language*. A pretty lame name but if you have a better name, please let me know. I’ll try to show you how easy it is to write a good parser using simple techniques (reading 1 character at a time, no state-machine) without a lot of dry theory. The first introductory post (after this one) will have some theory and some terminology you need to know, but after that the fun will start.