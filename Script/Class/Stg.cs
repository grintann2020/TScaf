namespace T {

    public class Stg {

        public enum EOrd : byte { // enum of order
            Run = 0, // run
            Stp = 1 // stp
        }

        public DAct[][] DPrgArr2 { get { return _dPrgArr2; } } // get the array of progress, used by stage manager
        public StgMng Mng { set { _mng = value; } }
        public byte ECrrPrg { get { return _eCrrPrg; } }
        public bool IsImp { get { return _isImp; } }
        protected DAct[][] _dPrgArr2 = null; // an array of progress
        protected DFnc<bool>[] _dCndArr = null; // an array of condition
        protected StgMng _mng = null; // registered stage manager
        protected byte[][][] _swtArr = null; // an array of switch, which aim to define logic between condition and progress
        private byte _eCrrPrg = 0; // current enum of progress
        private bool _isImp = false; // is implemented or not

        public void Imp() { // implement
            if (_isImp || _dPrgArr2 == null || _dCndArr == null || _swtArr == null) {
                return;
            }
            _isImp = true;
            _eCrrPrg = 0;
            _dPrgArr2[_eCrrPrg][(byte)EOrd.Run]?.Invoke();
        }

        public void Imp(byte ePrg) { // implement progress by specific enum
            if (_isImp || _dPrgArr2 == null || _dPrgArr2[ePrg] == null || _dCndArr == null || _swtArr == null) {
                return;
            }
            _isImp = true;
            _eCrrPrg = ePrg;
            _dPrgArr2[_eCrrPrg][(byte)EOrd.Run]?.Invoke();
        }

        public void Abr() { // abort
            if (!_isImp) {
                return;
            }
            _isImp = false;
            _dPrgArr2 = null; // an array of progress
            _dCndArr = null; // an array of condition
            _mng = null; // registered stage manager
            _swtArr = null; // an array of switch, which aim to define logic between condition and progress
            _eCrrPrg = 0;
        }

        public void PrpUpd() { // prop update
            if (_isImp == false) {
                return;
            }
            for (byte r = 0; r < _swtArr[_eCrrPrg].Length; r++) {
                if (_dCndArr[_swtArr[_eCrrPrg][r][0]].Invoke()) {
                    _eCrrPrg = _swtArr[_eCrrPrg][r][1];
                    _dPrgArr2[_eCrrPrg][(byte)EOrd.Run]?.Invoke();
                }
            }
            _dPrgArr2[_eCrrPrg][(byte)EOrd.Stp]?.Invoke();
        }
    }
}