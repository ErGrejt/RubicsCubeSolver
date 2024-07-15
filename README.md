# RubicsCubeSolver - Aplikacja do Układania Kostki Rubika

RubicsCubeSolver jest projektem aplikacji konsolowej napisanej w języku C#, która umożliwia układanie kostki Rubika metodą LBL (Layer-by-Layer). Aplikacja jest początkowym etapem przed przekształceniem jej w grę mobilną na platformie Android w Unity. Celem końcowym projektu jest stworzenie interaktywnej gry 3D, która pozwoli użytkownikowi na skanowanie kostki Rubika za pomocą aparatu oraz wyświetli sekwencję ruchów potrzebną do jej ułożenia.

## Opis Projektu

RubicsCubeSolver umożliwia użytkownikowi interaktywne układanie kostki Rubika przy użyciu metody LBL. Aplikacja jest konsolowa i na obecnym etapie użytkownik może manualnie wprowadzać kolory każdego klocka kostki. Następnie aplikacja wyświetla sekwencję ruchów, które użytkownik powinien wykonać, aby ułożyć kostkę.
Aplikacja została napisana bez użycia jakichkolwiek bibliotek do układania kostek rubika. Zależało mi aby aplikacja układała kostkę w ten sam sposób co ja.

## Funkcje Aplikacji

- **Wprowadzanie stanu Kostki Rubika**: Użytkownik musi manualnie wpisywać kolory każdego klocka
- **Metoda LBL**: Implementacja metodologii układania kostki Rubika warstwa po warstwie.
- **Interaktywny Interfejs Konsolowy**: Prosty interfejs do interakcji z użytkownikiem w trybie tekstowym.

## Przyszłe Rozszerzenie

Planowane jest przeniesienie aplikacji do środowiska Unity w celu stworzenia mobilnej gry na platformę Android. Gra pozwoli użytkownikowi na skanowanie kostki Rubika za pomocą aparatu (szybsze niż ręcznie wpisywanie kolorów). Następnie aplikacja wyświetli sekwencję ruchów, które użytkownik powinien wykonać, aby ułożyć kostkę Rubika.

## Technologie

- **C#**: Główny język programowania aplikacji konsolowej.
- **Unity**: Środowisko do tworzenia interaktywnych gier 2D i 3D.
- **Android**: Platforma mobilna, na którą będzie przeznaczona gra.

## Statystyki

Przeprowadziłem kilka przykładowych ułożeń kostki, aby sprawdzić jej efektywność. Wykonałem po 5 prób oraz dodatkowo jedną próbę, w której testowane kostki były identycznie pomieszane.

### Kostka pomieszana i ułożona przeze mnie:

- **1 próba** - 122 ruchy
- **2 próba** - 159 ruchów
- **3 próba** - 171 ruchów
- **4 próba** - 239 ruchów (zrobiłem parę błędów)
- **5 próba** - 183 ruchy

Średnia: **174,8 ruchów na ułożenie**.

### Kostka ułożona przez aplikację:

- **1 próba** - 209 ruchów
- **2 próba** - 174 ruchy
- **3 próba** - 115 ruchów
- **4 próba** - 103 ruchy
- **5 próba** - 192 ruchy

Średnia: **158,6 ruchów na ułożenie**.

### Dodatkowy eksperyment z dokładnie tak samo pomieszaną kostką:

- **Aplikacja**: 144 ruchy
- **Ja**: 154 ruchy

### Błędy

Aplikacja wymaga lekkich poprawek, które mogą jeszcze bardziej zminimalizować ilość ruchów, głównie w kroku drugim.

## Autor
Projekt jest realizowany przez:
- Witold Woźniczka
