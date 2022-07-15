namespace T {

    public class StgPrm { // stage prime
        
        public IStg[] IStgs { get { return _iStgs; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (StgMngr)value; } }
        protected IStg[] _iStgs;
        protected DActn[] _dPrms;
        protected StgMngr _mngr;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iStgs[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iStgs[ePrm] = null;
        }
    }
}