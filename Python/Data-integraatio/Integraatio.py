from xml.dom import minidom
import json

# USD-valuuttakurssin lukeminen
usdKurssi = 1.0
valuutat = minidom.parse("Integraatioharjoitus - Valuuttakurssi.xml")
kurssit = valuutat.getElementsByTagName("Cube")
for kurssi in kurssit:
    valuutanNimi = kurssi.getAttribute("currency")
    kurssinArvo = kurssi.getAttribute("rate")
    if valuutanNimi == "USD":
        usdKurssi = float(kurssinArvo)
        print(kurssinArvo)

# palkkatietojen lukeminen
mydoc = minidom.parse("Integraatioharjoitus - Palkanlaskenta.xml")

jsonData = []

items = mydoc.getElementsByTagName("palkka")
for elem in items:
    palkka = elem.getElementsByTagName("kuukausittain")[0].firstChild.data
    palkkaUsdnä = float(palkka) * usdKurssi
    nimi = elem.getElementsByTagName("nimi")[0].firstChild.data

    # työsuhteen alkamispäivää ei ole kaikilla työntekijöillä
    päiväElementti = elem.getElementsByTagName("työsuhdealkoi")
    palkkausPäivä = ""
    if päiväElementti.length > 0:
        palkkausPäivä = päiväElementti[0].firstChild.data
        
    jsonData.append({
        "personName": nimi,
        "salary": {
            "monthly": palkkaUsdnä
        },
        "hireDate": palkkausPäivä
    })
    print(nimi, palkka)

# kirjoitetaan JSON-tiedosto
with open("Tulokset.json", "w") as outfile:
    json.dump(jsonData, outfile)

print("JSON-tiedoston kirjoitus on valmis.")
