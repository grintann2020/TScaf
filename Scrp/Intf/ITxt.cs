namespace T {

    public interface ITxt {

        TxtMngr Mngr { set; }
        string[][] StrnArry { get; }
        bool IsAppl { get;}
        void Appl();
        void Cncl();
    }
}