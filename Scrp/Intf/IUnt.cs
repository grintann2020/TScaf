using UnityEngine;

namespace T {

    public interface IUnt {
        
        IUnt[] AdjcArry { get; }
        GameObject[] GmObjcArry { get; } // get the array of GameObjects in unit
        SGrd3 SPstn { get; } // get position
        SVctr3 SCrd { get; } // get coordinate
        float X { get; } // get x axis
        float Z { get; } // get z axis
        float Y { get; } // get y axis
        ushort Rw { get; } // get row
        ushort Clmn { get; } // get column
        ushort Lyr { get; } // get layer
        void StAdjc(byte indx, IUnt iUnt);
        void Admt(GameObject gmObjc); // move in
        void Omt(GameObject gmObjc); // move out
        void Omt(byte indx); // move out
        void Omt(); // move out
    }
}