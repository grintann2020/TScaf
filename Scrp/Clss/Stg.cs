namespace T {

    public class Stg {

        public enum EOrdr : byte { // enum of order
            Run = 0, // run
            Stp = 1 // stp
        }

        public DActn[][] DPrgsArry { get { return _dPrgsArry; } } // get the array of progress, used by stage manager
        public StgMngr Mngr { set { _mngr = value; } }
        public byte ECrrnPrgs { get { return _eCrrnPrgs; } }
        public bool IsImpl { get { return _isImpl; } }
        protected DActn[][] _dPrgsArry = null; // an array of progress
        protected DFnct<bool>[] _dCndtArry = null; // an array of condition
        protected StgMngr _mngr = null; // registered stage manager
        protected byte[][][] _swtcArry = null; // an array of switch, which aim to define logic between condition and progress
        private byte _eCrrnPrgs = 0; // current enum of progress
        private bool _isImpl = false; // is implemented or not

        public void Impl() { // implement
            if (_isImpl || _dPrgsArry == null || _dCndtArry == null || _swtcArry == null) {
                return;
            }
            _isImpl = true;
            _eCrrnPrgs = 0;
            _dPrgsArry[_eCrrnPrgs][(byte)EOrdr.Run]?.Invoke();
        }

        public void Impl(byte ePrgs) { // implement progress by specific enum
            if (_isImpl || _dPrgsArry == null || _dPrgsArry[ePrgs] == null || _dCndtArry == null || _swtcArry == null) {
                return;
            }
            _isImpl = true;
            _eCrrnPrgs = ePrgs;
            _dPrgsArry[_eCrrnPrgs][(byte)EOrdr.Run]?.Invoke();
        }

        public void Abrt() { // abort
            if (!_isImpl) {
                return;
            }
            _isImpl = false;
            _dPrgsArry = null; // an array of progress
            _dCndtArry = null; // an array of condition
            _mngr = null; // registered stage manager
            _swtcArry = null; // an array of switch, which aim to define logic between condition and progress
            _eCrrnPrgs = 0;
        }

        public void PrpUpdt() { // prop update
            if (_isImpl == false) {
                return;
            }
            for (byte r = 0; r < _swtcArry[_eCrrnPrgs].Length; r++) {
                if (_dCndtArry[_swtcArry[_eCrrnPrgs][r][0]].Invoke()) {
                    _eCrrnPrgs = _swtcArry[_eCrrnPrgs][r][1];
                    _dPrgsArry[_eCrrnPrgs][(byte)EOrdr.Run]?.Invoke();
                }
            }
            _dPrgsArry[_eCrrnPrgs][(byte)EOrdr.Stp]?.Invoke();
        }
    }
}