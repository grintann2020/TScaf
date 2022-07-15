namespace T {

    public class SpcMngr : Sngltn<SpcMngr>, IMngr { // stage manager

        public bool IsIntl { get { return _isIntl; } } // get is initialized or not
        private ISpc[] _iSpcs = null; // an array of stage
        private SpcPrm _spcPrm = null;  // prime of stage
        private byte _eCrrnSpc = 0; // enum of stage
        private bool _isIntl = false; // is initialized or not

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Dcnst();
            _spcPrm = null;
            _iSpcs = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _spcPrm = (SpcPrm)iPrm;
            _iSpcs = _spcPrm.ISpcs;
        }

        public void Cnst(byte eSpc) { // implement specific stage by enum
            if (_iSpcs[_eCrrnSpc] != null) {
                _iSpcs[_eCrrnSpc].Dcnst();
                _spcPrm.Omt(_eCrrnSpc);
            }
            _eCrrnSpc = eSpc;
            _spcPrm.Prm(_eCrrnSpc);
            _iSpcs[_eCrrnSpc].Cnst(0);
        }

        public void Cnst(byte eSpc, byte eExst) { // implement specific stage by enum
            if (_iSpcs[_eCrrnSpc] != null) {
                _iSpcs[_eCrrnSpc].Dcnst();
                _spcPrm.Omt(_eCrrnSpc);
            }
            _eCrrnSpc = eSpc;
            _spcPrm.Prm(_eCrrnSpc);
            _iSpcs[_eCrrnSpc].Cnst(eExst);
        }

        public void Dcnst() { // abort current stage
            if (_iSpcs[_eCrrnSpc] != null) {
                _iSpcs[_eCrrnSpc].Dcnst();
                _spcPrm.Omt(_eCrrnSpc);
            }
        }

        public ISpc GtISpc() { // return current stage
            return _iSpcs[_eCrrnSpc];
        }

        public bool IsCnst(byte eSpc) { // return specific stage is implemented or not
            return _iSpcs[eSpc] == null ? false : true;
        }

        public SGrd3 GtSScl() {
            return _iSpcs[_eCrrnSpc].SScl;
        }

        public IUnt[][][] GtIUnts() {
            return _iSpcs[_eCrrnSpc].IUnts;
        }

        public IUnt[] GtIUntPrs() {
            return _iSpcs[_eCrrnSpc].IUntPrs;
        }

        public IUnt GtIUnt(int eIndx) {
            return _iSpcs[_eCrrnSpc].IUntPrs[eIndx];
        }

        public IUnt GtIUnt(byte lyr, byte clmn, byte rw) {
            return _iSpcs[_eCrrnSpc].IUnts[lyr][clmn][rw];
        }
    }
}