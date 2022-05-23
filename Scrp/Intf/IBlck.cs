using UnityEngine;

namespace T {

    public interface IBlck {

        SGrd3 Grd { get; }
        SCrdn3 Crdn { get; }
        GameObject[] GmObjcArry { get; }
        ushort Rw { get; }
        ushort Clmn { get; }
        ushort Lyr { get; }
        float X { get; }
        float Z { get; }
        float Y { get; }
        byte EUnt { get; set; }
        void MvIn(GameObject gmObjc); // move in
        void MvOt(GameObject gmObjc); // move out
        void MvOt(byte indx);
        void MvOt();
    }
}