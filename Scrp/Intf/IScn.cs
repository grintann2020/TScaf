using UnityEngine;

namespace T {

    public interface IScn {

        ScnMng Mng { set; }
        bool IsEst { get; } // is established or not
        void Est(Transform _tf, DAct dEst = null); // establish scene by generating all objects group
        void Est(Transform _tf, byte eGrp, DAct dEst = null); // establish scene by generating specific objects group by enum, dBE = before established, dAE = after established
        void Elm(); // eliminate scene by release all object groups
        void Elm(byte eGrp); // eliminate scene by release specific object group by enum
        bool IsGrpEst(byte eGrp); // return is group established or not
        GameObject GtGO(byte eGrp, byte eObj); // return specific gameObject in specific group by enum
        void Enb(byte eGrp); // enable specific object group by enum
        void Dsb(byte eGrp); // disable specific object group by enum
        void Enb(byte eGrp, byte eObj); // enable specific object in specific group by enum
        void Dsb(byte eGrp, byte eObj); // disable specific object in specific group by enum
    }
}