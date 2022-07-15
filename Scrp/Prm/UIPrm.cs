namespace T {

    public class UIPrm { // UI prime

        public IUI[] IUIs { get { return _iUIs; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (UIMngr)value; } }
        protected IUI[] _iUIs;
        protected DActn[] _dPrms;
        protected UIMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iUIs[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iUIs[ePrm] = null;
        }
    }
}