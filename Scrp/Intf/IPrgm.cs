namespace T {

    public interface IPrgm {

        PrgmMngr Mngr  { set; } // set program manager
        byte ECrrnPrcs { get; } // get currnet process
        bool IsExct { get; } // get is executed or not
        void Exct(); // execute default process
        void Exct(byte ePrcs); // execute specific process by enum
        void Trmn(); // terminate
        void PrpUpdt(); // prop update
        void Altr(byte ePrcs); // execute
    }
}
