using UnityEngine;

namespace T {

    public interface IObjcs { // objects interface

        ObjcsMngr Mngr { set; } // set objects manager
        void Found(Transform rtTrnsfrm);
        void Ruin();
        SObjc[] GtSObjcArry(byte eObjc);
        SObjc GtSObjc(byte eObjc, int id);
        GameObject[] GtGmObjcArry(byte eObjc);
        GameObject GtGmObjc(byte eObjc, int id);
        T GtInst<T>(byte eObjc, int id);
        T[] GtInstArry<T>(byte eObjc);
        void MltpCrt(byte[][] eKyArry, DActn dCrt = null);
        void Crt(byte eObjc, int amnt, DActn dInst = null);
        void Dlt(byte eObjc, int id);
        void Enbl(byte eObjc, DActn<SObjc> dActn);
        void Dsbl(byte eObjc, int id);
    }
}