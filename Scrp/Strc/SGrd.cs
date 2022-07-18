namespace T {

    public struct SGrd2 {

        public int Clm, Rw;

        public SGrd2(int clm, int rw) {
            Clm = clm;
            Rw = rw;
        }
    }

    public struct SGrd3 {

        public int Clm, Rw, Lyr;

        public SGrd3(int lyr, int clm, int rw) {
            Lyr = lyr;
            Clm = clm;
            Rw = rw;
        }
    }
}