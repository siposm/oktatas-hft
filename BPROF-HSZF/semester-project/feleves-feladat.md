# Féléves Feladat

```txt
Sipos Miklós - 2024
```

## Feladatleírás

Megbízást kap egy cégtől, amely egy új rendszert szeretne fejleszteni a régi helyett. Ennek egy részeként, az új rendszerben egy C# konzolos alkalmazásra van szükség, amely alapvetően adatbázisban eltárolt adatokból képes lekérdezéseket, szűréseket, statisztikákat és egyéb számításokat végezni, megjeleníteni. Mivel az új rendszerben alapból nincsenek adatok, ezért a rendszer legyen képes (többek között) a régi rendszerből adatokat beimportálni.

## Kódszervezéssel kapcsolatos elvárások

A megrendelő elvárása, hogy a szoftver miután elkészült a későbbiekben más fejlesztők által karbantartható és továbbfejleszthető legyen. Ennek érdekében alkalmazzon megfelelő rétegzési elveket és használjon jól szeparált osztályokat, interfészeket, és használjon Git verziókövetést a teljes kódbázison.

Hozzon létre egy saját privát repository-t, melybe első lépésként a `.gitignore` fájlt vigye fel, [C#-ra vonatkozó szabályokkal](https://github.com/github/gitignore/blob/main/VisualStudio.gitignore).
Továbbá, a kód fejlődését megfelelően gyakran, szem előtt tartva a "commit small, commit often" elvet kövesse és commitolja a kódot az idő előrehaladtával. Multibranch technika használata nem szükséges, elegendő csak a `master` branch-re dolgozni.

## Alkalmazás menü

Az alkalmazásban legyen lehetőség egy kezdőmenüben lépkedve választani a különböző lehetőségek közül:

- Adat import (XML)
- Adat import (WEB JSON)
- Adat export
- CRUD
- Grafikon
- Lekérdezések
  - Lekérdezés #1
  - Lekérdezés #2
  - ...
  - Lekérdezés #n
- Kilépés

Az egyes menüelemeket kiválasztva a nekik megfelelő művelet hajtódjon végre, az alábbiakban található részletes leírásoknak megfelelően. Ehhez használhat valamilyen kész módszert (pl. [ConsoleMenu-simple](https://www.nuget.org/packages/ConsoleMenu-simple)), vagy saját megvalósítást is.

## Adat import (XML)

Egy régi rendszerből kiexportált adatokat szeretnénk az új rendszerbe betölteni. Ezeket az adatokat egy xml fájlban kapjuk meg, amely [itt érhető el](./employees-departments.xml). Legyen lehetőség ebből a lokális XML fájlból adatot betölteni a rendszerbe. Ezt úgy oldja meg, hogy dolgozza fel az állományt, állítson elő objektumokat, majd az objektumokat mentse el az adatbázisba. Figyeljen arra, hogy az juttatások értéke nem minden esetben HUF-ban, hanem EUR-ban van kifejezve. Ekkor, a feldolgozáskor számolja át ezt HUF-ra és úgy mentse el.

## Adat import (WEB JSON)

Szintén hasonló a feladat, viszont a régi rendszer másik almoduljában található adatokat JSON formában tudjuk megkapni, amiket webről is elérhetünk. Készítsen az alkalmazásban egy olyan részt, amely egy webes végpontról letölti ezeket az elemeket, feldolgozza őket majd szintén elmenti adatbázisba őket. A webes végpont itt érhető el: [https://nik.siposm.hu/db/managers.json](https://nik.siposm.hu/db/managers.json)

## Adat export

A megírt osztályokat különböző auditálási feladat miatt dokumentálni kell. Ehhez szeretnénk a meglévő osztályok struktúráját kimenteni. Reflexió segítségével dolgozza fel azokat az osztályokat a kódbázisban, amelyeken található egy `ToExportAttribute` attribútum. Az export kimeneteként egy xml fájlt kell kapnunk a lentebbi minta* struktúrának megfelelően. Legyen lehetőség bizonyos tulajdonságokat és metódusokat elrejteni az exportálásban, egy rájuk helyezett, `HideFromExportAttribute` nevű attribútum segítségével. Ha ilyen attr. van egy tulajdonságon vagy metóduson, akkor ezeket hagyja figyelmen kívül az exportálási algoritmus.

**minta: a feladat megvalósításának függvényében természetesen ez változhat / bővülhet új tulajdonságokkal, metódusokkal stb.*

```xml
<?xml version="1.0" encoding="utf-8"?>
<entities exportDate="2024.09.30. 12:13:30">
  <entity hash="1223546760">
    <type>Employee</type>
    <namespace>employee_manager_system</namespace>
    <properties count="4">
      <property>System.String Name</property>
      <property>Int32 Age</property>
      <property>Boolean FullTime</property>
      <property>Boolean HasDegree</property>
    </properties>
    <methods count="3">
      <method>
        <returnType>Boolean</returnType>
        <name>Promote</name>
      </method>
      <method>
        <returnType>Int32</returnType>
        <name>GetYearsOfService</name>
      </method>
      <method>
        <returnType>Double</returnType>
        <name>CalculateAnnualSalary</name>
        <parameters>
          <param>Int32 taxValue</param>
          <param>Boolean fullTime</param>
        </parameters>
      </method>
    </methods>
  </entity>
</entities>
```

Magyarázat az xml-hez:

- A gyökérelem mellett jelenjen meg attribútum segítségével, hogy mikor történt az exportálás.
- Az egyes entitásokhoz legyen attribútummal elhelyezve valamilyen egyedi hash érték.
- Az egyes entitásokban legyen kifejtve, hogy
  - milyen típusról van szó,
  - melyik névtérből származik,
  - hány tulajdonsága van és melyek azok (visszatérési értékekkel),
  - hány metódusa van és melyek azok (visszatérési értékekkel és bemeneti paraméterekkel, ha van).

## CRUD

Hozzon létre egy konzolos felületet amin keresztül a megfelelő entitásokat CRUD műveleteken keresztül tudjuk kezelni. Új elemek létrehozása, meglévő elemek törlése, módosítása és társai.

## Grafikon

Készítsen egy konzolos oszlopdiagramot, amelyben az alkalmazottak nevei és fizetésük jelenjen meg grafikusan, a könnyű átláthatóság érdekében. Fontos, hogy az oszlopok elejei egyvonalban kezdődjenek, egyéb esetben nem lesz vizuálisan jól összehasonlítható az eredmény. A felhasznált karakter szabadon megválasztható, ez a [mintán látott](https://www.compart.com/en/unicode/U+2588).

Egy lehetséges minta:

``` txt
Kovács István ████████████ 750,000 HUF
Nagy Anna     ████████ 650,000 HUF
Szabó Dávid   ███████████ 780,000 HUF
Horváth Ádám  ███████ 620,000 HUF
Tóth László   █████████████████ 850,000 HUF
Kiss Mária    ██████ 600,000 HUF
```

## Lekérdezések

A lekérdezések egyesével jelenjenek meg a menüben mint választható opciók.

Valósítsa meg a következő lekérdezéseket:

- **Vezető lekérdezések**
  - Hány doktori címmel rendelkező vezető (manager) van?
  - Van-e olyan (és ha igen ki/kik) akik doktori címmel rendelkeznek, de MBA (Master of Business Administration) végzettségük nincs?
  - Ki a legrégebb óta munkában lévő vezető?
  - Melyik az a vezető, aki az élt éveihez képest a legtöbb ideje dolgozik a cégnél?
  - Mi a vezetők közötti arány, hány embernek van MBA végzettsége, szemben azokkal akiknek nincs?
- **Alkalmazott lekérdezések**
  - Hány alkalmazott van, akik a 80-as években születtek?
  - Hány alkalmazott van, akik legalább két részlegen dolgoznak?
  - Melyik alkalmazottak azok akik jelenleg nyugdíjba mentek de mégis dolgoznak?
  - Hány alkalmazott van akik nyugdíjba mentek és ennek megfelelően nem dolgoznak?
  - Mennyit keresnek átlagosan azok, akik már nyugdíjba mentek?
  - Keresetük alapján (jutalékot is beleértve) csökkenő sorrendben kik dolgoznak itt?
  - Tudásszintjük alapján (junior, medior, senior) a dolgozók milyen összetételben dolgoznak a cégnél (100% az összes dolgozó)?
  - Melyek azok a dolgozók, akik olyan részleghez tartoznak ahol van doktori címmel rendelkező részlegvezető?
  - Hány olyan dolgozó van, akiknek a fizetése meghaladja az átlagos fizetési szintet; illetve hány van akik ez alatt keresnek (a jutalékot nem számolva)?
  - Mi az átlagfizetés (jutalékot nem nézve) az egyes szintekben?
  - Ki keres többet a jelenlegi dolgozók közül: aki medior szinten átlagfizetést kap vagy egy junior aki a legmagasabb fizetést kapja?
  - Melyik kategóriában (junior, medior, senior) a legtöbb a jutalék mértéke?
  - Melyik alkalmazott az, aki az itt töltött éveihez képest a legkevesebb projekten dolgozott?
  - Születési sorrendben ki mennyit keres?
  - A jelenleg aktív státuszban itt dolgozó alkalmazottak közül ki dolgozott a legkevesebb projekten?
  - Van-e olyan eset, ahol egy dolgozónak a jutaléka nagyobb, mint egy másik dolgozó alap fizetése? Ha igen, melyik kié?
- **Vegyes lekérdezések**
  - Ki dolgozik a legrégebb óta a cégnél? Vezetők és alkalmazottakat közösen nézve.
  - Van-e olyan manager aki egyben részlegvezető is? Ha igen, ki az?
  - Kik azok, akik vagy csak részlegvezetők, vagy csak manager-ek?

## Kilépés

A programot úgy írja meg, hogy csak akkor záródjon be, ha a kilépés opciót választja a felhasználó. Egyéb esetben, pl. egy lekérdezés eredményeinek a kiírása után várjon egy enter leütést, minek hatására térjen vissza a főmenübe.
