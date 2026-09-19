# UniCon.PenumbraMeta.Demo Project

This demo takes a mod `meta.json` as its only command-line argument and uses `UniCon.PenumbraMeta` to dump all the info about it to standard output.

I recommend configuring Visual Studio's launch settings to automatically supply a `meta.json` as a command line argument when launching, or dragging a `meta.json` file from the File Explorer directly onto the `.exe` to test.

## Visitor Pattern

About half the code in this demo is in its `ManipulatorPrinter`, `ConditionPrinter`, and `GroupPrinter` classes. These are examples of using the 'Visitor Pattern', which is a type-safe, object-oriented, and extremely performant alternative to using pattern-matching or long chains of `if (xxx is Subtype)` to handle subclasses.

The visitor pattern can be a bit overwhelming at first and you are welcome to ignore it and use `UniCon.PenumbraMeta` without it, but I would encourage you to at least give the visitor pattern a shot!