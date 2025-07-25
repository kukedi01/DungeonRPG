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