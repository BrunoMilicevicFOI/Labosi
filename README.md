# Labosi

Labosi trenutno

## Praćenje rada na Wiki stranici

GitHub Wiki ima **vlastiti git repozitorij** odvojen od glavnog repozitorija.
Postoje dva načina kako vidjeti koliko ste radili na wiki stranici:

### 1. Pregled povijesti na GitHubu

Posjetite stranicu s poviješću wiki stranice:

```
https://github.com/BrunoMilicevicFOI/Labosi/wiki/_history
```

Na svakoj wiki stranici kliknite na gumb **History** (Povijest) u gornjem desnom kutu.

### 2. Kloniranje Wiki repozitorija lokalno

Wiki ima vlastiti git repozitorij koji možete klonirati i pregledavati:

```bash
git clone https://github.com/BrunoMilicevicFOI/Labosi.wiki.git
cd Labosi.wiki
git log --oneline --all
```

### 3. Praćenje wiki promjena u glavnom repozitoriju

Ovaj repozitorij koristi GitHub Actions (`gollum` event) za automatsko bilježenje
svake promjene na wiki stranici kao commit u glavnom repozitoriju.
Promjene se bilježe u datoteci [`wiki-contributions.md`](wiki-contributions.md).

Time možete vidjeti sve wiki commitove zajedno s ostalim commitovima u:
```
https://github.com/BrunoMilicevicFOI/Labosi/commits
```
