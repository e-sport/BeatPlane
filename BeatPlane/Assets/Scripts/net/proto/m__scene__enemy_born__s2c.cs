using System;
using Engine;
using System.Collections.Generic;
public class m__scene__enemy_born__s2c : ProtoBase
{
    public byte type;
    public short x;
    public short y;
    public m__scene__enemy_born__s2c()
    {
        proto_id = 1202;
    }
    public override void read(ByteArray byteArray)
    {
        base.read(byteArray);
        type = byteArray.Readbyte();
        x = byteArray.Readshort();
        y = byteArray.Readshort();
    }
}
