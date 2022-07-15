namespace T {

    public class ArchMngr : Sngltn<ArchMngr>, IMngr { // data manager

        public bool IsIntl { get { return _isIntl; } }
        private IArch[] _iArchs = null;
        private ArchPrm _archPrm = null;
        private byte _eCrrnArch = 0;
        private bool _isIntl = false;

        public IArch GtIArch() {
            return _iArchs[_eCrrnArch];
        }

        public bool IsOpn(byte eArch) { // return is specific archive opened or not
            return _iArchs[eArch] == null ? false : true;
        }

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Cls();
            _archPrm = null;
            _iArchs = null;
        }

        public void Intl(IPrm iPrm) { // inithublize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _archPrm = (ArchPrm)iPrm;
            _iArchs = _archPrm.IArchs;
        }

        public void Opn(byte eArch) { // open
            if (_iArchs[_eCrrnArch] != null) {
                if (_eCrrnArch == eArch) {
                    return;
                }
                _iArchs[_eCrrnArch].Cls();
                _archPrm.Omt(_eCrrnArch);
            }
            _eCrrnArch = eArch;
            _archPrm.Prm(_eCrrnArch);
            _iArchs[_eCrrnArch].Opn();
        }
 
        public void Cls() { // close
            if (_iArchs[_eCrrnArch] != null) {
                _iArchs[_eCrrnArch].Cls();
                _archPrm.Omt(_eCrrnArch);
            }
        }
    }
}