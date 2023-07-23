# Zahtjevi korisnika

* Nastavnik se u aplikaciju prijavljuje sa korisničkim podacima za sam SQL Server
* U slučaju neuspješne prijave, aplikacija treba korisniku dati informaciju u čemu je problem (jesu li neispravni podaci, ili nema odgovora od servera, i sl.)
* Prilikom prijave, nastavnik može specificirati i putanju do SQL servera (dakle s istom aplikacijom se treba moći spojiti na različite servere).
* Kada se nastavnik logira, u nekom dijelu aplikacije mora stalno biti vidljivo koji korisnik je prijavljen i na koji smo server prijavljeni.
* Nastavnik mora biti u mogućnosti vidjeti popis kreiranih aktivnih baza (filtrirano po akademskoj godini). Po defaultu se prikazuju baze za tekuću akademsku godinu. Za svaku bazu je potrebno vidjeti:
(1) TeamNumber - kojem timu pripada baza,
(2) Name - naziv baze,
(3) CreationDate - datum kreiranja,
(4) Username - korisničko ime za spajanje na bazu,
(5) Password - lozinka je skrivena na ekranu,
(6) Note - proizvoljan komentar,
(7) EmailSent - Podatak o tome je li email sa pristupnim podacima za bazu već poslan timu studenata.
(8) ContactEmail - email člana ili članova tima kojemu bi se trebao poslati email s pristupnim podacima za bazu.
* osim prikaza aktivnih baza, korisnik mora moći vidjeti i zaseban popis arhiviranih baza (to su baze koje su u našoj evidenciji označene kao arhivirane, a na SQL serveru su deattach-ane).
* Prikazane baze nastavnik treba moći i pretraživati po nazivu tima
* Nastavnik sa popisa postojećih baza može obrisati jednu ili više selektiranih baza. Pri tome se baza/baze trebaju obrisati i sa servera i iz naše evidencije u aplikaciji. U slučaju da pokušamo obrisati bazu podataka, a ona je već obrisana sa servera (tj. ne postoji na serveru) potrebno je onda samo obrisati zapis iz naše evidencije.
* Osim mogućnosti brisanja postojećih baza, potrebno je omogućiti i arhiviranje baza. Tj. baze se moraju moći arhivirati. To će bazu u našoj evidenciji označiti kao arhiviranu, a na serveru će baza biti deattach-ana.
* za svaku pojedinačnu bazu podataka možemo poslati email sa pristupnim podacima. Pri tome se email poruka automatski generira (ali ju je prije slanja moguće editirati).
* Osim slanja emaila za pojedinačne baze, moguće je poslati email i za veći broj odabranih baza. U tom slučaju nije moguće mijenjati automatski generiranu poruku.
* Nastavnik može kreirati pojedinačnu bazu podataka na način da se generiraju i osnovni podaci na temelju broja tima (TeamNumber). Alternativno, nastavnik i sam može unijeti proizvoljan naziv baze, korisničko ime i lozinku za bazu koja će biti generirana.
* Osim generiranja pojedinačne baza, moguće je generirati i više baza od jednom. Jedan način je kroz čarobnjak definirati predložak za nazive baza (npr. prefix i sufix) te broj baza koje će biti generirane. Drugi način je generirati baze na temelju popisa baza (i pripadajućih podataka) na temelju datoteke.
* Potrebno je omogućiti editiranje postavki sustava, kao što je uređivanje popisa akademskih godina, 

NEFUNKCIONALNI ZAHTJEVI
* svaki put kada se radi neka potencijalno rizična operacija (kreiranje, brisanje, arhiviranje baza, slanje emailova,...) treba korisnika tražiti potvrdu kroz dijaloški okvir ili nešto slično.
* Kada se takve značajne operacije obave, potrebno je korisnika na nenametljiv i sažet način obavijestiti da je operacija uspješno završena. Npr. "Uspješno kreirano 25 baza podataka".
* Osim takvog sažetog načina, za velike operacije bi trebao biti kreirana log datoteka u kojoj bi bile detaljnije informacije o uspjehu ili neuspjehu operacije. Npr. Log datoteka u kojoj za 25 kreiranih baza piše:

"Uspješno kreirana baza 23001_DB"

"Uspješno kreirana baza 23002_DB"

"Uspješno kreirana baza 23003_DB"

...


Baza podataka ima (trenutno) samo jednu tablicu:

![image](https://user-images.githubusercontent.com/5802626/226627741-a7ae530f-dac2-42e9-a25b-062940124735.png)
