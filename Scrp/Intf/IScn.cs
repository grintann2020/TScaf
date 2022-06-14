using UnityEngine;

namespace T {

    public interface IScn {

        ScnMngr Mngr { set; }
        bool IsEstb { get; } // is established or not
        void Estb(Transform _trnf, DActn dAftrEstb = null); // establish scene by generating all objects group
        void Estb(Transform _trnf, byte eGrp, DActn dAftrEstb = null); // establish scene by generating specific objects group by enum, dBE = before established, dAE = after established
        void Elmn(); // eliminate scene by release all object groups
        void Elmn(byte eGrp); // eliminate scene by release specific object group by enum
        bool IsGrpEstb(byte eGrp); // return is group established or not
        GameObject GtGmObjc(byte eGrp, byte eObjc); // return specific gameObject in specific group by enum
        void Enbl(byte eGrp); // enable specific object group by enum
        void Dsbl(byte eGrp); // disable specific object group by enum
        void Enbl(byte eGrp, byte eObjc); // enable specific object in specific group by enum
        void Dsbl(byte eGrp, byte eObjc); // disable specific object in specific group by enum
    }
}