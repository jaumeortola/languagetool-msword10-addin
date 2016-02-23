(See below in [English](#english))
# LanguageTool per a MS Word (català)

[LanguageTool](https://www.languagetool.org) és un programa de revisió lingüística de codi obert per a més de 20 llengües. Amb aquest complement ("add-in") el podreu fer servir en el Microsoft Word (per a Windows). 

Aquesta implementació està en català i té opcions de configuració específiques per a aquesta llengua. Però també es pot servir amb les altres llengües que tenen suport en LanguageTool.

### Instal·lació
* Descarregueu [Languagetool](https://www.languagetool.org) (versió com a programa independent) i executeu-lo en [mode servidor](http://wiki.languagetool.org/http-server) (port per defecte: 8081). Alternativament, podeu usar alguna API pública de LanguageTool com languagetool.org o softcatala.org.
* Baixeu [l'última versió](https://github.com/jaumeortola/languagetool-msword10-addin/releases/latest) del complement, descomprimiu i instal·leu.
* En alguns casos, cal reiniciar l'ordinador. 

### Requisits
* Requereix Microsoft .Net 4.5.2. Si no el teniu instal·lat, podeu descarregar-lo [aquí](https://www.microsoft.com/en-us/download/details.aspx?id=42643). No funciona en versions anteriors a Windows Vista SP2.
* S'ha provat en Microsoft Word 2007 i 2010 (Windows). 

### Com funciona
* En el MS Word podeu trobar el grup de botons de LanguageTool group en el menú "Complements". Només hi ha dos botons: Revisa (per a començar la revisió des del paràgraf actual) i Opcions. 
* El text s'envia al servidor de LanguageTool per paràgrafs on és analitzat. 
* Els possibles errors i suggeriments es mostren en un quadre de diàleg. 

### Limitacions
* Els errors no són subratllats o ressaltats en el text a mesura que s'escriu. Aquesta funció és desitjable, però amb la tecnologia usada en aquest projecte no es pot implementar sense causar efectes no volguts en el funcionament del MS Word.
* En comptes de triar un dels suggeriments oferts en el quadre de diàleg, es pot editar directament el fragment de text on hi ha l'error. En alguns casos això pot afectar la formatació del text.

### Llicència
* LGPL 2.1 o posterior.

---

# <a name="english"></a>LanguageTool for MS Word (English)


[LanguageTool](https://www.languagetool.org) is an open source proof-reading program with support for more than 20 languages. With this add-in you can use it in Microsoft Word (Windows OS).

### Installation
* Download [LanguageTool](https://www.languagetool.org) (desktop version) and run it in [server mode](http://wiki.languagetool.org/http-server) (port by default: 8081). Alternatively, you can use some public LanguageTool API (for instance in languagetool.org or softcatala.org), but this is discouraged specially if you work with long documents.
* Download [the latest version](https://github.com/jaumeortola/languagetool-msword10-addin/releases/latest) of the add-in, unzip and install.
* In some cases you may need to reboot the computer.

### Requirements
* Microsoft .Net 4.5.2. If it is not installed, you can download it [here](https://www.microsoft.com/en-us/download/details.aspx?id=42643). It does not work in versions prior to Windows Vista SP2.
* The add-in has been tested in Microsoft Word 2007 and 2010 (Windows).

### How it works
* In MS Word, the LanguageTool group can be found under the "Add-ins" menu. There are just two buttons: Check (to start checking from the current paragraph) and Settings.
* The text is sent to the LanguageTool server by paragraphs where it is analyzed.
* The possible errors and suggestions for replacement are shown in a dialog box.

### Limitations
* The errors are not underlined or highlighted in the text. This is a desirable feature, but it is too difficult to implement, with the technology used here, without causing unwanted effects on the operation of MS Word. 
* Instead of choosing one the suggestions shown in the dialog box, you can edit the piece of text where the error is found. In some cases, this replacement can affect the text format.


### License
* LGPL 2.1 or later.

<img src="/msword-lt-addin-screenshot.jpg" width="400"/> 

---
![Generalitat de Catalunya](/languagetool-msword10-addin/Resources/suportGenCat.png "Generalitat de Catalunya")


