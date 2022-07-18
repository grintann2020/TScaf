namespace T {

    public class PrgMng : Sng<PrgMng>, IMng { // program manager

        public bool IsInt { get { return _isInt; } }
        private PrgPrm _prgPrm = null; // prime of program
        private IPrg[] _iPrgArr = null;
        private byte _eCrrPrg = 0;
        private bool _isInt = false;

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Trmn();
            _prgPrm = null;
            _iPrgArr = null;
        }

        public void Int(IPrm iPrm) { // initialize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _prgPrm = (PrgPrm)iPrm;
            _iPrgArr = _prgPrm.IPrgArr;
        }

        public void Exc(byte ePrg) { // excute specific program by enum
            if (_iPrgArr[_eCrrPrg] != null) {
                if (_eCrrPrg == ePrg) {
                    return;
                }
                _iPrgArr[_eCrrPrg].Trm();
                _prgPrm.Omt(_eCrrPrg);
            }
            _eCrrPrg = ePrg;
            _prgPrm.Prm(_eCrrPrg);
            _iPrgArr[_eCrrPrg].Exc();
        }

        public void Exc(byte ePrg, byte ePrc) {
            if (_iPrgArr[_eCrrPrg] != null) {
                if (_eCrrPrg == ePrg) {
                    if (_iPrgArr[_eCrrPrg].ECrrPrc == ePrc) {
                        return;
                    } else {
                        _iPrgArr[_eCrrPrg].Alt(ePrc);
                        return;
                    }
                } else {
                    _iPrgArr[_eCrrPrg].Trm();
                    _prgPrm.Omt(_eCrrPrg);
                }
            }
            _eCrrPrg = ePrg;
            _prgPrm.Prm(_eCrrPrg);
            _iPrgArr[_eCrrPrg].Exc(ePrc);
        }

        public void Trmn() { // terminate
            if (_iPrgArr[_eCrrPrg] != null) {
                _iPrgArr[_eCrrPrg].Trm();
                _prgPrm.Omt(_eCrrPrg);
            }
        }

        public void PrpUpd() { // prop update
            _iPrgArr[_eCrrPrg]?.PrpUpd();
        }

        public IPrg GtIPrg() { // return current program
            return _iPrgArr[_eCrrPrg];
        }

        public bool IsExc(byte ePrg) { // return specific stage is implemented or not
            return _iPrgArr[ePrg] == null ? false : true;
        }

        public void Altr(byte ePrc) {
            _iPrgArr[_eCrrPrg].Alt(ePrc);
        }
    }
}