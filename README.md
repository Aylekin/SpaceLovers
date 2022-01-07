# SpaceLovers
browser based puzzle game made with C# in Unity

## Cel i założenia
Gra "Space Lovers" jest grą stworzoną na przeglądarki w silniku Unity. Gra inspirowana jest kultową grą Binary Land z ery Pegasusa. Gra stworzona jest w pełni przeze mnie. Skrypty jak i oprawa graficzna jest mojego autorstwa ( z wyjątkiem czcionki użytej w grze ). 

## Technologie
* C#
* Unity 2D
* Adobe Photoshop 

## Uruchomienie
Repozytorium nie zawiera całego, kompletnego projektu. W folderze "Scripts" znajdują się tylko pliki z kodem .cs. 
Mają one za zadanie ukazać, jak zostały rozwiązane funkcjonalności i mechanizmy gry.


## Przebieg rozgrywki

### 1) Menu gry
Po włączeniu gry ukazuje się użytkownikowi proste menu główne z animowanym tłem. Do wyboru użytkownik ma 3 opcje: rozpocząć rozgrywkę, zobaczyć ustawienia jak i wyjście z gry.
W ustawieniach znajdują się opcje głośności muzyki i efektów dźwiękowych. Można je wyciszyć bądź dostosować ich poziom przy pomocy suwaków.

![screen1](/Screens/menu1.JPG)
![screen2](/Screens/menu2.JPG)
![screen3](/Screens/menu3.JPG)

### 3) Poziom I, II i III
Rozgrywka składa się z 3 poziomów stopniowo dodających dodatkowych mechanik i przeciwników. Gracz steruje jednocześnie dwoma postaciami przy pomocy strzałek na klawiaturze. Postaci poruszają się względem siebie w formie odbicia lustrzanego. Celem gracza jest uciknięcie przeszkód i dotarcze na górę planszy do drzwi odpowiednio żółtą i różową postacią po odpowiedniej ich stronie. Przy pomocy przycisków Z i X gracz może odpowiednio wystrzelić laser z konkretnej postaci, która niszczy przeciwników i przeszkody.
Do formie przeszkód ukazane są czarne dziury, które unieruchamiają postać gdy ta w nie wejdzie. Gracz może uwolnić postać niszcząc czarną dziurę przy pomocy lasera postaci, która nie została uwięziona. Gdy obydwie postaci zostaną złapane w czarne dziury gracz traci życia i poziom jest resetowany.
W formie przeciwników okazane są UFO, które poruszają się w pętli na odpowiedniej osi. Są 2 rodzaje UFO, różowe i żółte, które w zależności od postaci, która się do nich zbliży są bardziej agresywne. Kontakt postaci z przeciwnikiem kończy się automatyczną utratą życia i resetem poziomu. Gracz jest w stanie zniszczyć przeciwnika przy pomocy lasera.

Gra kończy się po utracie wszystkich żyć bądź w przypadku dotarcia do Finishu na wszystkich 3 poziomach.

![screen4](/Screens/poziom1.JPG)
![screen5](/Screens/poziom2.JPG)
![screen6](/Screens/poziom3.JPG)
