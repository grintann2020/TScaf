namespace T {

    public interface IStg {

        DAct[][] DPrgArr2 { get; }
        StgMng Mng { set; } // set stage manager
        byte ECrrPrg { get; }
        bool IsImp { get; } // get is implement or not
        void Imp(); // implement
        void Imp(byte ePrgs); // implement specific process by enum
        void Abr(); // abort
        void PrpUpd(); // prop update
    }
} 