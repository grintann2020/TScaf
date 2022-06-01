namespace T {

    public class Intractn { // interaction

        public enum EPrpr : byte { // enum of event properties
            Inpt = 0, // input
            Dtct = 1, // detect
            Actn = 2, // action
            DfltStts = 3, // default status
            Stts = 4 // status
        }

        public enum EStts : byte { // enum of switch
            Cls = 0, // close
            Opn = 1 // open
        } 

        public IntractnMngr Mngr { set { _mgr = value; } }
        public bool IsInstl { get { return _isInstl; } }  // return is installed or not
        protected IntractnMngr _mgr = null; // interaction manager
        protected DFnct<IInpt>[] _dIInptArry = null; // an array of input delegate
        protected DFnct<DActn>[] _dActnClssArry = null;
        protected DActn<object[]>[] _dActnsArry = null; // an array of actions delegate
        protected IInpt[] _iInptArry = null; // an array of input interface
        protected byte[][] _evntArry = null; // array of event
        private bool _isInstl = false;  // is installed or not

        public Intractn(DFnct<IInpt>[] dIInptArry) {
            _dIInptArry = dIInptArry;
        }

        public void Instl() { // install
            if (_isInstl || _dIInptArry == null || _dActnsArry == null || _iInptArry == null || _evntArry == null) {
                return;
            }
            _isInstl = true;
            for (byte e = 0; e < _evntArry.Length; e++) {
                _evntArry[e][(byte)EPrpr.Stts] = _evntArry[e][(byte)EPrpr.DfltStts];
            }
        }

        public void Unnstl() { // uninstall
            if (!_isInstl) {
                return;
            }
            _isInstl = false;
            _mgr = null;
            _dIInptArry = null;
            _dActnsArry = null;
            _iInptArry = null;
            _evntArry = null;
        }

        public void PrpUpdt() { // prop update
            if (!_isInstl) {
                return;
            }
            for (byte e = 0; e < _evntArry.Length; e++) {
                if (_iInptArry[_evntArry[e][(byte)EPrpr.Inpt]] != null && _evntArry[e][(byte)EPrpr.Stts] != 0) {
                    _iInptArry[_evntArry[e][(byte)EPrpr.Inpt]].DDtctArry[_evntArry[e][(byte)EPrpr.Dtct]]?.Invoke(_dActnsArry[_evntArry[e][(byte)EPrpr.Actn]]); // inputArryay[eInptut].DetectArryay[eDetect](actionArryay[eAction]);
                }
            }
        }

        public void DfltStts() { // default
            for (byte e = 0; e < _evntArry.Length; e++) {
                _evntArry[e][(byte)EPrpr.Stts] = _evntArry[e][(byte)EPrpr.DfltStts];
            }
        }

        public void Prmp(byte eEvnt) { // prompt
            if (_evntArry[eEvnt][(byte)EPrpr.Stts] == (byte)EStts.Cls) {
                _evntArry[eEvnt][(byte)EPrpr.Stts] = (byte)EStts.Opn;
            }
        }

        public void Dssd(byte eEvnt) { // dissuade
            if (_evntArry[eEvnt][(byte)EPrpr.Stts] == (byte)EStts.Opn) {
                _evntArry[eEvnt][(byte)EPrpr.Stts] = (byte)EStts.Cls;
            }
        } 
    }
}