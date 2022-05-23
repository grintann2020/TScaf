namespace T {

    public interface IMngr {
        
        bool IsIntl { get; }
        void Rst();
        void Intl(IPrm iPrm);
    }
}