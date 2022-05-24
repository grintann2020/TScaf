namespace T {

    public interface IStg {

        StgMngr Mngr  { set; } // set stage manager
        bool IsImpl { get; } // get is implement or not
        DActn[][] DPrgsArry { get; }
        void Impl(); // implement
        void Impl(byte ePrgs); // implement specific process by enum
        void Abrt(); // abort
        void PrpUpdt(); // prop update
    }
}