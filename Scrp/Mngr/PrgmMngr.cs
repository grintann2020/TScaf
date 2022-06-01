namespace T {

    public class PrgmMngr : Sngltn<PrgmMngr>, IMngr { // program manager

        public bool IsIntl { get { return _isIntl; } }
        private PrgmPrm _prgmPrm = null; // prime of program
        private IPrgm[] _iPrgmArry = null;
        private byte _ePrgm = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Trmn();
            _prgmPrm = null;
            _iPrgmArry = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _prgmPrm = (PrgmPrm)iPrm;
            _iPrgmArry = _prgmPrm.IPrgmArry;
        }

        public void Exct(byte ePrgm) { // excute specific program by enum
            if (_iPrgmArry[_ePrgm] != null) {
                if (_ePrgm == ePrgm) {
                    return;
                }
                _iPrgmArry[_ePrgm].Trmn();
                _prgmPrm.Omt(_ePrgm);
            }
            _ePrgm = ePrgm;
            _prgmPrm.Prm(_ePrgm);
            _iPrgmArry[_ePrgm].Exct();
        }

        public void Trmn() { // terminate
            if (_iPrgmArry[_ePrgm] != null) {
                _iPrgmArry[_ePrgm].Trmn();
                _prgmPrm.Omt(_ePrgm);
            }
        }

        public void PrpUpdt() { // prop update
            _iPrgmArry[_ePrgm]?.PrpUpdt();
        }

        public IPrgm IPrgm() { // return current program
            return _iPrgmArry[_ePrgm];
        }

        public bool IsExct(byte ePrgm) { // return specific stage is implemented or not
            return _iPrgmArry[ePrgm] == null ? false : true;
        }
    }
}