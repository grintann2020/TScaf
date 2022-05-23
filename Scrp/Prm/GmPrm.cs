namespace T {

    public class GmPrm { // game prime

        public IMngr[] IMngrArry { get { return _iMngrArry; } }
        public IMngr IMngr { get; set; }
        public IPrm[] IPrmArry { get { return _iPrmArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        protected IMngr[] _iMngrArry;
        protected IMngr _iMngr;
        protected IPrm[] _iPrmArry;
        protected DActn[] _dPrmArry;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iPrmArry[ePrm].IMngr = _iMngrArry[ePrm];
            }
        }

        public void Omt(byte ePrm) { // omit
            _iPrmArry[ePrm] = null;
        }
    }
}