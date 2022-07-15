namespace T {

    public class ScnPrm { // scene prime

        public IScn[] IScns { get { return _iScns; } } // get the array of scene interface
        public DActn[] DPrms { get { return _dPrms; } } // get the array of primes
        public IMngr IMngr { set { _mngr = (ScnMngr)value; } } // get interaction manager
        protected IScn[] _iScns; // an array of scene interfaces
        protected DActn[] _dPrms; // an array  of prime delegates
        protected ScnMngr _mngr; // interaction manager

        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iScns[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iScns[ePrm] = null;
        }
    }
}