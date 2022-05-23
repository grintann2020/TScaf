namespace T {

    public class Stg {

        public enum EOrdr : byte { // enum of order
            Rn = 0, // run
            Stp = 1 // stp
        }
        
        public StgMngr Mngr { set { _mngr = value; } }
        public bool IsImpl { get { return _isImpl; } }
        public DActn[][] DPrgsArry { get { return _dPrgsArry; } }
        protected StgMngr _mngr = null; // registered stage manager
        protected DActn[][] _dPrgsArry = null; // an array of progress
        protected DFnct<bool>[] _dCndtArry = null; // an array of condition
        protected byte[][][] _swtcArry = null; // an array of switch, which aim to define logic between condition and progress
        private byte _ePrgs = 0; // current enum of progress
        private bool _isImpl = false; // is implemented or not
 
        public void Impl() { // implement
            if (_isImpl) {
                return;
            }
            _isImpl = true;
            _dPrgsArry[_ePrgs][(byte)EOrdr.Rn]?.Invoke();
        }

        public void Impl(byte ePrgs) { // implement progress by specific enum
            if (_isImpl) {
                return;
            }
            _ePrgs = ePrgs;
            _isImpl = true;
            _dPrgsArry[_ePrgs][(byte)EOrdr.Rn]?.Invoke();
        }

        public void Abrt() { // abort
            if (!_isImpl) {
                return;
            }
            _ePrgs = 0;
            _isImpl = false;
        }

        public void PrpUpdt() { // prop update
            if (_isImpl == false) {
                return;
            }
            for (byte r = 0; r < _swtcArry[_ePrgs].Length; r++) {
                if (_dCndtArry[_swtcArry[_ePrgs][r][0]].Invoke()) {
                    _ePrgs = _swtcArry[_ePrgs][r][1];
                    _dPrgsArry[_ePrgs][(byte)EOrdr.Rn]?.Invoke();
                }
            }
            _dPrgsArry[_ePrgs][(byte)EOrdr.Stp]?.Invoke();
        }
    }
}