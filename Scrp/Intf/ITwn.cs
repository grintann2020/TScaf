namespace T {

    public interface ITwn {

        int Id { get; } // identity
        void PrpUpd(float tm); // prop update
        void Str(float tm, bool isDly = true); // start
        void Ps(float tm); // pause
        void Rsm(float tm); // resume
    }
}