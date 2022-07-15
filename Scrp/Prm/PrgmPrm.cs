namespace T {

    public class PrgmPrm { // program prime

        public IPrgm[] IPrgms { get { return _iPrgms; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (PrgmMngr)value; } }
        protected IPrgm[] _iPrgms; 
        protected DActn[] _dPrms;
        protected PrgmMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iPrgms[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iPrgms[ePrm] = null;
        }
    }
}