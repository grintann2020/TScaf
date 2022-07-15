namespace T {

    public struct SGrd2 {

        public int Clmn, Row;

        public SGrd2(int clmn, int row) {
            Clmn = clmn;
            Row = row;
        }
    }

    public struct SGrd3 {

        public int Clmn, Row, Lyr;

        public SGrd3(int lyr, int clmn, int row) {
            Lyr = lyr;
            Clmn = clmn;
            Row = row;
        }
    }
}