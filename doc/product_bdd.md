# BDD tesztek készítése Specflow segítségével

A BDD (viselkedésvezérelt programozás) az egy tesztelési forma, ahol a tesztelés felhasználó számára könnyen érthető (mondatszerű) formában történik. Az angol nyelv szavaival könnyen leírható parancsok segítségével lehet ellenőrizni a program működését.

## Specflow

A Specflow-t választottuk a megadott technológiák közül, mert azt .NET-es projektekhez könnyen fel lehet használni. Telepítettük egy extensionként Visual Studioba, majd a segítségével írtunk néhány kézi tesztet.

## Tesztelt osztályok:

> **RDFSharp**: Teszteltük az alap konstruktorát és néhány alapvető funkcióját, hogyan viselkednek az adattagjai. Illetve teszteltük, hogy 2 gráf objektumnak hogyan működik az unió művelete.
>
> **RDFCollection**: Teszteltük az alap függvényeit, illetve hogy hogyan lehet belőle gráfot létrehozni, azaz hogyan viselkedik más osztállyal.
>
> **RDFQuery**: Létrehoztunk egy alap gráfot, amiket feltöltöttünk termékekkel (amiknek van ára). Majd létrehoztunk egy lekérdezést, ami segítségével meg lehet keresni a minimális illetve maximális értékű terméket.

## Végleges tesztek lefutása:

![final_results](/doc/pics/product_bdd_pic3.png)

### BDD tesztelés esetén a feladatok:

1. Kiválasztani azt az osztályt/függvényt/funkciót a programból, amit tesztelni szeretnénk.
2. Megírni a hozzá tartozó tesztelő függvényt, hozzá pedig az ember számára értelmezhető futtató parancsot.
3. Megírni a szenáriókat.
4. Lefuttatni a teszteket, majd az eredményekből következtetést levonni.

#### Példa az `RDFGraph` osztály részfunkcióinak tesztelésére:

##### Példa ezenárió:

![scenario](/doc/pics/product_bdd_pic1.png)

##### Példa eredmény:

![result](/doc/pics/product_bdd_pic2.png)