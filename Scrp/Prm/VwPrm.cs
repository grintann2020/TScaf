namespace T {

    public class VwPrm { // view prime

        public IVw[] IVws { get { return _iVws; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (VwMngr)value; } }
        protected IVw[] _iVws;
        protected DActn[] _dPrms;
        protected VwMngr _mngr;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iVws[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iVws[ePrm] = null;
        }
    }
}