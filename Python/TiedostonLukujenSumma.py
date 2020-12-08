tiedostoPolku = r"C:\Robotiikka\Python\Numerot.txt"

tiedosto = open(tiedostoPolku, "r")

summa = 0
for rivi in tiedosto:
    luku = int(rivi)
    summa = summa+luku

print(summa)
tiedosto.close()

# ---------------------
f = open ("numerot.txt","r"); print(sum([int(i) for i in f])); f.close()
