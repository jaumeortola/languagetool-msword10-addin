(See below in [English](#english))
# LanguageTool per a MS Word (català)

[LanguageTool](https://www.languagetool.org) és un programa de revisió lingüística de codi obert per a més de 20 llengües. Amb aquest complement ("add-in") el podreu fer servir en el Microsoft Word (per a Windows). 

Aquesta implementació està en català i té opcions de configuració específiques per a aquesta llengua. Però també es pot servir amb les altres llengües que tenen suport en LanguageTool.

### Instal·lació
* Descarregueu [Languagetool](https://www.languagetool.org) (versió com a programa independent) i executeu-lo en [mode servidor](http://wiki.languagetool.org/http-server) (port per defecte: 8081). Alternativament, podeu usar alguna API pública de LanguageTool com languagetool.org o softcatala.org.
* Baixeu [l'última versió](https://github.com/jaumeortola/languagetool-msword10-addin/releases/latest) del complement, descomprimiu i instal·leu.
* De moment, la versió publicada no està signada amb el certificat apropiat, i això pot causar algun problema a l'hora d'instal·lar el complement. 

### Versions de MS Word
De moment només s'ha provat en Microsoft Word 2010 (Windows). 

### Com funciona
* En el MS Word podeu trobar el grup de botons de LanguageTool group en el menú "Complements". Només hi ha dos botons: Revisa (per a començar la revisió des del paràgraf actual) i Opcions. 
* El text s'envia al servidor de LanguageTool per paràgrafs on és analitzat. 
* Els possibles errors i suggeriments es mostren en un quadre de diàleg. 

### Limitacions
* Els errors no són subratllats o ressaltats en el text a mesura que s'escriu. Aquesta funció és desitjable, però amb la tecnologia usada en aquest projecte no es pot implementar sense causar efectes no volguts en el funcionament del MS Word.  

### Llicència
* LGPL 2.1 o posterior.

---

# <a name="english"></a>LanguageTool for MS Word (English)


[LanguageTool](https://www.languagetool.org) is an open source proof-reading program with support for more than 20 languages. With this add-in you can use it in Microsoft Word (Windows OS).

The current implementation is in Catalan and has setup options specific to Catalan.


### Installation
* Download [Languagetool](https://www.languagetool.org) (desktop version) and run it in [server mode](http://wiki.languagetool.org/http-server) (port by default: 8081). Alternatively, you can use some public LanguageTool API (for instance in  languagetool.org or softcatala.org), but this discouraged specially if you work with long documents.
* Download [the latest vestion](https://github.com/jaumeortola/languagetool-msword10-addin/releases/latest) of the add-in, unzip and install.
* At the moment, the released version is not signed with a certificate, and this can cause some problem when installing the add-in.

### MS Word versions
* The add-in has been tested only in Microsoft Word 2010. 

### How it works
* In MS Word, the LanguageTool group can be found under the "Add-ins" menu. There are just two buttons: Check (to start checking from the current paragraph) and Settings.
* The text is sent to the LanguageTool server by paragraphs where it is analyzed.
* The possible errors and suggestions for replacement are shown in a dialog box.

### Limitations
* The errors are not underlined or highlighted in the text. This is a desirable feature, but it is too difficult to implement, with the technology used here, without causing unwanted effects on the operation of MS Word.  

### License
* LGPL 2.1 o posterior.


---
![Generalitat de Catalunya](/languagetool-msword10-addin/Resources/suportGenCat.png "Generalitat de Catalunya")

