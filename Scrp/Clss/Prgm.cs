namespace T {

    public class Prgm {

        public enum ESqnc : byte { // enum of sequence
            Bgn = 0, // begin
            Updt = 1, // update
            End = 2 // end
        }

        public PrgmMngr Mngr { set { _mngr = value; } }
        public byte ECrrnPrcs { get { return _eCrrnPrcs; } }
        public bool IsExct { get { return _isExct; } }
        protected DActn[][] _dPrcsArry = null; // an array of process
        protected PrgmMngr _mngr = null; // manager of program
        private byte _eCrrnPrcs = 0; // current enum of process
        private bool _isExct = false; // is executed or not

        public void Exct() { // execute
            if (_isExct || _dPrcsArry == null) {
                return;
            }
            _isExct = true;
            _eCrrnPrcs = 0;
            _dPrcsArry[_eCrrnPrcs][(byte)ESqnc.Bgn]?.Invoke();
        }

        public void Exct(byte ePrcs) { // execute specific process by enum
            if (_isExct || _dPrcsArry == null || _dPrcsArry[ePrcs] == null) {
                return;
            }
            _isExct = true;
            _eCrrnPrcs = ePrcs;
            _dPrcsArry[ePrcs][(byte)ESqnc.Bgn]?.Invoke();
        }

        public void Trmn() { // terminate
            if (!_isExct) {
                return;
            }
            _isExct = false;
            _mngr = null;
            _dPrcsArry[_eCrrnPrcs][(byte)ESqnc.End]?.Invoke();
            _eCrrnPrcs = 0;
            _dPrcsArry = null;
        }

        public void PrpUpdt() { // prop update
            if (!_isExct) {
                return;
            }
            _dPrcsArry[_eCrrnPrcs][(byte)ESqnc.Updt]?.Invoke();
        }

        public void Altr(byte ePrcs) { // alter
            if (!_isExct || _eCrrnPrcs == ePrcs) {
                return;
            }
            _dPrcsArry[_eCrrnPrcs][(byte)ESqnc.End]?.Invoke();
            _eCrrnPrcs = ePrcs;
            _dPrcsArry[_eCrrnPrcs][(byte)ESqnc.Bgn]?.Invoke();
        }
    }
}