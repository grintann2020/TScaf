namespace T {

    public struct SGrd2 {

        public byte Clmn, Rw;

        public SGrd2(byte clmn, byte rw) {
            Clmn = clmn;
            Rw = rw;
        }
    }

    public struct SGrd3 {

        public byte Clmn, Rw, Lyr;

        public SGrd3(byte clmn, byte rw, byte lyr) {
            Clmn = clmn;
            Rw = rw;
            Lyr = lyr;
        }
    }
}