using System;
using Engine;
using System.Collections.Generic;
public class p_role : ProtoBase
{
    public string name;
    public Int32 x;
    public Int32 y;
    public p_role()
    {

    }
    public override void read(ByteArray byteArray)
    {
        name = byteArray.Readstring();
        x = byteArray.ReadInt32();
        y = byteArray.ReadInt32();
    }
    public override void write(ByteArray byteArray)
    {
        byteArray.Writestring(name);
        byteArray.WriteInt32(x);
        byteArray.WriteInt32(y);
    }
}
