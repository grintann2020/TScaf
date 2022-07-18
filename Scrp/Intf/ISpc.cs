namespace T {

    public interface ISpc {

        IUnt[][][] IUntArr3 { get; } // get the array of unit
        IUnt[] IUntPrArr { get; } // get the pure array of unit interfaces
        IUnt ICntUnt { get; } // get center unit interface
        SpcMng Mng { set; } // set manager
        SGrd3 SScl { get; } // get scale struct
        SGrd3 SCntGrd { get; } // get center grid struct
        float UntWdt { get; } // get unit width
        float UntLng { get; } // get unit length
        float UntHgh { get; } // get unit height
        float UntXSpc { get; } // get unit x axis spacing
        float UntZSpc { get; } // get unit z axis spacing
        float UntYSpc { get; } // get unit y axis spacing
        int Clm { get; } // get amount of columns
        int Rw { get; } // get amount of rows
        int Lyr { get; } // get amount of layers
        bool[][][] IsExsArr3 { get; }
        bool IsCnst { get; } // get is construct or not
        void Cnst(byte eExs); // construct
        void Dcns(); // deconstruct
    }
}