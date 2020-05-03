# duomenu-apdorojimas
## Versija 0.1 ##
Kaip naudoti:

1. Atidarius programą spausti 'enter' klavišą.

2. Įvesti studento pavardę, vardą, pažymius ir spausti 'enter' vieną kartą norint įvesti naują studentą arba du kartus, norint pereiti prie funkcijos pasirinkimo. Jei norima kad pažymiai būtų generuojami atsitiktinai, vietoje pažymio įvedame kiek atsitiktinių pažymių norime ir prirašome 'k' (kartai) raidę. Pvz: Įrašius 'Antanaitis Antanas 5k', šiam studentui bus atsitiktinai sugeneruojami 5 pažymiai.

3. Įvedame '1' ir spaudžiame 'enter', jei norime apskaičiuoti studentų pažymių vidurkį, įvedame '2' ir spaudžiame 'enter', jei norime apskaičiuoti studentų pažymių medianą.

4. Programa parodo studentų pažymių vidurkius arba medianas, norint toliau naudoti programą vėl spaudžiame 'enter'. Norint išeiti iš programos įvedame žodį 'exit' ir spaudžiame 'enter'.

## Versija 0.2 ##
Kaip naudoti:

1. Atidarius programą įvesti žodį 'file'.
2. Įvesti kelią iki studentai.txt failo (turi baigtis \studentai.txt).
3. Paspaudus 'enter' klavišą, bus parodomas visų studentų įrašytų faile rezultatų vidurkis ir mediana. Studentai surikiuoti pagal pavardę abėcėlės tvarka.

## Versija 0.3 ##
Atliktas kodo išskaidymas į atskirus .cs failus ir pora kartų panaudotas išimčių valdymas.

## Versija 0.4 ##
Kaip naudoti:

1. Atidarius programą įvesti žodį 'gen'.
2. Programa pradės generuoti failus iš 1000, 10000, 100000, 1000000 ir 10000000 įrašų. Iš viso 10 failų, surušiuotų pagal pavardes ir išskirtų pagal pažymių vidurkį į vargšiukus ir kietiakus.

Tuo pat metu yra atliekama ir programos greičio analizė, rezultatai gauti atlikus šią analizę su mano kompiuteriu yra tokie:

 Studentu #          Pridejimas          Rusiavimas          Paskirstymas        Failu generavimas
----------------------------------------------------------------------------------------------------
 1000                0:00.5              0:00.10             0:00.11             0:00.40

 10000               0:00.20             0:00.52             0:00.53             0:00.117

 100000              0:00.238            0:00.577            0:00.595            0:00.962

 1000000             0:02.513            0:06.334            0:06.645            0:10.39

 10000000            0:40.446            1:31.549            1:32.833            2:04.360
 
 Čia:
 
 Studentu # - Kiek studentų buvo sugeneruota.
 Pridejimas - Kiek laiko min/sek/milisek užtruko pridėti studentus programos viduje.
 Rusiavimas - Kiek laiko min/sek/milisek užtruko pridėti studentus ir juos surūšiuoti.
 Paskirstymas - Kiek laiko min/sek/milisek užtruko pridėti,surūšiuoti ir paskirstyti studentus į dvi grupes pagal pažymius.
 Failu generavimas - Kiek laiko min/sek/milisek užtruko pridėti,surūšiuoti, paskirstyti studentus į dvi grupes pagal pažymius ir generuoti failą.
