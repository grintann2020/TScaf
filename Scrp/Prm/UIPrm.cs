namespace T {

    public class UIPrm { // UI prime

        public IMngr IMngr { set { _mngr = (UIMngr)value; } }
        public IUI[] IUIArry { get { return _iUIArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        protected UIMngr _mngr;
        protected IUI[] _iUIArry;
        protected DActn[] _dPrmArry;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iUIArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iUIArry[ePrm] = null;
        }
    }
}