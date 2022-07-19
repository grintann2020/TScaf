namespace T {

    public class Prg {

        public enum ESqn : byte { // enum of sequence
            Bgn = 0, // begin
            Upd = 1, // update
            End = 2 // end
        }

        public PrgMng Mng { set { _mng = value; } }
        public byte ECrrPrc { get { return _eCrrPrcArr; } }
        public bool IsExc { get { return _isExc; } }
        protected DAct[][] _dPrcArr = null; // an array of process
        protected PrgMng _mng = null; // manager of program
        private byte _eCrrPrcArr = 0; // current enum of process
        private bool _isExc = false; // is executed or not

        public void Exc() { // execute
            if (_isExc || _dPrcArr == null) {
                return;
            }
            _isExc = true;
            _eCrrPrcArr = 0;
            _dPrcArr[_eCrrPrcArr][(byte)ESqn.Bgn]?.Invoke();
        }

        public void Exc(byte ePrc) { // execute specific process by enum
            if (_isExc || _dPrcArr == null || _dPrcArr[ePrc] == null) {
                return;
            }
            _isExc = true;
            _eCrrPrcArr = ePrc;
            _dPrcArr[ePrc][(byte)ESqn.Bgn]?.Invoke();
        }

        public void Trm() { // terminate
            if (!_isExc) {
                return;
            }
            _isExc = false;
            _mng = null;
            _dPrcArr[_eCrrPrcArr][(byte)ESqn.End]?.Invoke();
            _eCrrPrcArr = 0;
            _dPrcArr = null;
        }

        public void PrpUpd() { // prop update
            if (!_isExc) {
                return;
            }
            _dPrcArr[_eCrrPrcArr][(byte)ESqn.Upd]?.Invoke();
        }

        public void Alt(byte ePrc) { // alter
            if (!_isExc || _eCrrPrcArr == ePrc) {
                return;
            }
            _dPrcArr[_eCrrPrcArr][(byte)ESqn.End]?.Invoke();
            _eCrrPrcArr = ePrc;
            _dPrcArr[_eCrrPrcArr][(byte)ESqn.Bgn]?.Invoke();
        }
    }
}