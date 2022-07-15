using UnityEngine;

namespace T {

    public interface IObjcs { // objects interface

        ObjcsMngr Mngr { set; } // set objects manager
        void Found(Transform rtTrnsfrm);
        void Ruin();
        SObjc[] GtSObjcs(byte eObjc);
        SObjc GtSObjc(byte eObjc, int id);
        GameObject[] GtGmObjcs(byte eObjc);
        GameObject GtGmObjc(byte eObjc, int id);
        T GtInst<T>(byte eObjc, int id);
        T[] GtInsts<T>(byte eObjc);
        void MltpCrt(byte[][] eKys, DActn dCrt = null);
        void Crt(byte eObjc, int amnt, DActn dInst = null);
        void Dlt(byte eObjc, int id);
        void Enbl(byte eObjc, DActn<SObjc> dActn = null);
        void Dsbl(byte eObjc, int id);
    }
}