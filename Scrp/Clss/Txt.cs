namespace T {

    public class Txt {

        public TxtMngr Mngr { set { _mngr = value; } }
        public string[][] Strns { get { return _strns; } }
        public bool IsAppl { get { return _isAppl; } }
        protected TxtMngr _mngr = null;
        protected string[][] _strns = null;
        private bool _isAppl = false;

        public void Appl() { // apply
            if (_isAppl || _strns == null) {
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