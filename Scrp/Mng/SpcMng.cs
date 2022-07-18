namespace T {

    public class SpcMng : Sng<SpcMng>, IMng { // stage manager

        public bool IsInt { get { return _isInt; } } // get is initialized or not
        public IUnt[][][] CrrIUntArr3{
            get {
                if (_iSpcArr[_eCrrSpc] == null) {
                    return default;
                }
                return _iSpcArr[_eCrrSpc].IUntArr3;
            }
        }
        public IUnt[] CrrIUntPrArr3{
            get {
                if (_iSpcArr[_eCrrSpc] == null) {
                    return default;
                }
                return _iSpcArr[_eCrrSpc].IUntPrArr;
            }
        }
        public ISpc CrrISpc { get { return _iSpcArr[_eCrrSpc]; } }
        public SGrd3 CrrSScl {
            get {
                if (_iSpcArr[_eCrrSpc] == null) {
                    return default;
                }
                return _iSpcArr[_eCrrSpc].SScl;
            }
        }
        private ISpc[] _iSpcArr = null; // an array of stage
        private SpcPrm _spcPrm = null;  // prime of stage
        private byte _eCrrSpc = 0; // enum of stage
        private bool _isInt = false; // is initialized or not

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Dcns();
            _spcPrm = null;
            _iSpcArr = null;
        }

        public void Int(IPrm iPrm) { // initialize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _spcPrm = (SpcPrm)iPrm;
            _iSpcArr = _spcPrm.ISpcArr;
        }

        public void Cnst(byte eSpc) { // construct specific stage by enum
            if (_iSpcArr[_eCrrSpc] != null) {
                _iSpcArr[_eCrrSpc].Dcns();
                _spcPrm.Omt(_eCrrSpc);
            }
            _eCrrSpc = eSpc;
            _spcPrm.Prm(_eCrrSpc);
            _iSpcArr[_eCrrSpc].Cnst(0);
        }

        public void Cnst(byte eSpc, byte eExs) { // implement specific stage by enum
            if (_iSpcArr[_eCrrSpc] != null) {
                _iSpcArr[_eCrrSpc].Dcns();
                _spcPrm.Omt(_eCrrSpc);
            }
            _eCrrSpc = eSpc;
            _spcPrm.Prm(_eCrrSpc);
            _iSpcArr[_eCrrSpc].Cnst(eExs);
        }

        public void Dcns() { // abort current stage
            if (_iSpcArr[_eCrrSpc] != null) {
                _iSpcArr[_eCrrSpc].Dcns();
                _spcPrm.Omt(_eCrrSpc);
            }
        }

        public bool IsCnst(byte eSpc) { // return specific stage is implemented or not
            return _iSpcArr[eSpc] == null ? false : true;
        }

        public IUnt GtIUnt(int eIdx) {
            return _iSpcArr[_eCrrSpc].IUntPrArr[eIdx];
        }

        public IUnt GtIUnt(byte lyr, byte clm, byte rw) {
            return _iSpcArr[_eCrrSpc].IUntArr3[lyr][clm][rw];
        }
    }
}