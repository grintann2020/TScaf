namespace T {

    public struct SGrd2 {

        public ushort Rw, Clmn;

        public SGrd2(ushort rw, ushort clmn) {
            Rw = rw;
            Clmn = clmn;
        }
    }

    public struct SGrd3 {

        public ushort Rw, Clmn, Lyr;

        public SGrd3(ushort rw, ushort clmn, ushort lyr) {
            Rw = rw;
            Clmn = clmn;
            Lyr = lyr;
        }
    }
}