using System;
using Engine;
using System.Collections.Generic;
public class m__scene__roles__s2c : ProtoBase
{
    public short x;
    public short y;
    public List<p_role> roles = new List<p_role> ();
    public m__scene__roles__s2c()
    {
        proto_id = 1201;
    }
    public override void read(ByteArray byteArray)
    {
        base.read(byteArray);
        x = byteArray.Readshort();
        y = byteArray.Readshort();
        short sLen = 0;
        int i = 0;

        sLen = byteArray.Readshort();
        byteArray.ReadInt32 (); //完全没用的占位
        for (i = 0; i < sLen; i++) {
            p_role kp_role = new p_role ();
            byteArray.ReadInt32 (); //完全没用的占位
            kp_role.read(byteArray);
            roles.Add(kp_role);
        }
    }
}
