
## 1. GET – összes eszköz lekérése

**Method:**

```text
GET
```

**URL:**

```text
http://localhost:5242/api/eszkozok
```

**Body:**  
nem kell

**Elvárt eredmény:**

```text
200 OK
```

és egy JSON tömb az eszközökkel.

---

## 2. POST – új eszköz létrehozása

**Method:**

```text
POST
```

**URL:**

```text
http://localhost:5242/api/eszkozok
```

Postmanban:

```text
Body
→ raw
→ JSON
```

Body:

```json
{
  "nev": "Teszt laptop",
  "leltariSzam": "TEST-001",
  "kategoria": "Laptop",
  "gyarto": "Dell",
  "modell": "Latitude 5550",
  "terem": "A304",
  "allapot": "Jó",
  "hasznalatbanVan": true,
  "kolcsonozheto": true,
  "beszerzesiAr": 250000,
  "beszerzesDatuma": "2026-09-15"
}
```

**Elvárt eredmény:**

```text
201 Created
```

A válaszban kapsz egy új ID-t, például:

```text
21
```

Ezt jegyezd meg.

---

## 3. PUT – az új eszköz módosítása

Ne az `1`-es rekordot módosítsd, hanem a POST során létrehozott teszteszközt.

Ha például az új ID:

```text
21
```

akkor:

**Method:**

```text
PUT
```

**URL:**

```text
http://localhost:5242/api/eszkozok/21
```

Body:

```json
{
  "nev": "Módosított teszt laptop",
  "leltariSzam": "TEST-001",
  "kategoria": "Laptop",
  "gyarto": "Dell",
  "modell": "Latitude 5550",
  "terem": "A315",
  "allapot": "Közepes",
  "hasznalatbanVan": true,
  "kolcsonozheto": false,
  "beszerzesiAr": 260000,
  "beszerzesDatuma": "2026-09-15"
}
```

**Elvárt eredmény:**

```text
204 No Content
```

Utána GET-tel ellenőrizd, hogy tényleg módosult.

---

## 4. DELETE – a teszteszköz törlése

Ugyanazzal az ID-val:

**Method:**

```text
DELETE
```

**URL:**

```text
http://localhost:5242/api/eszkozok/21
```

**Body:**  
nem kell

**Elvárt eredmény:**

```text
204 No Content
```

Utána újra:

```text
GET http://localhost:5242/api/eszkozok
```

és a `TEST-001` leltári számú eszköznek már nem szabad szerepelnie.

A jó tesztsorrend tehát:

```text
GET
→ POST
→ a kapott ID-val PUT
→ ugyanazzal az ID-val DELETE
→ GET ellenőrzés
```

