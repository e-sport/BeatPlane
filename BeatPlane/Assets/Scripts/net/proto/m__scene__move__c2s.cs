using System;
using Engine;
using System.Collections.Generic;
public class m__scene__move__c2s : ProtoBase
{
    public short x;
    public short y;
    public m__scene__move__c2s()
    {
        proto_id = 1203;
    }
    public override void write(ByteArray byteArray)
    {
        base.write(byteArray);
        byteArray.WriteInt32(proto_id);
        byteArray.Writeshort(x);
        byteArray.Writeshort(y);
    }
}
