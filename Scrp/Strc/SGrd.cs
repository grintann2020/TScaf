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

        public SGrd3(byte lyr, byte clmn, byte rw) {
            Lyr = lyr;
            Clmn = clmn;
            Rw = rw;
        }
    }
}