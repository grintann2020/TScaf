namespace T {

    public class ObjcsPrm { // objects prime
        
        public IObjcs[] IObjcsArry { get { return _iObjcsArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        public IMngr IMngr { set { _mngr = (ObjcsMngr)value; } }
        protected IObjcs[] _iObjcsArry;
        protected DActn[] _dPrmArry;
        protected ObjcsMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iObjcsArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iObjcsArry[ePrm] = null;
        }
    }
}