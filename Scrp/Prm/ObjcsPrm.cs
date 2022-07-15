namespace T {

    public class ObjcsPrm { // objects prime
        
        public IObjcs[] IObjcss { get { return _iObjcss; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (ObjcsMngr)value; } }
        protected IObjcs[] _iObjcss;
        protected DActn[] _dPrms;
        protected ObjcsMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iObjcss[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iObjcss[ePrm] = null;
        }
    }
}