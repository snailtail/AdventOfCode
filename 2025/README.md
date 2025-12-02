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