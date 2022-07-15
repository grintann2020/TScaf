namespace T {

    public class IntractnMngr : Sngltn<IntractnMngr>, IMngr { // interaction manager

        public bool IsIntl { get { return _isIntl; } }
        private IntractnPrm _iaPrm = null; // prime of program
        private IIntractn[] _iIntractns = null;
        private byte _eCrrnIntractn = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Uninstl();
            _iaPrm = null;
            _iIntractns = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _iaPrm = (IntractnPrm)iPrm;
            _iIntractns = _iaPrm.IIntractns;
        }

        public void Instl(byte eIntractn) { // install
            if (_iIntractns[_eCrrnIntractn] != null) {
                if (_eCrrnIntractn == eIntractn) {
                    return;
                }
                _iIntractns[_eCrrnIntractn].Uninstl();
                _iaPrm.Omt(_eCrrnIntractn);
            }
            _eCrrnIntractn = eIntractn;
            _iaPrm.Prm(_eCrrnIntractn);
            _iIntractns[_eCrrnIntractn].Instl();
        }

        public void Uninstl() { // uninstall
            if (_iIntractns[_eCrrnIntractn] != null) {
                _iIntractns[_eCrrnIntractn].Uninstl();
                _iaPrm.Omt(_eCrrnIntractn);
            }
        }

        public void PrpUpdt() { // prop update
            _iIntractns[_eCrrnIntractn]?.PrpUpdt();
        }

        public IIntractn GtIIntractn() { // return current interaction
            return _iIntractns[_eCrrnIntractn];
        }

        public bool IsInst(byte eIntractn) { // return specific interaction is installed or not
            return _iIntractns[eIntractn] == null ? false : true;
        }

        public void Prmp(byte eEvt) { // prompt specific event by enum
            _iIntractns[_eCrrnIntractn]?.Prmp(eEvt);
        }

        public void Dssd(byte eEvt) { // dissuade  specific event by enum
            _iIntractns[_eCrrnIntractn].Dssd(eEvt);
        }

        public void Prmp(byte eIntractn, byte eEvt) { // prompt specific event in specific interaction by enum
            _iIntractns[eIntractn]?.Prmp(eEvt);
        }

        public void Dssd(byte eIntractn,byte eEvt) { // dissuade specific event in specific interaction by enum
            _iIntractns[eIntractn]?.Dssd(eEvt);
        }
    }
}