# Workshop 03 - Reflexió

    Sipos Miklós - 2024

## Inicializálás

A következő megadott végpontról töltse le és dolgozza fel az elemeket egy listába.

<https://nik.siposm.hu/db/developers.json>

## Attribútumok létrehozása

Hozza létre az alábbi attribútumokat és állítsa be, hogy csak tulajdonságokra lehessen rátenni őket. Adjon meg tetszőleges értékeket a lentebb leírtak alapján.

- `SalaryValidation`
- `SkillsValidation`

## Objektumok validálása

Hozzon létre egy `ObjectValidation` osztályt, amelynek legyen egy logikai visszatérési értékű `Validate` metódusa. A metódus feladata, hogy egy darab objektumot megkapva (ez lesz majd egy Developer) megvizsgálja reflexió segítségével az objektum tulajdonságait, és ha a tulajdonságon talál SalaryValidation vagy SkillsValidation attribútumot, akkor az abban foglaltak alapján levalidálja (ellenőrzi), hogy eleget tesznek-e a feltételeknek.

`SalaryValidation`: lehessen megadni egy minimum limitet az attribútum elhelyezésekor. Ezt ellenőrizve összehasonlítható, hogy a limit felett vagy alatt van adott developer fizetése. Ha felette van, akkor rendben van.

`SkillsValidation`: lehessen megadni egy minimum darabszámot az attribútum elhelyezésekor. Ezt ellenőrzive, ha nem éri el a fejlesztő skilljeinek száma ezt a mennyiséget, akkor még alulképzett és nincs rendben.

## Objektumok exportálása

Készítsen egy `Exporter` osztályt, amelynek legyen egy generikus `Export` metódusa. A metódus egy listát kap pl. Developer objektumokból, de bármi más is lehetne (ezért generikus!). A metódus dolgozza fel a lista elemeit, validálja azokat a fentebb leírt validáló osztály segítségével. Amennyiben valid (azaz megfelelő) az objektum, akkor exportálható XML-be.

Exportáláskor az alábbi kimeneti formát kövesse, ahol látható, hogy a validáció eredménye a salary és skills esetén megjelenik.

```xml
<Developer>
    <Name>John Doe</Name>
    <Role>Fejlesztő</Role>
    <Salary valid="false">5000</Salary>
    <Email>john.doe@example.com</Email>
    <Skills valid="true">
        <Skill>JavaScript</Skill>
        <Skill>HTML</Skill>
        <Skill>CSS</Skill>
        <Skill>Angular</Skill>
        <Skill>Sass CSS</Skill>
    </Skills>
</Developer>
```
