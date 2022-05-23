namespace T {

    public class ScnPrm { // scene prime

        public IMngr IMngr { set { _mngr = (ScnMngr)value; } }
        public IScn[] IScnArry { get { return _iScnArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        protected ScnMngr _mngr;
        protected IScn[] _iScnArry;
        protected DActn[] _dPrmArry;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iScnArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iScnArry[ePrm] = null;
        }
    }
}