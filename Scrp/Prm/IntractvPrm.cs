namespace T {

    public class IntractnPrm { // interaction prime

        public IIntractn[] IIntractns { get { return _iIntractns; } } // get the array of interaction interface
        public DActn[] DPrms { get { return _dPrms; } } // get the array of primes
        public IMngr IMngr { set { _mngr = (IntractnMngr)value; } } // get interaction manager
        protected IIntractn[] _iIntractns; // an array of interaction interfaces
        protected DFnct<IInpt>[] _dIInpts; 
        protected DActn[] _dPrms; // an array  of prime delegates
        protected IntractnMngr _mngr; // interaction manager
        
        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iIntractns[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iIntractns[ePrm] = null;
        }
    }
}