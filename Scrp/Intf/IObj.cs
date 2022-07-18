using UnityEngine;

namespace T {

    public interface IObjs { // objects interface

        ObjsMng Mng { set; } // set objects manager
        void Fnd(Transform rtTrnsfrm); // found
        void Rn(); // ruin
        SObj[] GtSObjArr(byte eObj);
        SObj GtSObj(byte eObj, int id);
        GameObject[] GtGOArr(byte eObj);
        GameObject GtGO(byte eObj, int id);
        T GtIns<T>(byte eObj, int id);
        T[] GtInsArr<T>(byte eObj);
        void MltCrt(byte[][] eKyArr2, DAct dCrt = null);
        void Crt(byte eObj, int amn, DAct dIns = null);
        void Dlt(byte eObj, int id);
        void Enb(byte eObj, DRct<SObj> dEnb = null);
        void Dsb(byte eObj, int id);
    }
}