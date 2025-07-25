# DungeonRPG

# 🎮 Konzolos RPG gyakorlóprojekt – Fejlesztési szakaszok

Ez a projekt egy egyszerű, szöveges RPG játék, amelyben a játékos karakter szörnyekkel harcol, fejlődik, tárgyakat gyűjt, és célja, hogy elérje a 20. szintet. A játék gyakorló célból készült, hogy segítsen a kezdőknek megérteni az **objektumorientált programozás**, a **tulajdonságok**, **konstruktorok**, és az **objektumok közötti interakciók** alapjait.

---

## ✅ Előkészületek


### 🧱 Projekt struktúra és névterek

Három különálló projektet használunk a megvalósításhoz:

| Projekt neve               | Feladata                                                                 | Névterek            |
|----------------------------|--------------------------------------------------------------------------|---------------------|
| `DungeonRPG.Entities`       | Adatmodellek: Játékos, Szörny, Tárgy osztályok                          | `DungeonRPG.Entities`|
| `DungeonRPG.Services`       | Játéklogika kezelése, harc, szörny generálás                            | `DungeonRPG.Services`|
| `DungeonRPG.ConsoleApp`     | Konzol alkalmazás, felhasználói input és output                         | `DungeonRPG.ConsoleApp`|

---

### ❓ Miért érdemes így felosztani a projekteket?

Ez a felosztás elősegíti, hogy:

- **A logika (services)** és az **adatok (entities)** ne függjenek a megjelenítéstől (console), így **könnyebben portolható** lesz más platformokra is (pl. web, mobil).
- Könnyebb lesz bővíteni a kódot, mivel a **játéklogika** és az **adatok kezelése** elkülönülnek.
- A **konszol alkalmazás** csak az **input** és **output** kezelésére koncentrál, így a játék működése nem függ a felhasználói felülettől.

---


### Projektfüggőségek

- `Services` hivatkozik az `Entities` projektre
- `ConsoleApp` hivatkozik a `Services` és `Entities` projektekre
- **A `Services` és `Entities` nem hivatkozhat a `ConsoleApp`-ra!**

---

## 📌 1. szakasz – Karakter és Szörny osztály

### Cél:
- Megismerkedni az osztályokkal, tulajdonságokkal, konstruktorral
- Létrehozni egy karaktert és egy szörnyet

### Feladatok:
- [ ] `Karakter` osztály elkészítése
- [ ] `Szorny` osztály elkészítése
- [ ] Tesztelés konzolból (kiírás a tulajdonságokról)

---

## 📌 2. szakasz – HarcService: karakter vs. szörny

### Cél:
- Interakció két objektum között
- Harcmodell kialakítása (szörny támad először)

### Feladatok:
- [ ] `HarcService` osztály a `Services` projektben
- [ ] `Tamad()` és `Vedekezik()` metódusok
- [ ] Konzolos harc szimuláció

---

## 📌 3. szakasz – Tárgyak és Inventory

### Cél:
- Kollekciók használata (lista)
- Inventory kezelése, tárgy hozzáadás, levonás

### Feladatok:
- [ ] `Targy` ősosztály, és gyermekosztályok (Pl. Kard, Ital stb.)
- [ ] `Karakter.Inventory` lista
- [ ] Tárgy hozzáadása és kiírása

---

## 📌 4. szakasz – Gyógyítás és különleges tárgyak

### Cél:
- Feltételek kezelése (pl. van-e ital)
- Különleges hatások (pl. bénítás)

### Feladatok:
- [ ] `Gyogyital` tárgy, `BenulasItal` tárgy
- [ ] `HasznalTargy()` metódus a karakterhez
- [ ] Konzolos teszt: ital használata harc közben

---

## 📌 5. szakasz – Dungeon rendszer és fejlődés

### Cél:
- Szintlépés és tapasztalati rendszer
- Véletlenszerű szörnygenerálás dungeon szerint

### Feladatok:
- [ ] `DungeonService` létrehozása
- [ ] Szörnyek generálása szint alapján
- [ ] Tapasztalatszerzés és szintlépés logikája

---

## 📌 6. szakasz – Tárgydobás és véletlen logika

### Cél:
- Véletlenszerű tárgydobás implementálása
- Tárgyak esély alapú megszerzése

### Feladatok:
- [ ] Szörny legyőzése után tárgy esélyek
- [ ] Tárgyhozzárendelés a karakter inventory-hoz

---

## 📌 7. szakasz – Játékciklus és győzelem

### Cél:
- Teljes játéklogika kialakítása
- Fő cél: elérni a 20. szintet

### Feladatok:
- [ ] Játék főciklusa (harc, loot, fejlődés)
- [ ] Játék vége: „Gratulálok! Elérted a 20. szintet.”

---

## 🧪 Extra gyakorlófeladatok (opcionális)

- [ ] Hibakezelés (mi van, ha nincs ital a használathoz?)
- [ ] Egységteszt alapjai a Services metódusokra
- [ ] További szörnytípusok (speciális képességekkel)

---

## 📘 További lehetőségek (haladóknak)

- Webes vagy mobilos felület hozzáadása
- Mentés/betöltés (fájlkezelés)
- JSON-alapú adatkonfiguráció

---



---------------------------------------------------------- 

Részletes leírások:

📌 1. szakasz – Karakter és Szörny osztály

🎯 Cél:
- Megismerkedni az osztályokkal (class)
- Megérteni, mi az a property, field és konstruktor
- Megtanulni, hogyan hozzunk létre példányokat (object-eket) egy osztályból
- Létrehozni egy karaktert és egy szörnyet, majd ezeket kipróbálni konzolból

─────────────────────────────

🧩 Fogalmi magyarázatok:

🔹 Mi az osztály (class)?
Az osztály egy sablon, ami alapján objektumokat hozunk létre. Olyan, mint egy tervrajz.

🔹 Mi a property?
Olyan, mint egy mező, de hozzáférési szabályozással:
Például:
    public int Eletero { get; private set; }

Ez azt jelenti, hogy kívülről le lehet kérdezni az "Eletero" értéket,
de módosítani csak az osztályon belül lehet.

🔹 Mi a konstruktor?
Egy speciális metódus, ami akkor fut le, amikor létrehozol egy új példányt.
Például:
    var jatekos = new Karakter("Béla");

Ehhez a Karakter osztályban kell egy ilyen konstruktor:
    public Karakter(string nev)
    {
        Nev = nev;
        // stb...
    }

─────────────────────────────

🧪 FELADATOK:

📁 A. FÁJL LÉTREHOZÁSA RIDERBEN:
1. Kattints jobb gombbal a DungeonRPG.Entities projektre
2. Válaszd: Add → New File
3. Fájl neve: Karakter.cs

📁 Ugyanezt tedd meg a Szorny.cs fájlra is

─────────────────────────────

🧱 B. Karakter osztály létrehozása

Feladatod, hogy létrehozz egy Karakter nevű osztályt a következő tulajdonságokkal:

- Nev (string)
- Eletero (int)
- MaxEletero (int)
- SebzesErtek (int)

Milyen típusokat használsz és miért? Gondold át!

➕ TIPP:
Használj PROPERTY-ket (nem sima mezőket)!
Pl:

    public int SebzesErtek { get; private set; }

─────────────────────────────

🏗 C. Konstruktor írása

A konstruktorban add meg az alábbi kezdőértékeket:

- A nevet paraméterként kapja
- MaxEletero = 100
- Eletero = MaxEletero
- SebzesErtek = 10

❓ Miért kell a MaxEletero és Eletero külön? Gondolkozz!
(Pl. meggyógyítható legyen, de ne menjen túl a maximumon)

─────────────────────────────

🧟 D. Szorny osztály

A Szorny osztály lehet hasonló a Karakterhez, de lehet benne különbség:

- Nev (string)
- Eletero (int)
- MaxEletero (int)
- SebzesErtek (int)

➕ Gondold végig: kell-e különbség a játékos és a szörny között?
Pl. lesznek később speciális képességek?

─────────────────────────────

🖥 E. Tesztelés konzolból

1. Lépj át a DungeonRPG.ConsoleApp projektbe
2. A Program.cs-ben próbáld ki az alábbiakat:

- Hozz létre egy karaktert:

    var jatekos = new Karakter("Teszt Elek");

- Hozz létre egy szörnyet:

    var szorny = new Szorny("Gonosz Kobold");

- Írasd ki a tulajdonságaikat:

    Console.WriteLine($"Játékos: {jatekos.Nev}, Életerő: {jatekos.Eletero}/{jatekos.MaxEletero}");
    Console.WriteLine($"Szörny: {szorny.Nev}, Életerő: {szorny.Eletero}/{szorny.MaxEletero}");

─────────────────────────────

🧠 GONDOLKOZTATÓ KÉRDÉSEK:

1. Milyen adatokat engednél kívülről is módosítani, és melyeket nem?
2. Hogyan védenéd az osztály belső állapotát?
3. Mi történne, ha egy karakter Eletero értéke 0 alá csökkenne?
4. Hogyan gyógyítanád vissza a karaktert?

─────────────────────────────

✅ HA KÉSZ VAGY:
Készítsd el a következő osztályokat: Karakter, Szorny, és teszteld őket
A végén írhatod ki az eredményeket a konzolra
De figyelj rá: csak a ConsoleApp projektben lehet Console.WriteLine()!

─────────────────────────────

📦 Várható eredmény (csak ha már próbálkoztál magadtól):

Játékos: Teszt Elek, Életerő: 100/100
Szörny: Gonosz Kobold, Életerő: 60/60

─────────────────────────────

💬 Ha nem sikerült, ne csüggedj! Próbálj rájönni, hol a hiba,
és kérdezz vissza, ha valamit nem értesz.

A következő szakaszban már harci metódusokat is írunk!

----------------------------------------------------------

📌 2. szakasz – HarcService: karakter vs. szörny

🎯 Cél:
- Megtanulni, hogyan „dolgoznak együtt” különböző objektumok
- Kialakítani a harc szabályait: a szörny mindig először támad
- A programlogikát külön szolgáltatásba szervezni (Services réteg)

─────────────────────────────

🧩 Fogalmi magyarázat:

🔸 Mi az a „service”?
A szolgáltatási réteg (service) olyan osztályokat tartalmaz, amelyek elvégzik a „működést”, például egy harcot lebonyolítanak, de NEM írnak ki semmit a konzolra, és nem is kérnek be adatot!

🔸 Mi az interakció?
Amikor két objektum „hatással van egymásra”. Például:
- A Szörny megsebzi a Játékost
- A Játékos visszaüt

🔸 Miért fontos a sorrend?
A harc során először mindig a szörny támad, hogy a játék ne legyen túl könnyű.
Ez logikailag fontos: ne keverjük meg a sorrendet!

─────────────────────────────

📁 A. FÁJL LÉTREHOZÁSA A SERVICES PROJEKTBEN:

1. Rider bal oldalán keresd meg a DungeonRPG.Services projektet
2. Kattints rá jobb gombbal → Add → New File
3. Fájlnév: HarcService.cs
4. Namespace: DungeonRPG.Services

─────────────────────────────

🧪 B. FELADAT: HarcService osztály létrehozása

Kezdj egy alap class sablonnal:

    namespace DungeonRPG.Services
    {
        public class HarcService
        {
            // ide fognak jönni a metódusok
        }
    }

─────────────────────────────

⚔️ C. Metódus: Tamad()

🎯 Cél: Egyik karakter (például a Szörny) támadja meg a másikat (például a Játékost)

❓ Először gondold végig:
- Milyen adatra van szükség a támadáshoz?
- Honnan tudjuk, mennyit kell sebezni?
- Hogyan csökkentjük a célpont életerejét?

📝 TIPP: A Jatekos és Szorny osztályban már lehet egy `SebzestKap(int mennyiseg)` metódusod

➕ A Tamad() metódus így nézhet ki (de NE másold egyből! Gondolkodj!):

    public void Tamad(Karakter tamado, Karakter celpont)
    {
        int sebzes = tamado.SebzesErtek;
        celpont.SebzestKap(sebzes);
    }

❗ Fontos: A HarcService NEM írhat ki semmit a konzolra!

─────────────────────────────

🛡️ D. Metódus: Vedekezik()

🎯 Cél: A játékos vagy a szörny védekezik, így kevesebb sebzést kap

❓ Gondold végig:
- Mennyi sebzést csökkentsen a védekezés? (Pl. 50%-kal?)
- Hol történjen a csökkentés? A HarcService-ben vagy a karakter osztályban?

📝 TIPP:
Hozz létre egy Vedekezik() metódust a HarcService-ben, ami egy sebzés értékből kiszámolja a „csökkentett” sebzést, és azt alkalmazza a célpontra.

Például:
    public void Vedekezik(Karakter vedekezo, Karakter tamado)
    {
        int eredetiSebzes = tamado.SebzesErtek;
        int csokkentettSebzes = eredetiSebzes / 2;
        vedekezo.SebzestKap(csokkentettSebzes);
    }

➕ TIPP: Később ezt is testreszabhatod pajzs vagy képességek alapján!

─────────────────────────────

🧠 GONDOLKOZTATÓ KÉRDÉSEK:

1. Ki „tud” sebzést kapni? Hol kell ennek történnie? (Karakter/Szorny osztályban?)
2. Mi történik, ha a célpont életereje 0 alá csökken? Kell külön "halott" állapot?
3. Miben különbözik egy sima támadás egy védekező támadástól?
4. Szükséges-e visszaadni valamilyen eredményt (pl. hogy mennyit sebzett)?

─────────────────────────────

🖥️ E. Konzolos tesztelés

1. Menj át a DungeonRPG.ConsoleApp projektbe
2. A Program.cs fájlban próbáld ki:

- Hozz létre egy Jatekos-t és egy Szorny-et
- Példányosítsd a HarcService-t
- Hívd meg a Tamad() vagy Vedekezik() metódust

Pl. (csak ha már kitaláltad a működést):

    var harc = new HarcService();
    harc.Tamad(szorny, jatekos); // szörny támad
    harc.Tamad(jatekos, szorny); // játékos visszaüt

    Console.WriteLine($"Játékos: {jatekos.Eletero}");
    Console.WriteLine($"Szörny: {szorny.Eletero}");

─────────────────────────────

✅ EXTRA: Hibakezelés

➕ Gondolkodj el rajta: mi történjen, ha már halott valaki? Meg lehet még támadni?
➕ Milyen logikai feltételeket tudnál bevezetni, hogy ne támadhasson halott karakter?

─────────────────────────────

🧠 Összefoglaló:

- A HarcService nem tud semmit a konzolról!
- Csak a logikát tartalmazza (sebzés, védekezés, stb.)
- A Jatekos és Szorny osztályok felelősek az állapotukért
- A ConsoleApp hívja meg a logikát és írja ki az eredményt



----------------------------------------------

📌 3. szakasz – Tárgyak és Inventory kezelés

🎯 Cél:
- Megismerni és használni a kollekciókat (Listák)
- Inventory rendszer kialakítása a karakterekhez
- Egyszerű öröklődés és polimorfizmus bevezetése

─────────────────────────────

🧩 Fogalmi magyarázat:

🔸 Mi az a kollekció?
Egy olyan típus, ami több elemet tud tárolni. Például:
  - List<string> nevek = new List<string>();
  - List<Targy> inventory = new List<Targy>();

🔸 Miért kell Inventory?
A karaktereknek legyenek tárgyaik, amiket használhatnak, tárolhatnak, vagy eldobhatnak. Az inventory ezt a funkciót valósítja meg.

🔸 Mi az öröklődés?
Egy osztály (pl. Kard) örökölhet egy másik osztályból (pl. Targy). Ez azt jelenti, hogy automatikusan megkapja az alap osztály mezőit és metódusait.

─────────────────────────────

📁 A. FÁJLOK LÉTREHOZÁSA:

1. Menj a DungeonRPG.Entities projekthez a Rider-ben
2. Hozd létre az alábbi fájlokat:
    - Targy.cs
    - Kard.cs
    - Ital.cs

3. Később: módosítsd a Jatekos.cs fájlt, hogy tartalmazzon egy `Inventory` listát

─────────────────────────────

🛠️ B. Targy (ősosztály) létrehozása

📌 Gondold végig:
- Minden tárgynak van egy neve
- Talán van leírása, értéke is

💡 TIPP: A `Targy` osztály legyen `abstract`, mert önmagában nem szeretnénk példányosítani

Példa (csak vázlat):

    public abstract class Targy
    {
        public string Nev { get; protected set; }

        public Targy(string nev)
        {
            Nev = nev;
        }

        public abstract void Hasznal(Karakter celpont);
    }

🧠 KÉRDÉSEK:
- Miért érdemes `abstract`-ként írni?
- Mit jelent az, hogy a `Hasznal()` metódus is abstract?

─────────────────────────────

⚔️ C. Leszármazott osztály: Kard

📌 Ez egy támadó tárgy, ami megnöveli a karakter sebzését

Gondold végig:
- Mennyi sebzést adjon hozzá?
- Hol történjen a növelés? A Kardban, vagy a Karakter osztályban?

Példa:

    public class Kard : Targy
    {
        public int PluszSebzes { get; }

        public Kard(string nev, int pluszSebzes) : base(nev)
        {
            PluszSebzes = pluszSebzes;
        }

        public override void Hasznal(Karakter celpont)
        {
            celpont.NoveliSebzesErteket(PluszSebzes);
        }
    }

🧠 KÉRDÉS:
- Milyen hatása legyen a kardnak? Ideiglenes vagy végleges legyen?

─────────────────────────────

🧪 D. Leszármazott osztály: Ital

📌 Ez egy gyógyító tárgy, ami visszaad életerőt

Gondold végig:
- Mennyi életerőt töltsön vissza?
- Lehet-e többféle ital (pl. gyógyító, bénító)?

Példa:

    public class Ital : Targy
    {
        public int GyogyitasMennyisege { get; }

        public Ital(string nev, int gyogyitas) : base(nev)
        {
            GyogyitasMennyisege = gyogyitas;
        }

        public override void Hasznal(Karakter celpont)
        {
            celpont.Gyogyit(GyogyitasMennyisege);
        }
    }

─────────────────────────────

🎒 E. Inventory lista létrehozása

Menj a `Jatekos` (vagy Karakter) osztályba, és adj hozzá egy listát:

    public List<Targy> Inventory { get; }

    public Jatekos(string nev)
    {
        Inventory = new List<Targy>();
        // többi alapérték...
    }

📌 Fontos: csak a Karakter tudja módosítani az inventoryt, ne kívülről módosítsd

─────────────────────────────

➕ F. Tárgy hozzáadása és használata

❓ Gondold végig:
- Hogyan adod hozzá a tárgyat?
- Ki dönti el, mikor használják?

Adj metódusokat a karakterhez:

    public void HozzaadTargy(Targy targy)
    {
        Inventory.Add(targy);
    }

    public void HasznaljaTargyat(int index)
    {
        if (index < 0 || index >= Inventory.Count)
            return;

        Targy kivalasztott = Inventory[index];
        kivalasztott.Hasznal(this);
        Inventory.RemoveAt(index); // egyszer használható
    }

─────────────────────────────

🧠 GONDOLKOZTATÓ KÉRDÉSEK:

1. Hogyan tudod megjeleníteni a tárgyak nevét konzolon?
2. Lehet-e egy tárgy többféleképpen működő (pl. bénít és gyógyít)?
3. Érdemes-e szétválasztani az egyszer használható és tartós tárgyakat?
4. Hogyan biztosítod, hogy egy tárgy csak akkor legyen használható, ha tényleg van a listában?

─────────────────────────────

🖥️ H. Konzolos tesztelés

A ConsoleApp-ban próbáld ki:

1. Hozz létre 1 játékost
2. Adj hozzá egy kardot és egy italt az inventoryjához
3. Írasd ki a tárgyak listáját
4. Használd fel az első tárgyat
5. Nézd meg, mi történt a játékos állapotával

─────────────────────────────

✅ Összefoglaló:

- Megtanultad a kollekciók (lista) használatát
- Megalkottad az öröklődő tárgy osztályokat
- A karakter most már képes tárgyakat felvenni, kezelni és használni


---------------------------------------------


📌 4. szakasz – Gyógyítás és speciális tárgyak

🎯 Cél:
- Feltételes logika alkalmazása (pl. ha van ital, ha a karakter még él)
- Speciális tárgyak hatásmechanizmusának bevezetése
- Tárgyhasználat gyakorlása harc közben

─────────────────────────────

🧠 Fogalmak és előkészítés:

🔸 Tárgyak továbbfejlesztése
Korábban már létrehoztunk egy alap Targy osztályt, és leszármaztatott osztályokat (pl. Kard, Ital).
Most újabb leszármazottakat készítünk – speciális hatásokkal.

🔸 Feltételes logika
Ez azt jelenti, hogy valamilyen feltétel alapján másképp viselkedik a program:
  - Ha a karakter életereje kevesebb mint a maximum, gyógyítható
  - Ha van BenulasItal, akkor a szörny nem támad
  - stb.

─────────────────────────────

📁 A. FÁJLOK LÉTREHOZÁSA

1. Menj a DungeonRPG.Entities projekthez Rider-ben
2. Hozz létre két új fájlt:
   - Gyogyital.cs
   - BenulasItal.cs

─────────────────────────────

💊 B. Gyogyital létrehozása

📌 Cél: visszatölti a karakter életerejét – de csak ha van mit gyógyítani

🔍 Gondolkodj:
- Mennyi életerőt töltsön vissza?
- Mi történjen, ha már teljes az életerő?

Példaszerű vázlat:

    public class Gyogyital : Targy
    {
        public int GyogyitasMennyisege { get; }

        public Gyogyital(string nev, int gyogyitas) : base(nev)
        {
            GyogyitasMennyisege = gyogyitas;
        }

        public override void Hasznal(Karakter celpont)
        {
            if (celpont.Eletero < celpont.MaxEletero)
            {
                celpont.Gyogyit(GyogyitasMennyisege);
            }
        }
    }

🧠 GONDOLKOZTATÓ KÉRDÉS:
- Hogyan tudod elkerülni, hogy feleslegesen használják el az italt?
- Érdemes-e visszajelzést adni arról, hogy használt-e vagy sem?

─────────────────────────────

🧊 C. BenulasItal létrehozása

📌 Cél: megakadályozza, hogy a célpont támadjon a következő körben

🧠 Itt szükség lehet egy `Benult` állapotra

Példa gondolatmenet:

    public class BenulasItal : Targy
    {
        public BenulasItal(string nev) : base(nev)
        {
        }

        public override void Hasznal(Karakter celpont)
        {
            celpont.Benit();
        }
    }

A Karakter osztályban ehhez létre kell hoznod egy állapotot:

    public bool Benult { get; private set; }

    public void Benit()
    {
        Benult = true;
    }

🧠 KÉRDÉS:
- Hogyan lehet feloldani a bénítást egy kör után?
- Ki felelős a bénítás kezeléséért: a HarcService vagy a Karakter?

─────────────────────────────

🔁 D. HasznalTargy() metódus továbbfejlesztése

A Karakter osztályban már van egy `HasznalTargyat(int index)` metódus.

Most bővítsd úgy, hogy csak akkor engedje használni a tárgyat, ha az valóban használható:
- Gyógyital csak akkor, ha nem teljes az életerő
- BenulasItal csak akkor, ha a célpont még nincs bénítva

📌 TIPP:
A Hasznal() metóduson belül is lehet feltételeket tenni (ahogy a fenti példákban láttad)

─────────────────────────────

🧪 E. Konzolos tesztelés harc közben

📌 Lépések:
1. Hozz létre egy Játékost
2. Adj hozzá egy Gyógyitalt és egy BenulasItalt az inventoryjához
3. Hozz létre egy Szörnyet
4. Indíts el egy harcot (lásd előző szakasz)
5. Harc közben próbálj meg tárgyat használni:
   - Előbb próbálj meggyógyulni
   - Majd bénítsd le a szörnyet

📌 Vizsgáld meg:
- Hogyan változnak a karakterek állapotai?
- Mi történik, ha többször használod ugyanazt a tárgyat?
- Mi van, ha a listában nincs már tárgy?

─────────────────────────────

🧠 GONDOLKOZTATÓ KÉRDÉSEK:

1. Mi történik, ha a karakter bénult? Akkor is támadjon?
2. Hol legyen a felelősség a bénítás időtartamáért? (1 körig tartson?)
3. Hogyan tudod jelezni a játékosnak, ha egy tárgy nem használható?
4. Hogyan lehet majd többféle státusz-hatást kezelni a jövőben (pl. mérgezés, pajzs stb.)?

─────────────────────────────

✅ Összefoglaló:

- Két új tárgy típust hoztál létre – gyógyításra és bénításra
- Feltételes logikát alkalmaztál az osztályokon belül
- Harc közben is tudsz tárgyakat használni
- Megtanultad, hogyan vezess be státusz-effekteket


----------------------------------------------

📌 5. szakasz – Dungeon rendszer és fejlődés

🎯 Cél:
- Tapasztalati pontok (XP) gyűjtése és szintlépés megvalósítása
- Véletlenszerű szörnyek generálása a dungeon szintjének megfelelően
- Új szolgáltatás (DungeonService) létrehozása, amely kezeli a dungeon működését

─────────────────────────────

🧠 Fogalmak:

1. Tapasztalati pont (XP):
   - Minden legyőzött szörny ad XP-t
   - Amikor az XP eléri a következő szinthez szükséges értéket, a karakter szintet lép

2. Szintlépés:
   - A karakter szintje nő, ami általában növeli a tulajdonságait (pl. max életerő, sebzés)
   - Szintlépéskor frissítsd a karakter tulajdonságait és az aktuális életerőt

3. Véletlenszerű szörny generálás:
   - A dungeon szintjének megfelelő szörnyek jelennek meg
   - Szörnyek lehetnek különböző erősségűek és tulajdonságúak

─────────────────────────────

📁 A. FÁJLOK LÉTREHOZÁSA

1. Menj a DungeonRPG.Services projektbe Riderben
2. Hozz létre egy új fájlt: DungeonService.cs

─────────────────────────────

🛠 B. DungeonService osztály megtervezése

Feladat:
- Hozz létre egy osztályt, ami felelős a dungeon működéséért.
- Ebben legyen egy metódus: SzornyGeneralas(int dungeonSzint)
  - Ez egy listából véletlenszerűen kiválaszt egy vagy több szörnyet, akik a dungeon szintjének megfelelőek.

Példa vázlat:

    public class DungeonService
    {
        private Random _random = new Random();

        public Szorny SzornyGeneralas(int dungeonSzint)
        {
            // Szörnyek listája szint alapján
            // Példa: könnyű szörnyek 1-3 szint, közepes 4-7, nehéz 8-10
            // Válassz egyet véletlenszerűen a megfelelők közül

            // return kiválasztott szörny
        }
    }

🧠 KÉRDÉSEK:
- Hogyan tárolod a szörnyeket? Listában, tömbben?
- Mi alapján döntöd el, hogy melyik szörny legyen a megfelelő szintű?
- Hogyan lesz random a választás?

─────────────────────────────

🧮 C. Tapasztalati pontok és szintlépés kezelése a Karakter osztályban

Feladat:
- Adj hozzá két új property-t:
   - int Tapasztalat { get; private set; }
   - int Szint { get; private set; }

- Készíts metódust:
   - void TapasztalatNoveles(int mennyiseg)

Ennek a logikája:
- Ha a Tapasztalat eléri vagy meghaladja a szintlépéshez szükséges értéket (pl. minden szinthez kell 100 XP),
 akkor növeld a Szint értékét, és növeld a karakter erejét, max életerejét stb.

Példa:

    public void TapasztalatNoveles(int mennyiseg)
    {
        Tapasztalat += mennyiseg;
        while (Tapasztalat >= Szint * 100)
        {
            Tapasztalat -= Szint * 100;
            Szint++;
            MaxEletero += 10;
            Eletero = MaxEletero;
            SebzesErtek += 5;
        }
    }

🧠 KÉRDÉSEK:
- Hogyan biztosítod, hogy a Tapasztalat ne legyen negatív?
- Mi történik, ha a karakter több szintet lép egyszerre?
- Hogyan tudod megjeleníteni a szint és XP állapotot a játékosnak?

─────────────────────────────

🧑‍💻 D. Konzolos teszt

1. Hozz létre egy új DungeonService példányt
2. Állítsd be a dungeon szintjét (pl. 1 vagy 2)
3. Generálj egy szörnyet a dungeon szint alapján
4. Hozz létre egy karaktert
5. Simuláld a harcot, adj tapasztalatot a karakternek
6. Ellenőrizd, hogy a karakter szintlép és frissülnek a tulajdonságai

─────────────────────────────

🧠 ÖSSZEGZŐ KÉRDÉSEK:

- Hogyan lehet tovább fejleszteni a DungeonService-t, hogy többféle dungeon legyen?
- Miként lehet a szörnyek nehézségét jobban szabályozni?
- Hogyan kezelnéd a tapasztalati pontokat, ha többféle küldetés lenne?

─────────────────────────────

✅ Ez a szakasz megtanítja neked:

- Szintlépés logikáját
- Véletlenszerű elem kiválasztását listából
- Szolgáltatás (service) osztály létrehozását és használatát


----------------------------------------------

📌 6. szakasz – Tárgydobás és véletlen események

🎯 Cél:
- Megérteni és implementálni a véletlenszerű tárgydobás mechanizmust.
- Esélyek alapján dönteni arról, hogy milyen tárgyat kap a játékos a szörny legyőzése után.
- Tárgyakat hozzáadni a karakter inventory-jához.

─────────────────────────────

🧠 Fogalmak:

1. Véletlenszerűség (Randomness):
   - A játékban gyakran kell dönteni véletlenszerűen, pl. tárgyak esélyeinek kiszámítása.
   - Ehhez használjuk a C# Random osztályát.

2. Tárgy esélyek (Drop Chances):
   - Minden tárgynak megadhatunk egy százalékos esélyt, hogy megjelenjen.
   - Például: Kard 30%, Gyógyital 50%, Ritka ital 10%.

3. Inventory kezelése:
   - A karakter Inventory-ja egy lista, ami tárolja a megszerzett tárgyakat.
   - Új tárgyakat kell hozzáadni, amikor a játékos szerzi őket.

─────────────────────────────

📁 A. Előkészületek – Random példányosítása

1. A DungeonService vagy HarcService osztályban hozz létre egy Random objektumot, pl.:

    private Random _random = new Random();

─────────────────────────────

🛠 B. Tárgyak és esélyek megadása

1. Gondold végig, milyen tárgyak eshetnek ki a szörnyekből.
2. Minden tárgyhoz rendelj egy esély értéket (int vagy double), pl. 30 (30%).
3. Készíts egy metódust, ami véletlenszámot generál (0-99), és az esély alapján eldönti, hogy leesik-e a tárgy.

Példa:

    int dobottSzam = _random.Next(100); // 0 és 99 között
    if (dobottSzam < targyEsely) 
    {
        // tárgy leesik
    }

🧠 KÉRDÉSEK:
- Hogyan tudod a különböző esélyeket egy helyen kezelni?
- Mi történik, ha több tárgy is leeshet egyetlen legyőzéskor?
- Hogyan kezelnéd, hogy egy szörny ritka tárgyat is dobhasson?

─────────────────────────────

🧮 C. Tárgy hozzáadása az inventoryhoz

1. A Karakter osztályban legyen egy lista a tárgyaknak:

    public List<Targy> Inventory { get; private set; }

2. Készíts egy metódust a karakterben:

    public void HozzaadTargy(Targy targy)
    {
        Inventory.Add(targy);
    }

3. Amikor a szörny legyőzése után eldöntöd, hogy leesik-e tárgy, hívd meg ezt a metódust.

─────────────────────────────

🧑‍💻 D. Konzolos teszt

1. Generálj egy szörnyet
2. Szimuláld a harcot
3. A szörny legyőzése után fusson le a tárgy dobás logika
4. Írd ki, milyen tárgy esett ki (ha esett)
5. Nézd meg a karakter Inventory-ját a konzolon

─────────────────────────────

🧠 ÖSSZEGZŐ KÉRDÉSEK:

- Hogyan tehetnéd testreszabhatóvá a tárgydobási esélyeket (pl. nehézségi szint szerint)?
- Milyen adatszerkezet lehet a legjobb az esélyek és tárgyak összekapcsolására?
- Hogyan kezelnéd az inventory maximális kapacitását?

─────────────────────────────

✅ Ez a szakasz megtanít neked:

- Véletlenszám generálás használatát C#-ban
- Esély alapú döntések implementálását
- Gyűjtemény (lista) módosítását és használatát


----------------------------------------------

📌 7. szakasz – Játékciklus és győzelem

🎯 Cél:
- Összerakni a játék fő logikáját, amely ismétlődő harcokból, loot szerzésből és fejlődésből áll.
- Megvalósítani a játék végét, amikor a karakter eléri a 20. szintet.
- Gyakorolni a ciklusok és feltételek használatát a programban.

─────────────────────────────

🧠 Fogalmak:

1. Játékciklus (Game Loop):
   - Ez az a rész, ami újra és újra lefut, amíg a játék nem ér véget.
   - Minden körben lehet harcolni, tárgyakat szerezni, fejlődni.
   - C#-ban ez lehet egy while ciklus, ami addig fut, amíg a karakter szintje kisebb 20-nál.

2. Feltételes elágazás:
   - Ha a karakter eléri a 20. szintet, a ciklust meg kell szakítani, és ki kell írni a győzelmi üzenetet.

3. Metódushívások összekapcsolása:
   - A főciklusban hívjuk meg a HarcService harcát, a DungeonService szörny generálását, és a karakter szintlépését.

─────────────────────────────

📁 A. Játék főciklusának megtervezése

1. Gondold végig, hogyan néz ki egy kör:
   - Új szörny generálása
   - Harc a szörnnyel
   - Ha a karakter nyer, kap tárgyakat, tapasztalatot
   - Ellenőrzés, hogy elérte-e a 20. szintet
   - Ha nem, folytatódik a következő kör

2. Írd le pseudokódban vagy kommentekben a játék főciklusának lépéseit.

─────────────────────────────

🛠 B. Implementáció lépései

1. Hozz létre egy metódust, pl. `JatekCiklus()`, ami tartalmaz egy while ciklust:

    while (karakter.Szint < 20)
    {
        // szörny generálása
        // harc indítása
        // ha nyer: tárgyak és tapasztalat hozzáadása
        // szint ellenőrzése
    }

2. Gondoskodj róla, hogy a ciklusból ki tudj lépni, ha a karakter meghal vagy eléri a 20. szintet.

3. A harc eredményétől függően kezeld a karakter állapotát (például hp csökkenése).

4. Konzolon jelenítsd meg minden kör eseményeit (harc kimenetele, tárgyak, szintlépés).

─────────────────────────────

🧠 Kérdések, gondolkodtató pontok:

- Hogyan biztosítod, hogy a játék ne fusson végtelen ciklusban?
- Hogyan tudod logikailag elkülöníteni a játék állapotának kezelését (él, halott, győztes)?
- Milyen metódusokat használsz a különböző feladatokhoz (harc, loot, fejlődés)?
- Hogyan teheted modulárissá a játékciklust, hogy később könnyen bővíthető legyen?

─────────────────────────────

🧑‍💻 Konzolos teszt javaslat:

1. Indítsd el a játékciklust a `Main` metódusból.
2. Figyeld meg, hogyan változik a karakter szintje.
3. Próbáld ki, hogy a karakter eléri-e a 20. szintet, és megjelenik-e a győzelmi üzenet.
4. Ha a karakter meghal (hp=0), a játék szintén érjen véget, és írj ki erről egy üzenetet.

─────────────────────────────

✅ Amit megtanulsz ezzel a szakaszzal:

- Ciklusok és feltételek gyakorlati alkalmazása.
- Egy program fő logikájának megtervezése.
- Objektumok közötti együttműködés a játékmenetben.
- Konzolos output vezérlése.

─────────────────────────────

----------------------------------------------