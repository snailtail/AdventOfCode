string hexstring = File.ReadAllText("input.txt");
string binstring = Hexdecoder.HexStringToBinarystring(hexstring);

//Step 1:
Console.WriteLine(ParsePacket(binstring));


int ParsePacket(string Packet, int Count = -1)
{

    if (Packet == "" || double.Parse(Packet) == 0)
    {
        // to exit the recursiveness if we hit an empty string, or only zeroes left at the end.
        return 0;
    }

    if (Count == 0)
    {
        return ParsePacket(Packet, Count = -1);
    }

    int Version = Convert.ToInt32(Packet[0..3], 2);
    int PacketTypeID = Convert.ToInt32(Packet[3..6], 2);

    if (PacketTypeID == 4)
    {
        // This is a literal value
        int Position = 6;
        string packetPayload = "";
        bool reachedEnd = false;
        while (!reachedEnd)
        {
            if (Packet[Position] == '0')
            {
                // Last packet
                reachedEnd = true;
            }

            packetPayload += Packet[(Position + 1)..(Position + 5)];
            Position += 5;
        }
        return Version + ParsePacket(Packet[Position..], Count - 1);
    }
    else
    {
        // This is an operator packet
        char LengthTypeID = Packet[6];
        if (LengthTypeID == '0')
        {
            int numberOfBits = Convert.ToInt32(Packet[7..22], 2);
            return Version + ParsePacket(Packet[22..(22 + numberOfBits)], -1) + ParsePacket(Packet[(22 + numberOfBits)..], Count - 1);
        }
        else
        {
            int numberOfPackets = Convert.ToInt32(Packet[7..18], 2);
            return Version + ParsePacket(Packet[18..], Count = numberOfPackets);
        }
    }
}


internal static class Hexdecoder
{
    public static string HexCharToBinarystring(char c) => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
    public static string HexStringToBinarystring(string s) => string.Join(string.Empty, s.Select(c => HexCharToBinarystring(c)));

}