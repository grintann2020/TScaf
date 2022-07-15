namespace T {

    public class Stg {

        public enum EOrdr : byte { // enum of order
            Run = 0, // run
            Stp = 1 // stp
        }

        public DActn[][] DPrgss { get { return _dPrgss; } } // get the array of progress, used by stage manager
        public StgMngr Mngr { set { _mngr = value; } }
        public byte ECrrnPrgs { get { return _eCrrnPrgs; } }
        public bool IsImpl { get { return _isImpl; } }
        protected DActn[][] _dPrgss = null; // an array of progress
        protected DFnct<bool>[] _dCndts = null; // an array of condition
        protected StgMngr _mngr = null; // registered stage manager
        protected byte[][][] _swtcs = null; // an array of switch, which aim to define logic between condition and progress
        private byte _eCrrnPrgs = 0; // current enum of progress
        private bool _isImpl = false; // is implemented or not

        public void Impl() { // implement
            if (_isImpl || _dPrgss == null || _dCndts == null || _swtcs == null) {
                return;
            }
            _isImpl = true;
            _eCrrnPrgs = 0;
            _dPrgss[_eCrrnPrgs][(byte)EOrdr.Run]?.Invoke();
        }

        public void Impl(byte ePrgs) { // implement progress by specific enum
            if (_isImpl || _dPrgss == null || _dPrgss[ePrgs] == null || _dCndts == null || _swtcs == null) {
                return;
            }
            _isImpl = true;
            _eCrrnPrgs = ePrgs;
            _dPrgss[_eCrrnPrgs][(byte)EOrdr.Run]?.Invoke();
        }

        public void Abrt() { // abort
            if (!_isImpl) {
                return;
            }
            _isImpl = false;
            _dPrgss = null; // an array of progress
            _dCndts = null; // an array of condition
            _mngr = null; // registered stage manager
            _swtcs = null; // an array of switch, which aim to define logic between condition and progress
            _eCrrnPrgs = 0;
        }

        public void PrpUpdt() { // prop update
            if (_isImpl == false) {
                return;
            }
            for (byte r = 0; r < _swtcs[_eCrrnPrgs].Length; r++) {
                if (_dCndts[_swtcs[_eCrrnPrgs][r][0]].Invoke()) {
                    _eCrrnPrgs = _swtcs[_eCrrnPrgs][r][1];
                    _dPrgss[_eCrrnPrgs][(byte)EOrdr.Run]?.Invoke();
                }
            }
            _dPrgss[_eCrrnPrgs][(byte)EOrdr.Stp]?.Invoke();
        }
    }
}