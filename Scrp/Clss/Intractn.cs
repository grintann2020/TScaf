namespace T {

    public class Intractn { // interaction

        public enum EPrpr : byte { // enum of event properties
            Inpt = 0, // input
            Dtct = 1, // detect
            Actn = 2, // action
            DfltStts = 3, // default status
            CrrnStts = 4 // status
        }

        public enum EStts : byte { // enum of switch
            Cls = 0, // close
            Opn = 1 // open
        } 

        public IntractnMngr Mngr { set { _mgr = value; } }
        public bool IsInstl { get { return _isInstl; } }  // return is installed or not
        protected IntractnMngr _mgr = null; // interaction manager
        protected DFnct<IInpt>[] _dIInptArry = null; // an array of input delegate
        protected DActn<object[]>[] _dRactnArry = null; // an array of actions delegate
        protected IInpt[] _iInptArry = null; // an array of input interface
        protected byte[][] _bhvrArry = null; // array of event
        private bool _isInstl = false;  // is installed or not

        public Intractn(DFnct<IInpt>[] dIInptArry) {
            _dIInptArry = dIInptArry;
        }

        public void Instl() { // install
            if (_isInstl || _dIInptArry == null || _dRactnArry == null || _iInptArry == null || _bhvrArry == null) {
                return;
            }
            _isInstl = true;
            for (byte e = 0; e < _bhvrArry.Length; e++) {
                _bhvrArry[e][(byte)EPrpr.CrrnStts] = _bhvrArry[e][(byte)EPrpr.DfltStts];
            }
        }

        public void Unnstl() { // uninstall
            if (!_isInstl) {
                return;
            }
            _isInstl = false;
            _mgr = null;
            _dIInptArry = null;
            _dRactnArry = null;
            _iInptArry = null;
            _bhvrArry = null;
        }

        public void PrpUpdt() { // prop update
            if (!_isInstl) {
                return;
            }
            for (byte e = 0; e < _bhvrArry.Length; e++) {
                if (_iInptArry[_bhvrArry[e][(byte)EPrpr.Inpt]] != null && _bhvrArry[e][(byte)EPrpr.CrrnStts] != 0) {
                    _iInptArry[_bhvrArry[e][(byte)EPrpr.Inpt]].DDtctArry[_bhvrArry[e][(byte)EPrpr.Dtct]]?.Invoke(_dRactnArry[_bhvrArry[e][(byte)EPrpr.Actn]]); // inputArryay[eInptut].DetectArryay[eDetect](actionArryay[eAction]);
                }
            }
        }

        public void DfltStts() { // default
            for (byte e = 0; e < _bhvrArry.Length; e++) {
                _bhvrArry[e][(byte)EPrpr.CrrnStts] = _bhvrArry[e][(byte)EPrpr.DfltStts];
            }
        }

        public void Prmp(byte eEvnt) { // prompt
            if (_bhvrArry[eEvnt][(byte)EPrpr.CrrnStts] == (byte)EStts.Cls) {
                _bhvrArry[eEvnt][(byte)EPrpr.CrrnStts] = (byte)EStts.Opn;
            }
        }

        public void Dssd(byte eEvnt) { // dissuade
            if (_bhvrArry[eEvnt][(byte)EPrpr.CrrnStts] == (byte)EStts.Opn) {
                _bhvrArry[eEvnt][(byte)EPrpr.CrrnStts] = (byte)EStts.Cls;
            }
        } 
    }
}