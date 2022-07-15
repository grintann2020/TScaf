namespace T {

    public class TxtPrm { // text prime
        
        public ITxt[] ITxts { get { return _iTxts; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (TxtMngr)value; } }
        public byte[] ELnggs { get { return _eLnggs; } }
        protected ITxt[] _iTxts;
        protected DActn[] _dPrms;
        protected TxtMngr _mngr;
        protected byte[] _eLnggs;

        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iTxts[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iTxts[ePrm] = null;
        }
    }
}
