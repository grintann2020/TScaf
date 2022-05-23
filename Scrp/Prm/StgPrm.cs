namespace T {

    public class StgPrm { // stage prime
        
        public IMngr IMngr { set { _mngr = (StgMngr)value; } }
        public IStg[] IStgArry { get { return _iStgArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        protected StgMngr _mngr;
        protected IStg[] _iStgArry;
        protected DActn[] _dPrmArry;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iStgArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iStgArry[ePrm] = null;
        }
    }
}