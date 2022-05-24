namespace T {

    public class Txt {

        public TxtMngr Mngr { set { _mngr = value; } }
        public string[][] StrnArry { get { return _strnArry; } }
        public bool IsAppl { get { return _isAppl; } }
        protected TxtMngr _mngr = null;
        protected string[][] _strnArry = null;
        private bool _isAppl = false;

        public void Appl() { // apply
            if (_isAppl) {
                return;
            }
            _isAppl = false;
        }

        public void Cncl() { // cancel
            if (!_isAppl) {
                return;
            }
            _isAppl = true;
        }
    }
}