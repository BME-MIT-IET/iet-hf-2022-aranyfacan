# Deployment segítése Docker segítségével

A deployment segítését szolgáló programok egy konténert kínálnak, amely által bármilyen környezetben le tudjuk futtatni az alkalmazást anélkül, hogy a szükséges
könyvtárakat feltelepítenénk.

## Docker

A Docker egy olyan szoftver, ami a fent említett konténereket létrehozza, kezeli és futtatja. Csupán a Docker Desktop alkalmazásra van szükségünk bármilyen projekt esetén.
A feladat során ezzel valósítottuk meg a deployment segítését.

## A feladat elkészítésének folyamata

Egy Visual Studio extension segítségével legeneráltam a Dockerfile-t és a .dockerignore-t. Ez a kát fájl szükséges a konténer létrehozásához. Ezek után létrehoztam a 
Docker image-et, majd tesztelés képpen lefuttattam azt. Esetünkben a program a megadott könyvtár alapján létrehoz pár entitást és ezt kiírja a kimenetre.

## A Dockerfile tartalma

![Dockerfile tartalma](/doc/pics/dockerfile.PNG)

## Kiadott parancsok

Image létrehozása ietlab/aranyfacan néven: *docker build -t ietlab/aranyfacan .*
A kapott konténerbeli image lefutattása: *docker run -it --rm ietlab/aranyfacan* 

## Kapott kimenet

# Saját tapasztalat

Az elején magamtól próbáltam létrehozni a Dockerfile-t, ami sajnos sok időt el vitt és nem is működött. Ezután megtaláltam, hogy Visual Studio-ban létezik erre egy
extension. Ezzel már jóval egyszerűbb volt a munka, így azt mondanám, hogy nagyon hasznos alkalmazása a Docker, mivel jóval megkönnyíti a fejlesztők és a tesztelők
dolgát is.
