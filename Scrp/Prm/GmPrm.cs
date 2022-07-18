namespace T {

    public class GmPrm { // game prime

        public IMng[] IMngArr { get { return _iMngArr; } }
        public IPrm[] IPrmArr { get { return _iPrmArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { get; set; }
        protected IMng[] _iMngArr;
        protected IPrm[] _iPrmArr;
        protected DAct[] _dPrmArr;
        protected IMng _iMngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iPrmArr[ePrm].IMng = _iMngArr[ePrm];
            }
        }

        public void Omt(byte ePrm) { // omit
            _iPrmArr[ePrm] = null;
        }
    }
}