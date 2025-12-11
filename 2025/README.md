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

### Dag 6: Trash Compactor  

#### Del 1  

Inga bekymmer alls här, var orolig att jag inte läst ordentligt - men det var bara att bygga en grid med tal och göra lite beräkningar. Det klurigaste är att parse:a och loopa igenom datan rätt när man ska gå kolumnvis neråt i gridden. Men egentligen inget konstigt.  

#### Del 2  

Oväntat enkelt för en uppgift på helgen och del 2. Jag trodde det skulle komma någon större twist.  
Jag såg framför mig en grid med chars, och en baklängesloop kolumnvis som "hittar" tal, och som sen agerar när den stöter på en + eller * char.  
Det enda trixiga här var att hitta bra logik för att veta när det är dags att summera och "återställa" för nästa grupp av tal. Man kan lätt sno in sig i looparna om man inte har en strategi klar.  
Här tog jag mig tiden att skriva pseudokod först, för att se om jag hade några hål i logiken.  
Jag hade ändå missat en "nollställning" vid summeringen, men det syntes snabbt vid lite print debugging.  
Jag önskar jag kunde säga att jag byggde testerna först - det gjorde jag inte.  
Hade jag gjort det ordenligt hade jag säkert hittat de logikfelen därigenom.  
Men det fördröjde mig inte så många sekunder även utan testerna.  
Testerna idag tillkom efter lösningarna var klara. Jag erkänner! :D  

### Dag 7: Laboratories  

#### Del 1  
Lite klurigare idag känns det som, men efter lite fundering konstaterade jag att för del 1 är det egentligen bara kolumnerna som är intressanta. Att hålla ordning på de unika kolumner som "just nu" har en "beam" när man rör sig genom gridden neråt rad för rad. Och om man stöter på en splitter så byter man ut en beam mot två st nya. Set:et håller själv ordning på att det inte blir dubbletter.  

#### Del 2  

Oh boy... Quantum tachyon manifolds minsann... Det här blir att fundera lite mer på.  
Det var kanske inte så krångligt som jag först trodde.  
Om man går igenom varje rad, letar efter varje splitter - och så håller man reda på hur många "potentiella vägar" i en lika stor grid, och så kollar för varje cell.  
Om man stöter på en splitter:  
Finns det några vägar som leder ner till den här splittern? I så fall ska grid:arna till höger och vänster om den här splittern just nu plussas på med antalet inkommande vägar "ovanifrån".  
Om man inte stöter på nån splitter (tom cell):  
Då ska eventuella inkommande vägar ovanifrån bara plussas på i aktuell cell.  

Detta var på flera sätt ett intressant problem just i del 2.  
Det är typexemplet för när själva problembeskrivningen "skrämmer" mig att först tro att det knappt är någon idé att jag ger mig på att lösa det.  
Men trots ord som "Quantum" och mitt mentala bildspel av osäkerhetsprinciper och katter i lådor med mera, så var själva problemet egentligen inte så svårt. Det var ju dessutom garanterat att partikeln skulle ta både höger och vänster väg genom en splitter, så det underlättade ju verkligen.  
Men det var tur att man åtminstone bara skulle hålla koll på en riktning (nedåt i gridden) om man säger så. Det blev ett ganska stort antal vägar. :D.  

#### Tester 

Idag började jag med testerna!  
Yayy!  
Sen att det inte blev så mycket tester mot själva lösningarnas invärtes funktionalitet i sig är ju en annan sak.  
:D  
Man får va glad för det lilla!  

### Dag 8: Playground  

#### Del 1  

Yikes..! Hitta punkter i 3D-space, gruppera efter vilka som är närmast varandra, räkna grupper.  
Först tänkte jag att det gick att räkna avståndet från "origo" 0,0,0 till varje punkt, och utifrån det gruppera dem. Men det visar sig att det inte hänger ihop med avståndet mellan två punkter nödvändigtvis.  
Jag tror att jag hittat ett sätt att få ihop dem parvis i alla fall tillsammans med det inbördes avståndet, en kostsam operation och man får ju kolla alla kombinationerna - vilket med testinputen ger 190 kombinationer av par, och med den fulla inputen 499 500 kombinationer. Den listan går att sortera efter avståndet, så nu finns det i alla fall en bas att utgå från.  
Nu behöver man "bara" skapa grupper av paren och hålla koll på dem på något vis.  
Jag tänkte linked list, men efter lite laborationer insåg jag att det lätt skulle bli loopar i den - vilket jag inte vill ha.  
Jag ska bolla lite med "AI" och se om vi kan arbeta oss fram till någon lämplig datastruktur för att hålla koll på detta.  

Vi hittade nåt som kallas DisjointSet - Ett sätt att hålla koll på och slå samman grupper. Varje punkt är först sin egen grupp, och roten i sin egen grupp.
Sen går man igenom dem efter inbördes avstånd, och kopplar ihop dem med varandra.  

#### Del 2  

En twist - som vanligt på del 1.  
Joina ihop alla par och håll koll på de två sista som kopplades ihop med något, vilka är det?
Multiplicera sedan deras X koordinater med varandra.  
Här var jag tvungen att förlita mig på ChatGPT för att reda ut problemet och hitta rätt algoritm - jag snurrade ner mig långt ner i källaren med problembeskrivningen och förstod fel ganska länge.  


### Dag 9: Movie Theater  

#### Del 1  

Hitta motsatta "hörn" som bildar rektanglar (kan vara en rak linje också), och kolla vilken den största möjliga arean som någon av dessa rektanglar täcker.  
Egentligen inget knepigt här, finns säkert nåt mer effektivt sätt att lösa det på men jag körde på att göra alla möjliga par, och jag använde mig av "manhattan distance" mellan punkterna för att avgöra vilka punkter som var längst ifrån varandra.  
Sen insåg jag att det inte nödvändigtvis bildade den största rektangeln, utan att det defacto var själva area-beräkningen till syvende och sist som avgjorde - och därför körde jag den på samtliga par, och sen valde jag bara ut max area från den beräkningen.  

#### Del 2  

Mitt huvud gör ont bara av att läsa beskrivningen.  
Jag tror jag har förstått vad som förväntas nu efter många omläsningar och genom att stirra på exemplen. Men jag har ingen direkt bra känsla för hur jag skulle lösa det.  
Lite kaffe kanske hjälper.  
Punkterna sitter ihop med varandra och bildar en yta, nu ska man hitta den största rektangeln som håller sig innanför denna yta egentligen. Om jag tolkar och översätter problemet till någotsånär korrekta tankar.  
Först tänker jag nåt slags fill - med gränspunkter att hålla sig inom, men det blir inte heller bra tror jag.  
Just nu funderar jag på att lagra alla punkter i "ytterkanterna" av ytan, och sen använda det som gränser när jag kollar rektanglar på samma sätt som i del 1 - men bara räkna rektanglarna som befinner sig innanför gränserna.  
Jag misstänker dock att den riktiga inputen kommer att generera för många punkter eller nåt sånt, så att det blir "ogörligt" att hantera. Men vi får se. Man måste börja nånstans, och än är jag inte redo att fråga AI om hjälp :D  
Jag testar att bygga en lista med alla "edges" till att börja med i alla fall.  
Som tilllägg till det blev det en funktion som tar fram hörnen på en rektangel - xmax, xmin, ymax, ymin.  
Sen blev det svårt som fan. Jag insåg att jag inte skulle kunna kolla varje punkt i varje rektangel, mot varje punkt i "ytan" - det skulle bli så in i helskotta många kombinationer att universum hinner upphöra existera innan det räknats klart.  
Jag googlade runt på diverse dåliga sökuttryck, innan jag slutligen gav upp och frågade ChatGPT om vilken typ av problem det är jag försöker lösa. Jag har ett projekt i ChatGPT där den fått instruktioner att inte ge mig lösningar utan att bolla om problembeskrivningar och hjälpa till att peta mig åt rätt håll för att förstå problemet och hitta möjliga angreppsvinklar.  
Här tog det en god stund för mig att förstå, och det hjälpte inte helt ändå - för nu snackar vi geometri och beräkningar på en nivå som jag aldrig gjort innan. Att kolla om en punkt befinner sig inuti en polygon (min "yta") och sen avgöra om en rektangel helt befinner sig innanför ytan med hjälp av att kolla skärningspunkter - var något som jag till sist fick be om hjälp med att förstå hur man skriver funktioner för.  
Så tack ChatGPT för de två funktioner som hjälpte mig med geometrin, samt coachningen att förstå hur de hänger ihop tillräckligt väl för att jag skulle kunna bygga logiken för del 2. :D  
__point_in_polygon__ samt __edge_intersects_rect_interior__  


### Dag 10: Factory  

#### Del 1  

Wow... När jag läste beskrivninen första gången imorse vid frukost så tänkte jag att det inte var nån idé alls att ens försöka sig på dagens problem.  
Efter lite jobb, och lunch i magen så läste jag om den igen och får en känsla av att det är bitwise jämförelser jag behöver använda. Kanske xor.  
Måste grunna lite mer på det!  
Det är inte jämförelser, det är xor bitmask jag behöver!  
Jag har gjort något sådant någon gång förut, men jag hittar det inte nu så jag får googla vidare :D  
Okej, så parsing av input så att Machine instansen får lösa det - och nu har den koll på sin egen "pattern_string" som visar hur det önskade målläget ska se ut, en count på hur många lampor den har, en bitmask för önskat läge, en lista med bitmasks för knapparna, och en lista av joltages.  
Oklart var joltages ska va till, men det kommer väl i del 2 om vi någonsin tar oss så långt.  
Nu finns det möjlighet att loopa över knapparna och xor:a dem med maskinens nuvarande state och se hur många knapptryckningar man behöver göra för att hitta önskad state.  
Det här har jag nu hållt på med tills jag ifrågasatte min lämplighet att sitta vid den här datamaskinen överhuvudtaget - hur svårt skulle det vara?!? Tydligen otroligt svårt.  
Jag bad till sist AI om hjälp att hitta ett sätt att bruteforce:a mig igenom knapptryckningskombinationerna och räkna vilken "billigaste" kombo som resulterade i rätt target state.  
Det visar sig att det finns ett antal smarta sätt som man kan göra detta på, bitmasker för alla kombinationer av knappar istället för flernivå loopar, och så kollar man bitwise om just den här knappen ska tryckas på just nu i en inre loop.  
På så sätt köttar man sig igenom alla kombinationer. Dessutom kom AI med ett förbättringsförslag att man skulle låta bli att kolla alla masker som har lika eller sämre bit_count() än den hittills bästa lösningen, så snabbar man upp det hela.

Så med facit i hand, och mycket hjälp av AI hade jag egentligen rätt vid frukosten. Det här skulle jag inte gett mig in på :-D  
Men å andra sidan så lärde jag mig en hel del av det, även om jag inte lyckades hitta hela lösningen själv - magkänslan var i alla fall rätt att det skulle kunna hanteras med bits även om jag inte hade rätt terminologi i huvudet när jag rubber-duckade till README'n.  

Vi ska se vad del 2 erbjuder...  

#### Del 2  

Åh helvete... Nu är det inte binärt längre, lampor på eller av. Nu är det joltages värdena som representerar counters som ska nå de specifika joltage värdena. 
På något vis känns detta som ett såntdär problem där jag naturligt hamnar i nån dålig algoritm som resulterar i sju kvintiljoner beräkningar, och äter sju hundra terabyte RAM. :D  
Jag har redan "fuskat" och frågat AI om steg 1, jag bollar lite om mina tankar att detta ändå är likt del 1, fast istället för binärt resultat så har vi nu counters på varje position som i vissa fall ska upp i och över hundratalen värdemässigt. 

Jaha, ChatGPT pratar om BFS, och deltavärden för knapparna. Vi testar. Vi lagrar joltages som en tuple, och för varje knapp lagrar vi en motsvarande delta-tuple som visar vilka counters som knappen påverkar knapp=(1,3) => delta=(0,1,0,1) om vi har 4 joltage counters.  
Än så länge är jag med i matchen hur det skulle funka. Vad jag har svårt att greppa är hur vi ska mäkta med att testa kombinationer och hitta den "bästa" - utan att testa i evighetens evighet.  
Okej, jag läste på mer runt BFS metodiken och jag hade ju fattat lite fel. Angreppsvinkeln med den blir att testa kombinationer i ordning efter antal knapptryck tills man första gången når target state. Då vet man att man har minsta möjliga. Så BFS kommer dra igenom först alla varianter där man bara trycker ner en av knapparna. Sen alla varianter där man trycker ner två av knapparna. Vi använder en kö som lagring för knapptrycken vi gör, och på så sätt testar vi kombinationerna tillsammans i "lager".  

Nu har jag testkört detta och med testinputen funkar det. Däremot blir det jobbigt redan på första maskinen i den riktiga inputen. Den har ju 8 st "räknare" i Joltage-sektionen, och värden upp till 250 på flera av dem, samt 8 "knappar" att trycka på.  
Efter ett par minuters körning på första "riktiga" maskinen så äter python 4 gigabytes av mitt arbetsminne, och den visar inga tecken på att lugna ner sig :D
Jag antar att det kanske hade gått att testa att sprida ut detta på multipla kärnor och processa parallellt, men jag tror inte brute strength är vägen fram ändå. Det känns lite som att försöka putta på alperna, även om jag kallar in 7 kompisar till som puttar så är det en otroligt oöverstiglig uppgift. :D. 

Jag får kolla om jag hittar en smartare lösning. Problemet med den är antagligen att jag inte kommer förstå matematiken bakom.  
Men jag kan ju be codex om en lösning om inte annat, nu vet jag ju vad som inte fungerar, och vad som fungerar en bit.  
Vi får se, jag laborerar på.  

*AI-hjälp för del 2:* Dokumentation av den AI-framtagna lösningen finns i `codex_explains_day10.md`. Jag (den här författaren) löste inte den delen själv.

### Dag 11: Reactor  

#### Del 1  

Jahaja, ett grafproblem. Vilken tur, det är jag ganska kass på - så då får jag chansen att öva.  
Jag tolkar att jag ska parse:a input:en och bygga en riktad graf där man bara kan röra sig åt ett håll. Och sen ska jag räkna alla möjliga vägar från "you" till "out".  
Här luktar det jättemycket DFS eller BFS

Börjat med att parse:a input:en till en `list[str]` som representerar vertices, och en `list[list[int]]` som är adjacency_matrix för dem. Alla edges får en weight av 1 eftersom det inte nämns några kostnader eller så. Och grafen är enkelriktad.  

Jag skapar en klass för ServerRack som får ta emot och göra parseingen och hålla matrisen (kablagen) och servrarna (vertices)  

Efter lite youtubande på kvällskvisten så verkar det mest rimliga vara DFS för att traversera grafen. Jag försöker väl bygga nåt sånt helt enkelt, jag tror jag vill ha det som en metod på ServerRack klassen. Jag börjar så i alla fall.  

Okej, gött. Jag kollade lite på DFS på youtube och använde deque() (Double Ended Queue) som stack, och sen var det egentligen bara att köra på, starta på startnoden. pusha in alla adjacent nodes till stacken (med hjälp av adjacency matrixen), varje gång vi poppat den nod som är "slutnoden" så ökar vi räknaren för det med 1 - då har vi nått fram.
Jag var på väg att stoppa in ett set för att hålla reda på "besökta noder" men glömde lite bort den när mina testkörningar visade att jag fick ett OK resultat med testinputen. Tur var väl det, för det hade ju effektivt dödat hela grejen med att räkna alla _möjliga_ vägar. Då hade jag fått första bästa bara.  

Nu kan jag ju bara bäva inför vad del 2 ska innebära såhär näst sista dagen... :D. 

#### Del 2  