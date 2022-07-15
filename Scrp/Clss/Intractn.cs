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
        protected DFnct<IInpt>[] _dIInpts = null; // an array of input delegate
        protected DActn<object[]>[] _dRactns = null; // an array of actions delegate
        protected IInpt[] _iInpts = null; // an array of input interface
        protected byte[][] _bhvrs = null; // array of event
        private bool _isInstl = false;  // is installed or not

        public Intractn(DFnct<IInpt>[] dIInpts) {
            _dIInpts = dIInpts;
        }

        public void Instl() { // install
            if (_isInstl || _dIInpts == null || _dRactns == null || _iInpts == null || _bhvrs == null) {
                return;
            }
            _isInstl = true;
            for (byte e = 0; e < _bhvrs.Length; e++) {
                _bhvrs[e][(byte)EPrpr.CrrnStts] = _bhvrs[e][(byte)EPrpr.DfltStts];
            }
        }

        public void Uninstl() { // uninstall
            if (!_isInstl) {
                return;
            }
            _isInstl = false;
            _mgr = null;
            _dIInpts = null;
            _dRactns = null;
            _iInpts = null;
            _bhvrs = null;
        }

        public void PrpUpdt() { // prop update
            if (!_isInstl) {
                return;
            }
            for (byte e = 0; e < _bhvrs.Length; e++) {
                if (_iInpts[_bhvrs[e][(byte)EPrpr.Inpt]] != null && _bhvrs[e][(byte)EPrpr.CrrnStts] != 0) {
                    _iInpts[_bhvrs[e][(byte)EPrpr.Inpt]].DDtcts[_bhvrs[e][(byte)EPrpr.Dtct]]?.Invoke(_dRactns[_bhvrs[e][(byte)EPrpr.Actn]]); // inputsay[eInptut].Detectsay[eDetect](actionsay[eAction]);
                }
            }
        }

        public void DfltStts() { // default
            for (byte e = 0; e < _bhvrs.Length; e++) {
                _bhvrs[e][(byte)EPrpr.CrrnStts] = _bhvrs[e][(byte)EPrpr.DfltStts];
            }
        }

        public void Prmp(byte eEvnt) { // prompt
            if (_bhvrs[eEvnt][(byte)EPrpr.CrrnStts] == (byte)EStts.Cls) {
                _bhvrs[eEvnt][(byte)EPrpr.CrrnStts] = (byte)EStts.Opn;
            }
        }

        public void Dssd(byte eEvnt) { // dissuade
            if (_bhvrs[eEvnt][(byte)EPrpr.CrrnStts] == (byte)EStts.Opn) {
                _bhvrs[eEvnt][(byte)EPrpr.CrrnStts] = (byte)EStts.Cls;
            }
        } 
    }
}