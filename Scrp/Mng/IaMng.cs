namespace T {

    public class IaMng : Sng<IaMng>, IMng { // interaction manager

        public bool IsInt { get { return _isInt; } }
        private IaPrm _iaPrm = null; // prime of program
        private IIa[] _iIaArr = null;
        private byte _eCrrIa = 0;
        private bool _isInt = false;

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Unnst();
            _iaPrm = null;
            _iIaArr = null;
        }

        public void Int(IPrm iPrm) { // initialize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _iaPrm = (IaPrm)iPrm;
            _iIaArr = _iaPrm.IIaArr;
        }

        public void Instl(byte eIa) { // install
            if (_iIaArr[_eCrrIa] != null) {
                if (_eCrrIa == eIa) {
                    return;
                }
                _iIaArr[_eCrrIa].Unnst();
                _iaPrm.Omt(_eCrrIa);
            }
            _eCrrIa = eIa;
            _iaPrm.Prm(_eCrrIa);
            _iIaArr[_eCrrIa].Instl();
        }

        public void Unnst() { // uninstall
            if (_iIaArr[_eCrrIa] != null) {
                _iIaArr[_eCrrIa].Unnst();
                _iaPrm.Omt(_eCrrIa);
            }
        }

        public void PrpUpd() { // prop update
            _iIaArr[_eCrrIa]?.PrpUpd();
        }

        public IIa GtIIa() { // return current interaction
            return _iIaArr[_eCrrIa];
        }

        public bool IsIns(byte eIa) { // return specific interaction is installed or not
            return _iIaArr[eIa] == null ? false : true;
        }

        public void Prmp(byte eEvt) { // prompt specific event by enum
            _iIaArr[_eCrrIa]?.Prmp(eEvt);
        }

        public void Dss(byte eEvt) { // dissuade  specific event by enum
            _iIaArr[_eCrrIa].Dss(eEvt);
        }

        public void Prmp(byte eIa, byte eEvt) { // prompt specific event in specific interaction by enum
            _iIaArr[eIa]?.Prmp(eEvt);
        }

        public void Dss(byte eIa,byte eEvt) { // dissuade specific event in specific interaction by enum
            _iIaArr[eIa]?.Dss(eEvt);
        }
    }
}