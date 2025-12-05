# Advent of Code 2025

[![2025 Python Tests](https://github.com/snailtail/AdventOfCode/actions/workflows/2025-python.yml/badge.svg)](https://github.com/snailtail/AdventOfCode/actions/workflows/2025-python.yml)

Här försöker jag mig på att lösa [Advent of Code 2025](https://adventofcode.com/2025).  

Detta år gör jag ett nytt försök att använda Python för att lösa pusslen.

## Logg  

### Dag 1: Secret Entrance  

#### Del 1  

Inga större problem egentligen, av någon anledning fastnade jag rätt länge på något "off by one" fel - som så många gånger förr. Jag vet inte om det var jag som tänkte fel, eller om det bara var ovanan av Python - säkert en kombination. Men till sist så fick jag till det i alla fall.  

#### Del 2  

Här höll jag på en hel del och velade fram och tillbaka innan jag till sist bestämde mig för att göra den simplaste lösningen möjligt och bara räkna steg för steg, skippa modulo och sånt. Jag hade helt sonika inte orken att göra om min lösning från steg 1 i tanken allt för mycket. Hade jag orkat skulle jag gjort en regelrätt klass för min dial kanske, och lagt in lite vettiga checks i dess metoder - så hade det varit betydligt mindre bökigt att hålla ordning på.  

### Dag 2: Gift Shop  

#### Del 1  

Inget större problem alls, spenderade en del tid åt att försöka göra en "pythonisk" parse av input:en utan att googla - gav upp det, och löste dagen först med min något o-pythoniska metodik, men återkom och åtgärdade parse delarna efteråt.  
Basically var lösningen att kolla om vänster halva av ett "tal" i en range matchar höger halva. Tal som bestod av ojämnt antal siffror kunde man egentligen skippa helt då de omöjligt kunde uppfylla kriterierna.  

#### Del 2  

En twist på del 1.  
Jag hade nyligen pillat med .count() i Python så jag snavade kanske pga det ganska snabbt in på en metodik som gick att använda.  
Jag loopar igenom slices av strängen och kollar om längden på slicen multiplicerat med antalet förekomster av den slicen i hela strängen, matchar längden på hela strängen. I så fall består strängen av enbart upprepningar av slicen - då kan jag räkna den som invalid och break:a ur loopen.  

```python
for le in range(1,len(s)):
    part = s[:le]
    if len(part) * s.count(part) == len(s):
        invalid_ids.append(v)
        break
```

### Dag 3: Lobby  

#### Del 1  

Här började jag - korkat nog - med att leta efter de två största siffrorna i varje nummersekvens - och sen sätta ihop dem. Det tog inte så lång tid att montera den lösningen.  
Men jag borde kanske ha förstått vad som skulle komma i del 2.. :D. 

#### Del 2  

Nu skulle man inte ha 2 siffror längre, utan 12. Så då föll hela lösningen från del 1 till föga. Jag kan ju inte hålla ordning på 12 siffror och deras inbördes ordning på det viset.  
Först föll tanken på permutationer, men jag insåg att det ju skulle förändra inbördes ordningen på siffrorna - och dels att permutera strängar med 100 tecken skulle ta "lite väl lång tid".  
Efter mycket funderande och testande kom jag fram till att en stack kunde lösa detta. Att gå från most significant till least significant och kolla hela tiden om den förra siffran var mindre än nuvarande - och i så fall plocka bort den - tills man har rätt antal kvar. Det blev en lösning som tog lite puts att få till, men den fungerar ju bra oavsett längden man vill ha. Mycket tur idag med tror jag :D  
Tyvärr orkade jag inte börja med testerna, jag får se om jag kompletterar dagen med tester senare.  
Egentligen vill jag ju köra testdrivet.  

### Dag 4: Printing Department  

#### Del 1  

Inga konstigheter här, navigera en grid och räkna angränsande saker.  

#### Del 2  

Lustigt nog inga större konstigheter här heller, hade nog förväntat mig en svårare twist.  
En ganska enkel while loop tills inga entiteter går att "ta bort" längre.


### Dag 5: Cafeteria  

#### Del 1  

Inte några direkta konstigheter nu heller, det enda var att jag läste felaktigt att jag skulle hitta alla ogiltiga ingredigenser - så jag byggde en onödigt komplex lösning för del 1. När jag läste ordentligt och insåg att jag bara skulle hitta alla giltiga id'n så satt jag med lite mer komplexitet än jag behövde, men svaret fanns ju också där så det var väl okej antar jag :D  

#### Del 2  

Först tänkte jag att jag bara kunde köra enkel matematik och subtrahera stop - start och lägga till 1 för att få antal tal inom varje range. Men då ignorerade jag ju faktumet att ranges kan överlappa. Det tog en god stund att klura ut en lösning på det. Lösningen blev att gå igenom alla ranges och göra en "merge" av överlappande. Först sortera dem efter startvärdet, och sen kolla om nästa ranges start var mindre än nuvarande end, och slå ihop dem bara.
Därefter kunde man göra så som jag tänkte från början, och subtrahera stop - start och addera 1 för att få antalet tal inom varje range - utan att riskera att få dubbletter.  

Jag testade faktiskt en variant med att göra ett set av alla id'n från varje range, men det var duktigt stora ranges att loopa över så det var inte riktigt genomförbart i praktiken.  
