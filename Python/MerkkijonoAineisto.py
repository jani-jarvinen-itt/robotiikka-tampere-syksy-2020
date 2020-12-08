aineisto = """Matti;32
Maija;29
Otso;16
Pena;56"""

person = aineisto.split("\n")
for item in person:
    if(int(item[-2:]) < 40):
        print(item[:-3])
