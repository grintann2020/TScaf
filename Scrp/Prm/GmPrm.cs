namespace T {

    public class GmPrm { // game prime

        public IMngr[] IMngrs { get { return _iMngrs; } }
        public IPrm[] IPrms { get { return _iPrms; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { get; set; }
        protected IMngr[] _iMngrs;
        protected IPrm[] _iPrms;
        protected DActn[] _dPrms;
        protected IMngr _iMngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iPrms[ePrm].IMngr = _iMngrs[ePrm];
            }
        }

        public void Omt(byte ePrm) { // omit
            _iPrms[ePrm] = null;
        }
    }
}