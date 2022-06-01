namespace T {

    public class IntractnMngr : Sngltn<IntractnMngr>, IMngr { // interaction manager

        public bool IsIntl { get { return _isIntl; } }
        private IntractnPrm _iaPrm = null; // prime of program
        private IIntractn[] _iIntractnArry = null;
        private byte _eIntractn = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Unnstl();
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
            if (_iIntractnArry[_eIntractn] != null) {
                if (_eIntractn == eIntractn) {
                    return;
                }
                _iIntractnArry[_eIntractn].Unnstl();
                _iaPrm.Omt(_eIntractn);
            }
            _eIntractn = eIntractn;
            _iaPrm.Prm(_eIntractn);
            _iIntractnArry[_eIntractn].Instl();
        }

        public void Unnstl() { // uninstall
            if (_iIntractnArry[_eIntractn] != null) {
                _iIntractnArry[_eIntractn].Unnstl();
                _iaPrm.Omt(_eIntractn);
            }
        }

        public void PrpUpdt() { // prop update
            _iIntractnArry[_eIntractn]?.PrpUpdt();
        }

        public IIntractn IIntractn() { // return current interaction
            return _iIntractnArry[_eIntractn];
        }

        public bool IsInst(byte eIntractn) { // return specific interaction is installed or not
            return _iIntractnArry[eIntractn] == null ? false : true;
        }

        public void Prmp(byte eEvt) { // prompt specific event by enum
            _iIntractnArry[_eIntractn]?.Prmp(eEvt);
        }

        public void Dssd(byte eEvt) { // dissuade  specific event by enum
            _iIntractnArry[_eIntractn].Dssd(eEvt);
        }

        public void Prmp(byte eIntractn, byte eEvt) { // prompt specific event in specific interaction by enum
            _iIntractnArry[eIntractn]?.Prmp(eEvt);
        }

        public void Dssd(byte eIntractn,byte eEvt) { // dissuade specific event in specific interaction by enum
            _iIntractnArry[eIntractn]?.Dssd(eEvt);
        }
    }
}