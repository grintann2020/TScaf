namespace T {

    public class Prgm {

        public enum ESqnc : byte { // enum of sequence
            Bgn = 0, // begin
            Updt = 1, // update
            End = 2 // end
        }

        public PrgmMngr Mngr { set { _mngr = value; } }
        public bool IsExct { get { return _isExct; } }
        protected DActn[][] _dPrcsArry = null; // an array of process
        protected PrgmMngr _mngr = null; // manager of program
        private byte _ePrcs = 0; // current enum of process
        private bool _isExct = false; // is executed or not

        public void Exct() { // execute
            if (_isExct) {
                return;
            }
            _ePrcs = 0;
            _isExct = true;
            _dPrcsArry[_ePrcs][(byte)ESqnc.Bgn]?.Invoke();
        }

        public void Exct(byte ePrcs) { // execute specific process by enum
            if (_isExct) {
                return;
            }
            _ePrcs = ePrcs;
            _isExct = true;
            _dPrcsArry[_ePrcs][(byte)ESqnc.Bgn]?.Invoke();
        }

        public void Trmn() { // terminate
            if (!_isExct) {
                return;
            }
            _dPrcsArry[_ePrcs][(byte)ESqnc.End]?.Invoke();
            _mngr = null;
            _ePrcs = 0;
            _isExct = false;
        }

        public void PrpUpdt() { // prop update
            if (!_isExct) {
                return;
            }
            _dPrcsArry[_ePrcs][(byte)ESqnc.Updt]?.Invoke();
        }

        public void Altr(byte ePrcs) { // alter
            if (!_isExct || _ePrcs == ePrcs) {
                return;
            }
            _dPrcsArry[_ePrcs][(byte)ESqnc.End]?.Invoke();
            _ePrcs = ePrcs;
            _dPrcsArry[_ePrcs][(byte)ESqnc.Bgn]?.Invoke();
        }
    }
}