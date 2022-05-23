namespace T {

    public class SpcMngr : Sngltn<SpcMngr> {

        private ISpc[] _iSpcArr;

        public void Bind(SpcPrm spcPrm) {
            _iSpcArr = spcPrm.ISpcArr;
        }

        public void Init() {

        }

        // public void Dfl(byte eSpc) {   
        //     _iSpcArr[eSpc].Dfl();
        // }

        // public byte[][][] DflArr(byte eSpc) {
        //     return _iSpcArr[eSpc].DflArr;
        // }

        // public byte[][][] CurArr(byte eSpc) {
        //     return _iSpcArr[eSpc].CurArr;
        // }

        // public void Alt(byte eSpc, byte eAlt) {
        //     _iSpcArr[eSpc].Alt(eAlt);
        // }

        public void Cnstr(byte eSpc, SCrdn3 ctr) {
            _iSpcArr[eSpc].Cnstr(ctr);
        }


        public void Dcstr(byte eSpc) {
            _iSpcArr[eSpc].Dcstr();
        }

        public ISpc Spc(byte eSpc) {
            return _iSpcArr[eSpc];
        }

        public bool IsCnstr(byte eSpc) {
            return _iSpcArr[eSpc].IsCnstr;
        }
    }
}