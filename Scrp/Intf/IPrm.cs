namespace T {

    public interface IPrm {

        IMng IMng { set; }
        DAct[] DPrmArr { get; }
        void Prm(byte ePrm);
        void Omt(byte ePrm);
    }
}