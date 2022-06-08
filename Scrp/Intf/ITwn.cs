namespace T {

    public interface ITwn {

        int Id { get; }
        void PrpUpdt(float tm);
        void Strt(float tm, bool isDly = true);
        void Ps(float tm);
        void Rsm(float tm);
    }
}