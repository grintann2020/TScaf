namespace T {

    public class Intractn { // interaction

        public enum EEvntPrpr : byte { // enum of event properties
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
        protected IntractnMngr _mgr = null;
        protected IInpt[] _iInptArry = null; // array of input
        protected DActns<object>[] _dActnsArry; // array of actions delegate
        protected byte[][] _evntArry; // array of event
        private bool _isInstl = false;  // is installed or not

        public Intractn(IInpt[] iInptArry) {
            _iInptArry = iInptArry;
        }

        public void Instl() { // install
            if (_isInstl) {
                return;
            }
            for (byte e = 0; e < _evntArry.Length; e++) {
                _evntArry[e][(byte)EEvntPrpr.Stts] = _evntArry[e][(byte)EEvntPrpr.DfltStts];
            }
            _isInstl = true;
        }

        public void Unnstl() { // uninstall
            if (!_isInstl) {
                return;
            }
            for (byte e = 0; e < _evntArry.Length; e++) {
                _evntArry[e][(byte)EEvntPrpr.DfltStts] = 0;
            }
            _isInstl = false;
        }

        public void PrpUpdt() { // prop update
            if (!_isInstl) {
                return;
            }
            for (byte e = 0; e < _evntArry.Length; e++) {
                if (_iInptArry[_evntArry[e][(byte)EEvntPrpr.Inpt]] != null && _evntArry[e][(byte)EEvntPrpr.Stts] != 0) {
                    _iInptArry[_evntArry[e][(byte)EEvntPrpr.Inpt]].DDtctArry[_evntArry[e][(byte)EEvntPrpr.Dtct]](_dActnsArry[_evntArry[e][(byte)EEvntPrpr.Actn]]); // inputArryay[eInptut].DetectArryay[eDetect](actionArryay[eAction]);
                }
            }
        }

        public void DfltStts() { // default
            for (byte e = 0; e < _evntArry.Length; e++) {
                _evntArry[e][(byte)EEvntPrpr.Stts] = _evntArry[e][(byte)EEvntPrpr.DfltStts];
            }
        }

        public void Prmp(byte eEvnt) { // prompt
            if (_evntArry[eEvnt][(byte)EEvntPrpr.Stts] == (byte)EStts.Cls) {
                _evntArry[eEvnt][(byte)EEvntPrpr.Stts] = (byte)EStts.Opn;
            }
        }

        public void Dssd(byte eEvnt) { // dissuade
            if (_evntArry[eEvnt][(byte)EEvntPrpr.Stts] == (byte)EStts.Opn) {
                _evntArry[eEvnt][(byte)EEvntPrpr.Stts] = (byte)EStts.Cls;
            }
        }
    }
}