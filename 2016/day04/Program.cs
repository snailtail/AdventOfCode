// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

List<Room> rooms = new();


Console.WriteLine("Hello, World!");
var lines = File.ReadAllLines("input.txt").Where(l=> !String.IsNullOrEmpty(l));

int sumOfSectors = 0;
List<string> RoomNames = new();
foreach(var line in lines)
{
    var room = new Room(line);
    if(room.IsValid)
    {
        sumOfSectors+=room.sectorID;
    }
    rooms.Add(room);
    //Console.WriteLine(line);
    RoomNames.Add($"{room.sectorID} -> {room.DecryptedName}");
    Console.WriteLine(room.sectorID + " -> " + room.DecryptedName);
}

Console.WriteLine($"Step 1: {sumOfSectors}");
File.WriteAllLines("/Users/magnus/aoc_rooms.txt",RoomNames.ToArray());
