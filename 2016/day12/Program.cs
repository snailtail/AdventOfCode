// See https://aka.ms/new-console-template for more information
string[] Commands = File.ReadAllLines("input.txt");
//Step 1
Cpu myCpu = new Cpu();
myCpu.Load(Commands);
myCpu.Run();
Console.WriteLine(myCpu.Registers["a"]);
//Step 2
myCpu.Load(Commands);
myCpu.Registers["c"]=1;
myCpu.Run();
Console.WriteLine(myCpu.Registers["a"]);

/*

cpy x y copies x (either an integer or the value of a register) into register y.
inc x increases the value of register x by one.
dec x decreases the value of register x by one.
jnz x y jumps to an instruction y away (positive means forward; negative means backward), but only if x is not zero.

*/