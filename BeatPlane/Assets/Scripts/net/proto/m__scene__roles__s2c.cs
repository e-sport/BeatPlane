using System;
using Engine;
using System.Collections.Generic;
public class m__scene__roles__s2c : ProtoBase
{
    public List<p_role> roles = new List<p_role> ();
    public m__scene__roles__s2c()
    {
        proto_id = 1201;
    }
    public override void read(ByteArray byteArray)
    {
        base.read(byteArray);
        short sLen = 0;
        int i = 0;

        sLen = byteArray.Readshort();
        for (i = 0; i < sLen; i++) {
            p_role kp_role = new p_role ();
            kp_role.read(byteArray);
            roles.Add(kp_role);
        }
    }
}
