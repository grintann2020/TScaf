namespace T {

    public interface ITxt {

        TxtMngr Mngr { set; }
        string[][] Strns { get; }
        bool IsAppl { get;}
        void Appl();
        void Cncl();
    }
}