using System.Diagnostics;
using System.Security;
using System.Xml;

var lines = File.ReadAllLines("input.txt");
List<Aunt> aunts = new();
foreach(var line in lines)
{
    var parts = line.Split(" ");
    string name = parts[0];
    string id = parts[1].Substring(0,parts[1].Length-1);
    int? children = null;
    int? cats= null;
    int? samoyeds= null;
    int? pomeranians= null;
    int? akitas= null;
    int? vizslas= null;
    int? goldfish= null;
    int? trees= null;
    int? cars= null;
    int? perfumes= null;
    for(int n = 2; n < 7; n+=2)
    {
        switch(parts[n])
        {
            case "children:":
                children=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "cats:":
                cats=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "samoyeds:":
                samoyeds=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "pomeranians:":
                pomeranians=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "akitas:":
                akitas=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "vizslas:":
                vizslas=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "goldfish:":
                goldfish=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "trees:":
                trees=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "cars:":
                cars=int.Parse(parts[n+1].Replace(",",""));
                break;
            case "perfumes:":
                perfumes=int.Parse(parts[n+1].Replace(",",""));
                break;
            default:
                break;
        }
    }

    // id = part 1 - minus sista tecknet
    // part 2-3, 4-5, 6-7 är propertyname och antal
    var aunt = new Aunt(id,children,cats,samoyeds,pomeranians,akitas,vizslas,goldfish,trees,cars,perfumes);
    aunts.Add(aunt);
}

var step1 = aunts.Where(
    o => 
    (o.children == null || o.children == 3) 
    && 
    (o.cats == null || o.cats==7)
    &&
    (o.samoyeds==null || o.samoyeds==2)
    &&
    (o.pomeranians == null || o.pomeranians==3)
    &&
    (o.akitas==null || o.akitas==0)
    &&
    (o.vizslas==null || o.vizslas==0)
    &&
    (o.goldfish == null || o.goldfish==5)
    &&
    (o.trees==null || o.trees==3)
    &&
    (o.cars==null || o.cars==2)
    &&
    (o.perfumes == null || o.perfumes==1)
    ).ToList();
Console.WriteLine(step1[0].ID);

var step2 = aunts.Where(
    o => 
    (o.children == null || o.children == 3) 
    && 
    (o.cats == null || o.cats>7)
    &&
    (o.samoyeds==null || o.samoyeds==2)
    &&
    (o.pomeranians == null || o.pomeranians<3)
    &&
    (o.akitas==null || o.akitas==0)
    &&
    (o.vizslas==null || o.vizslas==0)
    &&
    (o.goldfish == null || o.goldfish<5)
    &&
    (o.trees==null || o.trees>3)
    &&
    (o.cars==null || o.cars==2)
    &&
    (o.perfumes == null || o.perfumes==1)
    ).ToList();

Console.WriteLine(step2[0].ID);
internal class Aunt
{
    public string ID;
    public int? children;
    public int? cats;
    public int? samoyeds;
    public int? pomeranians;
    public int? akitas;
    public int? vizslas;
    public int? goldfish;
    public int? trees;
    public int? cars;
    public int? perfumes;
    public Aunt(string Id, int? Children, int? Cats, int? Samoyeds, int? Pomeranians, int? Akitas, int? Vizslas, int? Goldfish, int? Trees, int? Cars, int? Perfumes)
    {
        ID = Id;
        children=Children;
        cats=Cats;
        samoyeds=Samoyeds;
        pomeranians=Pomeranians;
        akitas=Akitas;
        vizslas=Vizslas;
        goldfish=Goldfish;
        trees=Trees;
        cars=Cars;
        perfumes=Perfumes;
    }
}