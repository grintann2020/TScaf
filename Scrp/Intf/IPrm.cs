namespace T {

    public interface IPrm {

        IMngr IMngr { set; }
        DActn[] DPrms { get; }
        void Prm(byte ePrm);
        void Omt(byte ePrm);
    }
}