namespace T {

    public interface IPrm {

        IMngr IMngr { set; }
        DActn[] DPrmArry { get; }
        void Prm(byte ePrm);
        void Omt(byte ePrm);
    }
}