import datetime
import time
lokitiedosto = r"C:\Temp\Python-loki.txt"

def kirjoita_lokiin(viesti):
    kellonaika = datetime.datetime.now()
    rivi = str(kellonaika) + ": " + viesti + "\n"
    tiedosto = open(lokitiedosto, "a")
    tiedosto.write(rivi)
    tiedosto.close()
    print(rivi)

kirjoita_lokiin("Moi!")
time.sleep(5)
kirjoita_lokiin("Toinen rivi.")
