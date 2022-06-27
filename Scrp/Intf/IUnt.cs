using UnityEngine;

namespace T {

    public interface IUnt {
        
        object[] CntnArry { get; } // get the array of GameObjects in unit
        IUnt[] AdjcArry { get; }
        SGrd3 SGrd { get; } // get grid
        SVctr3 SPstn { get; } // get position
        float X { get; } // get x axis
        float Z { get; } // get z axis
        float Y { get; } // get y axis
        int Rw { get; } // get row
        int Clmn { get; } // get column
        int Lyr { get; } // get layer
        bool IsIntractbl { get; set; }
        T GtCntn<T>(byte indx);
        void StAdjc(byte indx, IUnt iUnt);
        void Admt<T>(T cntn); // move in
        void Omt(byte indx); // move out
        void Omt(); // move out
    }
}