#### Projekt to prosta aplikacja konsolowa do zarządzania wypożyczalnią sprzętu elektronicznego (laptopy, projektory, aparaty) dla studentów i pracowników.

## Uruchamianie projektu
Projekt ma już przygotowany template ze wszystkimi przypadkami w Program.cs, jedynie warto zaznaczyć, że program uruchamialem w wersji net10.0

## Podział na klasy i dziedziczenie:
1. Klasa Gear oraz Person - klasy bazowe. Zawierają to, co wspólne dla każdego sprzętu (ID, cena, status) i każdej osoby (imię, nazwisko, kara).
2. Klasy pochodne (np. Laptop, Student): tylko specyficzne dane (np. RAM w laptopie czy limit wypożyczeń u studenta). Gdybym chciał dodać klasę kolejnego sprzętu np. Smartfon, to wystarczy dopisać, a w zasadzie przekopiować schemat klas dziedziczących, ewentualnie zmienić .toString a cała reszta systemu (wypożyczanie, raport) będzie z nią odrazu współpracować

## Kohezja:
Postarałem zadbać o to, aby każda klasa zajmowała się jednym obszarem systemu:
1. FineMonitoring. Ta klasa ma zasadniczo jedno zadanie - obliczyć karę adekwatną do przekroczonego terminu
2. Rental. Zarządza całym procesem wypożyczania, sprawdza czy sprzęt jest wolny, czy użytkownik nie przekroczył limitu wypożyczeń dla swojej roli.
3. Gear. Odpowiada za przechowywanie informacji o sprzęcie, jego statusie. Posiada również metody pomocnicze takie jak displayAllGear()

## Coupling:
Mimo że klasy muszą ze sobą współpracować, starałem się, aby nie były od siebie uzależnione:

Klasa Rental nie sprawdza, czy wypożyczającym jest Student czy Employee. Sprawdza po prostu pole borrower.maxRentals. To sprawia, że mechanizm wypożyczania jest uniwersalny, nie trzeba zmieniać kodu Rental.cs, gdy dodamy nowy typ użytkownika.

Użycie metody base.ToString() pozwala klasom pochodnym na budowanie opisów na fundamencie klasy bazowej, co ułatwia zarządzanie formatowaniem tekstu w jednym miejscu.

## Odpowiedzialność: 
Konstruktor Rental:
- Pełni rolę strażnika. To on decyduje, czy wypożyczenie w ogóle może dojść do skutku. Jeśli sprzęt jest zajęty, konstruktor wypisuje błąd i nie dopuszcza do stworzenia obiektu na liście aktywnych wypożyczeń.


## Użycie LINQ
W projekcie użyłem technologii LINQ (np. .Count(), .FirstOrDefault()), co pozwoliło na szybkie i czytelne filtrowanie danych bez pisania długich pętli for. Dzięki temu kod odpowiedzialny za sprawdzanie limitów i przeterminowanych terminów jest krótki i czytelny.