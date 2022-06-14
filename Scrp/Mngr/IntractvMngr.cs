namespace T {

    public class IntractnMngr : Sngltn<IntractnMngr>, IMngr { // interaction manager

        public bool IsIntl { get { return _isIntl; } }
        private IntractnPrm _iaPrm = null; // prime of program
        private IIntractn[] _iIntractnArry = null;
        private byte _eCrrnIntractn = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Uninstl();
            _iaPrm = null;
            _iIntractnArry = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _iaPrm = (IntractnPrm)iPrm;
            _iIntractnArry = _iaPrm.IIntractnArry;
        }

        public void Instl(byte eIntractn) { // install
            if (_iIntractnArry[_eCrrnIntractn] != null) {
                if (_eCrrnIntractn == eIntractn) {
                    return;
                }
                _iIntractnArry[_eCrrnIntractn].Uninstl();
                _iaPrm.Omt(_eCrrnIntractn);
            }
            _eCrrnIntractn = eIntractn;
            _iaPrm.Prm(_eCrrnIntractn);
            _iIntractnArry[_eCrrnIntractn].Instl();
        }

        public void Uninstl() { // uninstall
            if (_iIntractnArry[_eCrrnIntractn] != null) {
                _iIntractnArry[_eCrrnIntractn].Uninstl();
                _iaPrm.Omt(_eCrrnIntractn);
            }
        }

        public void PrpUpdt() { // prop update
            _iIntractnArry[_eCrrnIntractn]?.PrpUpdt();
        }

        public IIntractn GtIIntractn() { // return current interaction
            return _iIntractnArry[_eCrrnIntractn];
        }

        public bool IsInst(byte eIntractn) { // return specific interaction is installed or not
            return _iIntractnArry[eIntractn] == null ? false : true;
        }

        public void Prmp(byte eEvt) { // prompt specific event by enum
            _iIntractnArry[_eCrrnIntractn]?.Prmp(eEvt);
        }

        public void Dssd(byte eEvt) { // dissuade  specific event by enum
            _iIntractnArry[_eCrrnIntractn].Dssd(eEvt);
        }

        public void Prmp(byte eIntractn, byte eEvt) { // prompt specific event in specific interaction by enum
            _iIntractnArry[eIntractn]?.Prmp(eEvt);
        }

        public void Dssd(byte eIntractn,byte eEvt) { // dissuade specific event in specific interaction by enum
            _iIntractnArry[eIntractn]?.Dssd(eEvt);
        }
    }
}