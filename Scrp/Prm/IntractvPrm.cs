namespace T {

    public class IntractnPrm { // interaction prime

        public IMngr IMngr { set { _mngr = (IntractnMngr)value; } } // get interaction manager
        public IIntractn[] IIntractnArry { get { return _iIntractnArry; } } // get the array of interaction interface
        public DActn[] DPrmArry { get { return _dPrmArry; } } // get the array of primes
        protected IntractnMngr _mngr; // interaction manager
        protected IIntractn[] _iIntractnArry; // an array of interaction interfaces
        protected DFnct<IInpt>[] _dIInptArry; 
        protected DActn[] _dPrmArry; // an array  of prime delegates
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iIntractnArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iIntractnArry[ePrm] = null;
        }
    }
}