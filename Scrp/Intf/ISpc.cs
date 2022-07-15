namespace T {

    public interface ISpc {

        IUnt[][][] IUnts { get; } // get the array of unit
        IUnt[] IUntPrs { get; } // get the pure array of unit interfaces
        IUnt ICntrUnt { get; } // get center unit interface
        SpcMngr Mngr { set; } // set manager
        SGrd3 SScl { get; } // get scale struct
        SGrd3 SCntrGrd { get; } // get center grid struct
        float UntWdth { get; } // get unit width
        float UntLngt { get; } // get unit length
        float UntHght { get; } // get unit height
        float UntXSpcn { get; } // get unit x axis spacing
        float UntZSpcn { get; } // get unit z axis spacing
        float UntYSpcn { get; } // get unit y axis spacing
        int Clmns { get; } // get amount of columns
        int Rows { get; } // get amount of rows
        int Lyrs { get; } // get amount of layers
        bool[][][] IsExsts { get; }
        bool IsCnst { get; } // get is construct or not
        void Cnst(byte eExst); // construct
        void Dcnst(); // deconstruct
    }
}