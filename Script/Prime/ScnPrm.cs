namespace T {

    public class ScnPrm { // scene prime

        public IScn[] IScnArr { get { return _iScnArr; } } // get the array of scene interface
        public DAct[] DPrmArr { get { return _dPrmArr; } } // get the array of primes
        public IMng IMng { set { _mng = (ScnMng)value; } } // get interaction manager
        protected IScn[] _iScnArr; // an array of scene interfaces
        protected DAct[] _dPrmArr; // an array  of prime delegates
        protected ScnMng _mng; // interaction manager

        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iScnArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iScnArr[ePrm] = null;
        }
    }
}