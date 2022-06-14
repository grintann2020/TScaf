namespace T {

    public interface IStg {

        DActn[][] DPrgsArry { get; }
        StgMngr Mngr { set; } // set stage manager
        byte ECrrnPrgs { get; }
        bool IsImpl { get; } // get is implement or not
        void Impl(); // implement
        void Impl(byte ePrgs); // implement specific process by enum
        void Abrt(); // abort
        void PrpUpdt(); // prop update
    }
}