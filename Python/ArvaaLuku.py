import random

oikea_vastaus = random.randint(1,20)
# print(oikea_vastaus)

for i in range(3):
    arvaus = int(input("Arvauksesi välillä 1-20: "))

    if arvaus < oikea_vastaus:
        print("Oikea luku on suurempi.")
    elif arvaus > oikea_vastaus:
        print("Oikea luku on pienempi.")
    elif arvaus == oikea_vastaus:
        print("Oikein arvattu! Hienoa työtä!")
        break

print("Peli on päättynyt.")
