using UnityEngine;

namespace T {

    public interface IUnt {

        GameObject[] GmObjcArry { get; } // get GameObject in unit
        SGrd3 Grd { get; } // get grid
        SCrdn3 Crdn { get; } // get coordinate
        ushort Rw { get; } // row
        ushort Clmn { get; } // column
        ushort Lyr { get; } // layer
        float X { get; }
        float Z { get; }
        float Y { get; }
        void Admt(GameObject gmObjc); // move in
        void Omt(GameObject gmObjc); // move out
        void Omt(byte indx); // move out
        void Omt(); // move out
    }
}