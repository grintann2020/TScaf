namespace T {

    public class PrgmMngr : Sngltn<PrgmMngr>, IMngr { // program manager

        public bool IsIntl { get { return _isIntl; } }
        private PrgmPrm _prgmPrm = null; // prime of program
        private IPrgm[] _iPrgmArry = null;
        private byte _eCrrnPrgm = 0;
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
            if (_iPrgmArry[_eCrrnPrgm] != null) {
                if (_eCrrnPrgm == ePrgm) {
                    return;
                }
                _iPrgmArry[_eCrrnPrgm].Trmn();
                _prgmPrm.Omt(_eCrrnPrgm);
            }
            _eCrrnPrgm = ePrgm;
            _prgmPrm.Prm(_eCrrnPrgm);
            _iPrgmArry[_eCrrnPrgm].Exct();
        }

        public void Exct(byte ePrgm, byte ePrcs) {
            if (_iPrgmArry[_eCrrnPrgm] != null) {
                if (_eCrrnPrgm == ePrgm) {
                    if (_iPrgmArry[_eCrrnPrgm].ECrrnPrcs == ePrcs) {
                        return;
                    } else {
                        _iPrgmArry[_eCrrnPrgm].Altr(ePrcs);
                        return;
                    }
                } else {
                    _iPrgmArry[_eCrrnPrgm].Trmn();
                    _prgmPrm.Omt(_eCrrnPrgm);
                }
            }
            _eCrrnPrgm = ePrgm;
            _prgmPrm.Prm(_eCrrnPrgm);
            _iPrgmArry[_eCrrnPrgm].Exct(ePrcs);
        }

        public void Trmn() { // terminate
            if (_iPrgmArry[_eCrrnPrgm] != null) {
                _iPrgmArry[_eCrrnPrgm].Trmn();
                _prgmPrm.Omt(_eCrrnPrgm);
            }
        }

        public void PrpUpdt() { // prop update
            _iPrgmArry[_eCrrnPrgm]?.PrpUpdt();
        }

        public IPrgm GtIPrgm() { // return current program
            return _iPrgmArry[_eCrrnPrgm];
        }

        public bool IsExct(byte ePrgm) { // return specific stage is implemented or not
            return _iPrgmArry[ePrgm] == null ? false : true;
        }

        public void Altr(byte ePrcs) {
            _iPrgmArry[_eCrrnPrgm].Altr(ePrcs);
        }
    }
}