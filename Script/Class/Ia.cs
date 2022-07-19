namespace T {

    public class Ia { // interaction

        public enum EPrp : byte { // enum of event properties
            Inp = 0, // input
            Dtc = 1, // detect
            Act = 2, // action
            DflStt = 3, // default status
            CrrStt = 4 // status
        }

        public enum EStt : byte { // enum of switch
            Cls = 0, // close
            Opn = 1 // open
        } 

        public IaMng Mng { set { _mng = value; } }
        public bool IsInstl { get { return _isInstl; } }  // return is installed or not
        protected IaMng _mng = null; // interaction manager
        protected DFnc<IInp>[] _dIInpArr = null; // an array of input delegate
        protected DRct<object[]>[] _dRctArr = null; // an array of actions delegate
        protected IInp[] _iInpArr = null; // an array of input interface
        protected byte[][] _bhvArr = null; // array of behavior
        private bool _isInstl = false;  // is installed or not

        public Ia(DFnc<IInp>[] dIInpArr) {
            _dIInpArr = dIInpArr;
        }

        public void Instl() { // install
            if (_isInstl || _dIInpArr == null || _dRctArr == null || _iInpArr == null || _bhvArr == null) {
                return;
            }
            _isInstl = true;
            for (byte e = 0; e < _bhvArr.Length; e++) {
                _bhvArr[e][(byte)EPrp.CrrStt] = _bhvArr[e][(byte)EPrp.DflStt];
            }
        }

        public void Unnst() { // uninstall
            if (!_isInstl) {
                return;
            }
            _isInstl = false;
            _mng = null;
            _dIInpArr = null;
            _dRctArr = null;
            _iInpArr = null;
            _bhvArr = null;
        }

        public void PrpUpd() { // prop update
            if (!_isInstl) {
                return;
            }
            for (byte e = 0; e < _bhvArr.Length; e++) {
                if (_iInpArr[_bhvArr[e][(byte)EPrp.Inp]] != null && _bhvArr[e][(byte)EPrp.CrrStt] != 0) {
                    _iInpArr[_bhvArr[e][(byte)EPrp.Inp]].DDtcArr[_bhvArr[e][(byte)EPrp.Dtc]]?.Invoke(_dRctArr[_bhvArr[e][(byte)EPrp.Act]]); // inputsay[eInput].Detectsay[eDetect](actionsay[eAction]);
                }
            }
        }

        public void DflStt() { // default
            for (byte e = 0; e < _bhvArr.Length; e++) {
                _bhvArr[e][(byte)EPrp.CrrStt] = _bhvArr[e][(byte)EPrp.DflStt];
            }
        }

        public void Prmp(byte eEvn) { // prompt
            if (_bhvArr[eEvn][(byte)EPrp.CrrStt] == (byte)EStt.Cls) {
                _bhvArr[eEvn][(byte)EPrp.CrrStt] = (byte)EStt.Opn;
            }
        }

        public void Dssd(byte eEvn) { // dissuade
            if (_bhvArr[eEvn][(byte)EPrp.CrrStt] == (byte)EStt.Opn) {
                _bhvArr[eEvn][(byte)EPrp.CrrStt] = (byte)EStt.Cls;
            }
        } 
    }
}