# languagetool-msword10-addin

Microsoft Word add-in for [LanguageTool](https://www.languagetool.org). LanguageTool is an open source proof-reading program with support for more than 20 languages.

The current implementation is in Catalan and has setup options specific to Catalan.  

### Installation
* Download [Languagetool](https://www.languagetool.org) (desktop version) and run it in [server mode](http://wiki.languagetool.org/http-server) (default port: 8081). Alternatively, you can use public APIs in languagetool.org or softcatala.org.
* Download the [last release](https://github.com/jaumeortola/languagetool-msword10-addin/releases/latest), unzip and install.

### Versions of MS Word
For now it has been tested only in Microsoft Word 2010. 

### How it works
* In MS Word, the LanguageTool group can be found under the "Add-ins" menu. There are just two buttons: Check (to start checking) and Settings. 
* The text is sent to the LanguageTool server by paragraphs where it is analyzed. 
* The possible errors and suggestions for replacement are shown in a dialog box.

### Known limitations
* The errors are not underlined or highlighted in the text. This is a desirable feature, but it is too difficult to implement without causing unwanted effects on the operation of MS Word. 

### License
* This add-in is freely available under the LGPL 2.1 or later.
* The release version is not (yet) signed with an appropriate certificate.
