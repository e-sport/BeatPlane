using System;
using Engine;
using System.Collections.Generic;
namespace Engine 
{
    public class ProtoMap : Singleton<ProtoMap>
    {
        private Dictionary<int, Type> m_DicProtoType;
        public ProtoBase GetProto(int uiProtoID)
        {
            Type kProtoType;
            m_DicProtoType.TryGetValue(uiProtoID, out kProtoType);
            if (kProtoType != null)
            {
                ProtoBase kProto = null;
                kProto = Activator.CreateInstance(kProtoType) as ProtoBase;
                return kProto;
            }
            else
            {
                return null;
            }
        }
        public static readonly int m__role__login__c2s = 1001;
        public static readonly int m__proto__test__c2s = 998;
        public static readonly int m__proto__test__s2c = 999;
        public static readonly int m__system__heartbeat__c2s = 1000;
        public static readonly int m__role__login__s2c = 1100;
        public static readonly int m__scene__enter__c2s = 1200;
        public static readonly int m__scene__roles__s2c = 1201;
        public ProtoMap()
        {
            m_DicProtoType = new Dictionary<int, Type>();
            m_DicProtoType[m__role__login__c2s] = typeof(m__role__login__c2s);
            m_DicProtoType[m__proto__test__c2s] = typeof(m__proto__test__c2s);
            m_DicProtoType[m__proto__test__s2c] = typeof(m__proto__test__s2c);
            m_DicProtoType[m__system__heartbeat__c2s] = typeof(m__system__heartbeat__c2s);
            m_DicProtoType[m__role__login__s2c] = typeof(m__role__login__s2c);
            m_DicProtoType[m__scene__enter__c2s] = typeof(m__scene__enter__c2s);
            m_DicProtoType[m__scene__roles__s2c] = typeof(m__scene__roles__s2c);
        }
    }
}
