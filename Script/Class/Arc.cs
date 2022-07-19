namespace T {

    public class Arc { // archive

        public ArcMng Mng { set { _mng = value; } } // set manager
        public bool IsOpn { get { return _isOpn; } } // get is opened or not
        protected ArcMng _mng = null;
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
            _mng = null;
        }

        public void Rd() {

        }

        public void Wrt() {

        }
    }
}