using UnityEngine;

namespace T {

    public interface IUnt {

        object[] CntArr { get; } // get the array of GameObjects in unit
        IUnt[] AdjArr { get; } // get the array of adjacent
        SGrd3 SGrd { get; } // get grid
        SVct3 SPst { get; } // get position
        float X { get; } // get x axis
        float Z { get; } // get z axis
        float Y { get; } // get y axis
        int Rw { get; } // get row
        int Clm { get; } // get column
        int Lyr { get; } // get layer
        bool IsIaa { get; set; } // get is interactable or not
        bool IsEnb { get; }
        T GtCnt<T>(byte indx);
        void Enb();
        void Dsb();
        void StAdj(byte idx, IUnt iUnt);
        void Adm<T>(T cnt); // move in
        void Omt(byte idx); // move out
        void Omt(); // move out
    }
}