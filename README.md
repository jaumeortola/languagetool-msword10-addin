# LanguageTool per a MS Word (català)

[LanguageTool](https://www.languagetool.org) és un programa de revisió lingüística de codi obert per a més de 20 llengües. Amb aquest complement ("add-in") el podreu fer servir en el Microsoft Word. 

Aquesta implementació està en català i té opcions de configuració específiques per a aquesta llengua. Però també es pot servir amb les altres llengües que tenen suport en LanguageTool.

### Instal·lació
* Descarregueu [Languagetool](https://www.languagetool.org) (versió com a programa independent) i executeu-lo en [mode servidor](http://wiki.languagetool.org/http-server) (port per defecte: 8081). Alternativament, podeu usar alguna API pública de LanguageTool com languagetool.org o softcatala.org.
* Baixeu [l'última versió](https://github.com/jaumeortola/languagetool-msword10-addin/releases/latest) del complement, descomprimiu i instal·leu.

### Versions de MS Word
De moment només s'ha provat per a Microsoft Word 2010. 

### Com funciona
* En el MS Word podeu trobar el grup de botons de LanguageTool group en el menú "Complements". Només hi ha dos botons: Revisa (per a començar la revisió) i Opcions. 
* El text s'envia al servidor de LanguageTool per paràgrafs on és analitzat. 
* Els possibles errors i suggeriments es mostren en un quadre de diàleg. 

### Limitacions
* Els errors no són subratllats o ressaltats en el text a mesura que s'escriu. Aquesta funció és desitjable, però amb la tecnologia usada en aquest projecte no es pot implementar sense causar efectes no volguts en el funcionament del MS Word.  

### Llicència
* LGPL 2.1 o posterior.
* La versió publicada (encara) no està signada amb el certificat apropiat.

---
![Generalitat de Catalunya](/languagetool-msword10-addin/Resources/suportGenCat.png "Generalitat de Catalunya")

