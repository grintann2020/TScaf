namespace T {

    public interface ISpc {

        IUnt[][][] IUntArry { get; }
        IScn IScn { set; }
        float UntWdth { get; } // get unit width
        float UntLngt { get; } // get unit length
        float UntHght { get; } // get unit height
        float UntXSpcn { get; } // get unit x axis spacing
        float UntZSpcn { get; } // get unit z axis spacing
        float UntYSpcn { get; } // get unit y axis spacing
        byte Clmns { get; } // get amount of columns
        byte Rws { get; } // get amount of rows
        byte Lyrs { get; } // get amount of layers
        bool[][][] IsExstArry { get; }
        bool IsCnst { get; } // get is construct or not
        void Cnst(byte eExst); // construct
        void Dcnst(); // deconstruct
    }
}