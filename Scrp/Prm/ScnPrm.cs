namespace T {

    public class ScnPrm { // scene prime

        public IScn[] IScnArry { get { return _iScnArry; } } // get the array of scene interface
        public DActn[] DPrmArry { get { return _dPrmArry; } } // get the array of primes
        public IMngr IMngr { set { _mngr = (ScnMngr)value; } } // get interaction manager
        protected IScn[] _iScnArry; // an array of scene interfaces
        protected DActn[] _dPrmArry; // an array  of prime delegates
        protected ScnMngr _mngr; // interaction manager

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