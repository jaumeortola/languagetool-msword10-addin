# languagetool-msword10-addin

Microsoft Word add-in for [LanguageTool](www.languagetool.org). LanguageTool is an open source proof-reading program with support for more than 20 languages.

### Requirements
* Download [Languagetool](www.languagetool.org) and run it in [server mode](http://wiki.languagetool.org/http-server).

### Tested
For now it has ben tested only in Microsoft Word 2010. 

### How it works
* The text is send to the LanguageTool server by paragraphs where it is analyzed. 
* Possible spelling, grammar and style errors are highlighted using the "highlight" feature of MS Word.
* A right-click on the highlighted words shows a message and a list of possible replacements. 

### Known limitations
* The "highlight" feature of MS Word is no longer usable together with the add-in. 
* Information about the errors is stored in hidden fields inside the text. 
* Support for long documents (i. e. checking in background) is not complete.  

### Licence
