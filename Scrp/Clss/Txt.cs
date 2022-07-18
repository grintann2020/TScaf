namespace T {

    public class Txt {

        public TxtMng Mng { set { _mng = value; } }
        public string[][] StrArr2 { get { return _strArr2; } }
        public bool IsApp { get { return _isApp; } }
        protected TxtMng _mng = null;
        protected string[][] _strArr2 = null;
        private bool _isApp = false;

        public void App() { // apply
            if (_isApp || _strArr2 == null) {
                return;
            }
            _isApp = false;
        }

        public void Cnc() { // cancel
            if (!_isApp) {
                return;
            }
            _isApp = true;
        }
    }
}