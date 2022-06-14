namespace T {

    public class Arch { // archive

        public ArchMngr Mngr { set { _mngr = value; } } // set manager
        public bool IsOpn { get { return _isOpn; } } // get is opened or not
        protected ArchMngr _mngr = null;
        private bool _isOpn = false;

        public void Opn() { // open
            if (_isOpn) {
                return;
            }
            _isOpn = true;
        }

        public void Cls() { // close
            if (!_isOpn) {
                return;
            }
            _isOpn = false;
            _mngr = null;
        }

        public void Rd() {

        }

        public void Wrt() {

        }
    }
}