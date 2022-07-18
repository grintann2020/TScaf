namespace T {

    public class IaPrm { // interaction prime

        public IIa[] IIaArr { get { return _iIaArr; } } // get the array of interaction interface
        public DAct[] DPrmArr { get { return _dPrmArr; } } // get the array of primes
        public IMng IMng { set { _mng = (IaMng)value; } } // get interaction manager
        protected IIa[] _iIaArr; // an array of interaction interfaces
        protected DFnc<IInp>[] _dIInpArr; 
        protected DAct[] _dPrmArr; // an array  of prime delegates
        protected IaMng _mng; // interaction manager
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iIaArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iIaArr[ePrm] = null;
        }
    }
}