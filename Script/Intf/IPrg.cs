namespace T {

    public interface IPrg {

        PrgMng Mng  { set; } // set program manager
        byte ECrrPrc { get; } // get currnet process
        bool IsExc { get; } // get is executed or not
        void Exc(); // execute default process
        void Exc(byte ePrc); // execute specific process by enum
        void Trm(); // terminate
        void PrpUpd(); // prop update
        void Alt(byte ePrc); // execute
    }
}
