# Gyakorló I. Zárthelyi Dolgozat

<br>
<br>

A feladat megoldása során a tanult elveket, szintaktikákat javasolt alkalmazni.

A feladatban felhasználandó állomány: [pizzas-database.xml](https://users.nik.uni-obuda.hu/siposm/db/pizza-database.xml)

Figyelem! Jelen feladathoz megoldás (kód) nincs. A `ZH1` mappában található feladat egy másik feladatsorra vonatkozik. Részletekért lásd `README.md` abban a mappában.

<br>
<br>

## Feladat 0.
Hozzon létre egy class library projektet `ConsoleLoggerLibrary` néven. Hozzon létre benne egy osztály `ConsoleLogger` néven, benne egy void `ConsoleLog` metódust, amely egy `object` típust fogad. Az object-et írja ki a konzolra, a ToString metódus segítségével. Társítsa hozzá a másik (lentebbi következő) projekthez.

## Feladat 1.
Készítsen egy `IPizza` interfészt, ami az alábbi publikus tulajdonságokat írja elő:
- string Type { get; set; }
- int Size { get; set; }
- int PastaThickness { get; set; }
- int NumberOfToppings { get; set; }
- double Price {get; set; }

Készítsen egy `Pizza` osztályt, amely valósítsa meg az `IPizza` interfészt.

Egészítse ki ezt az osztályt az alábbi tulajdonsággal:
- string FantasyName { get; set; }

Egészítse ki ezt az osztályt egy ToString metódussal, amely reflexió segítségével a saját (jelölt) tulajdonságait és az aktuális értékét fogja string formájában visszaadni. A jelöléshez hozza létre a megfelelő `ToStringAttribute` osztályt a tanultaknak megfelelően, és tegye rá ezt az összes tulajdonságra (de tetszőlegesen lehet variálni, hogy csak kevesebbre kerül rá).

## Feladat 2.
Készítsen egy `FantasyNameValidatorAttribute` osztályt, amely rendelkezzen a következő tulajdonságokkal:
- char Character { get; set; }
- int Length { get; set; }

Az osztályra tegyen megszorítást, hogy csak tulajdonságokra lehessen alkalmazni. Az előzőekben létrehozott (`Pizza` osztály) FantasyName tulajdonságra alkalmazza az attribútumot, értéknek adja meg a $ karaktert, valamint a 10 értéket, mint hosszt.

## Feladat 3.
Készítsen egy `Validator` osztályt, amelyben egy bool `CheckFantasyName` metódus segítségével vizsgálja meg, hogy a paraméternek kapott object rendelkezik-e FantasyName tulajdonsággal, s amennyiben igen, úgy vizsgálja meg, hogy az attribútumban megadottaknak eleget tesz-e az értéke, azaz rendelkezik-e a megadott karakterrel és van-e legalább olyan hosszú karakterszámra. Ha igen, igaz értékkel térjen vissza, egyéb esetben hamissal. A feladat elvégzését reflexióval valósítsa meg.

## Feladat 4.
Készítsen egy `Detector` osztályt, benne egy void `DetectPizzaClasses` metódussal. A metódus futásidőben vizsgálja meg reflexió segítségével az aktuális osztályokat, ezek nevét kérje le fordított ABC sorrendbe rendezve egy tömbbe. Figyeljen, hogy csak azokat az osztályokat kérje le, amelyek az `IPizza` interfészt megvalósítják. A látványosabb teszteléshez készítsen a `Pizza` osztályból három darab leszármazottat (`VegaPizza`, `NagyPizza`, `BebiPizza`). Ezekben további dolgok nem lesznek elhelyezve. A lekért típusokat írja ki XML fájlba (`pizzaClasses.xml` néven) figyelve az XML struktúra betartására. Írja ki az osztályokat nevét és a nevek hashkódját. A gyökérben attribútumként helyezze el, hogy hány osztály van összesen.

## Feladat 5.
Hozzon létre egy `Func` delegáltat, amely egy fájl nevet kap bemenetnek (string) és egy `IEnumerable<Pizza>` típussal tér vissza. A delegáltba hozzon létre egy névtelen függvényt, amelyben a kapott fájlt (`pizzas.xml` ld. később) beolvassa és egy `List`-et állít elő. Elegendő csak a fantázianeveket kiválasztani a `Pizza` objektumok előállításakor. Ezt követően hívja meg a delegáltat és az előállt kimenetet validálja le fantázianevek alapján. Az eredményt a korábban létrehozott class libraryban definiált `ConsoleLogger` segítségével írassa ki.

## Feladat 6.
Olvassa be a `pizza-database.xml` állományt és hajtsa végre rajta a következő lekérdezéseket:
- 6.1. kérdezze le azokat a pizzákat amelyek fantázianevében nem szerepel a pizza szó
- 6.2. kérdezze le, hogy az egyes méretekből hány darab van, majd rendezze ezeket darabszám alapján csökkenő sorrendbe (a kimenet egy új névtelen osztályban legyen TYPE és COUNT mezőkkel)
- 6.3.1. kérdezze le a pizzák nevét és típusát, amelyek legalább 4 feltéttel rendelkeznek
- 6.3.2. határozza meg, hogy mennyi ezeknek az átlagos ára típusonként
- 6.4. kérdezze le, hogy átlagosan mennyi az ára az egyes méretű pizzáknak (a kimenet egy új névtelen osztályban legyen SIZE és AVGSAL mezőkkel)
- 6.5. határozza meg, hogy melyik pizzát éri meg megvenni a leginkább (az ár & feltétek száma & méret paraméterek tekintetében)
- 6.6. határozza meg, hogy hány paradicsomos alapú pizza van amelyeknek a feltétszáma kevesebb mint a második legtöbb feltéttel rendelkező pizza (az összes közül) és amelyeknek az ára a középső ársávban található. középső ársáv alatt a maximális ár és a minimális ár plusz/minusz 10%-át értjük
- 6.7.1. módosítsa úgy az xml elemeit, hogy ahol "cm" attribútum érték található, ott írja ki helyette (a fájlban), hogy "centimetres"
- 6.7.2. hasonló elv mentén a pizza neve mellé helyezze el "chars" nevű attribútumként, hogy hány karakterből áll a neve. az új xml-t `_mod.xml` néven mentse el
- 6.8. határozza meg, hogy az egyes méretekből típusonként hány darab található
- 6.9. kérje le, hogy melyek azok a pizzák amelyeknek a neve kevesebb karakterből áll mint a PastaThickness (tészta vastagás) és a NumberOfToppings (feltétek száma) összegének a kétszerese
- 6.10. határozza meg, hogy melyik pizzából lehet kettőt vagy többet vásárolni, úgy, hogy még mindig kevesebb összegbe kerül, mint a legdrágább pizza (több elfogadható megoldás esetén mindre kíváncsiak vagyunk)
- 6.11. határozza meg, hogy a VIP státusszal ellátott pizzák átlagára az olcsóbb, vagy pedig a sima pizzák átlagára
- 6.12. határozza meg, hogy a VIP vagy sima pizzáknál fordul elő többször a 30-as méret
- 6.13. határozza meg, hogy a VIP vagy a sima pizzáknál fordul elő átlagosan a hosszabb elnevezés

## Feladat 7.
Dolgozza fel az összes nem VIP pizzát és határozza meg a következőket amolyan vezetői kimutatás formájában:
- átlagos ár 3 tizedesjegy pontossággal
- leggyakoribb méret
- leggyakoribb típus (base (alap) tekintetében)
- leggyakoribb típus (small - medium - large tekintetében)
- átlagos tésztavastagság lefele kerekítve
- összes feltét száma
- legmagasabb ár
- legalacsonyabb ár
- átlagos ár

Ezeket az adatokat 1 db xml fájlba írja ki `_stat.xml` néven. Ahol ár szerepel, ott attribútumban jelölje meg, hogy "HUF"-ról van szó. A leggyakoribb típusok esetén szintén attribútummal jelölje, hogy "base"-ről vagy "type"-ról van szó.

Ugyan ezeket kérje le a VIP pizzák esetén is, és írja ki a `_statVIP.xml` állományba. Minden jelölést az előzőeknek megfelelően ejtsen meg.

## Feladat 8.
A 7. feladatban meghatározott értékeknek hozzon létre egy CodeFirst elvű EFCore adatbázist. Az `OnModelCreating` metódustól el lehet most tekinteni. A feladat az, hogy akár a már kiírt xml-ből, akár a meglévő objektumból az adatok kerüljenek elmentésre az adatbázisba. A szükséges entitás / model osztályt is hozza létre ennek megfelelően.

## Feladat 9.
Hozzon létre egy `Func` delegáltat amely két string bemenetet kap bemenetnek amelyek a `_stat.xml` és `_statVIP.xml` fájlokra mutatnak és kimenetnek egy `Dictionary<string,double>`-t ad vissza. Az utóbbi adatszerkezetbe a következő értékeket kell meghatározni az xml állományok beolvasásával és feldolgozásával:
- átlagos ár
- átlagos legmagasabb ár
- átlagos legalacsonyabb ár

Ezek kiszámolásához tehát a két kategóriában már előzőleg külön-külön meghatározott érték átlagát kell venni.

## Feladat 10.
Készítsen egy `Predicate` delegáltat amely egy double értéket kap bemenetnek és meghatározza, hogy az adott érték prím szám-e avagy sem.

Használja fel ezt a delegáltat a 9. feladatban létrehozott dictionary levizsgálására (TKey, TValue esetén az utóbbi fog kelleni).

## Feladat 11.
A már létező Dictionary típusnak reflexió segítségével kérje le a típusát és írja ki a konzolra a metódusait. (Ezeket kellene látni: [link](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netcore-3.1#methods)) Reflexió segítségével hívja meg a `Clear` metódust, és ellenőrizze, hogy törlődett-e az adatszerkezet.

## Feladat 12.
Az egyes részfeladatokat a `Main` részből tesztelje.

## Feladat 13.
Szusszanjunk. 👌😊

<br>
<br>

---

<br>
<br>

**Ha bármilyen problémát / elírást észlelnétek, kérlek jelezzétek emailben és javítom a doksit! Köszönöm.**

<br>

**Sipos Miklós**\
sipos.miklos@nik.uni-obuda.hu\
https://users.nik.uni-obuda.hu/siposm