namespace T {

    public class VwPrm { // view prime

        public IMngr IMngr { set { _mngr = (VwMngr)value; } }
        public IVw[] IVwArry { get { return _iVwArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        protected VwMngr _mngr;
        protected IVw[] _iVwArry;
        protected DActn[] _dPrmArry;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iVwArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iVwArry[ePrm] = null;
        }
    }
}