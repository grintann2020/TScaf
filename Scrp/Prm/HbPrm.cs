namespace T {

    public class HbPrm { // hub prime
        
        public IMngr IMngr { set { _mngr = (HbMngr)value; } }
        public IHb[] IHbArry { get { return _iHbArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        protected HbMngr _mngr;
        protected IHb[] _iHbArry;
        protected DActn[] _dPrmArry;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iHbArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iHbArry[ePrm] = null;
        }
    }
}