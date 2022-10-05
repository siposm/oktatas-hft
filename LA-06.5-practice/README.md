# Gyakorló Zárthelyi Dolgozat

<br>
<br>

A feladat megoldása során a tanult elveket, szintaktikákat javasolt alkalmazni.

A feladatban felhasználandó állomány: [book-database.xml](https://users.nik.uni-obuda.hu/siposm/db/book-database.xml)

Figyelem! Jelen feladathoz megoldás (kód) nincs.

<br>
<br>

## Feladat 1.
Hozzon létre egy **ASP.NET Core Web API** projektet, amelyben hozzon létre egy `BookController` nevű osztályt.

Hozzon létre egy code-first megközelítés szerinti in-memory típusú adatbázist `BookDbContext` néven. Töltse fel az adatbázist seed adatokkal, melyeket dolgozzon fel a fentebbi xml állományból. A szükséges `Book` osztályt is hozza létre. Az xml feldolgozása folyamán a könyv azonosítóját módosítsa, csak a szám értékre van szükségünk, a `bk` előtagot távolítsa el. Például `<book id="bk101">` esetén az azonosító ne `bk101` legyen, hanem csak `101`.

A controllerben hozza létre az adatbázis példányt, ezen keresztül dolgozzon.

## Feladat 2.
A controller osztályon keresztül hozza létre az alábbi alapvető CRUD végpontokat, a hozzájuk megfelelő HTTP metódusokkal társítva:

- `GetAllBooks`: visszaadja az összes könyvet
- `GetBookById`: visszaad egy adott azonosítóval rendelkező könyvet
- `AddBook`: új könyv hozzáadása
- `UpdateBook`: meglévő könyv módosítása
- `DeleteBook`: meglévő könyv törlése
- `DeleteBookById`: meglévő könyv törlése azonosító alapján

## Feladat 3.
A controller osztályon keresztül hozza létre az alábbi végpontokat, a hozzájuk megfelelő HTTP metódusokkal társítva. A szűréseket/legkérdezéseket LINQ segítségével valósítsa meg.

- `GetBooksByAuthor`: a paraméternek átadott szerző alapján leválogatja a könyveket
- `GetCheapestBook`: a legolcsóbb könyvet visszaadja
- `GetMostExpensiveBook`: a legdrágább könyvet visszaadja
- `GetMostFrequentGenreBooks`: a legpopulárisabb műfajú (genre) könyveket adja vissza
- `GetOldestBook`: a legrégebben kiadott könyvet adja vissza (több esetén ABC sorrendben az elsőt, cím szerint)
- `GetLongestDescriptionBook`: a leghosszabb leírással rendelkező könyvet adja vissza
- `GetAuthorsSecondName`: a szerzők második nevét adja vissza
- `GetAvgPricePerYears`: az azonos évben kiadott könyvek átlagos árát adja vissza
- `GetBooksBelowPriceLimit`: határozza meg a legdrágább könyv árának 70%-át, és az árban ez alatt elérhető könyveket adja vissza ár szerint csökkenő sorrendben
- `GetSurroundingBooks`: a megadott azonosítóval rendelkező könyv szomszédait (előtte és utána lévő elem) adja vissza
    - csak a szerző neve és a könyv címe kell, valamint a kiadás éve nap/hónap/év formában
    - ehhez hozzon létre saját DTO osztályt `BookDTO` néven

## Feladat 4.
A megvalósított végpontokat Swagger-ből vagy Postman-ből tesztelje.