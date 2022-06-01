namespace T {

    public class PrgmPrm { // program prime

        public IPrgm[] IPrgmArry { get { return _iPrgmArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        public IMngr IMngr { set { _mngr = (PrgmMngr)value; } }
        protected IPrgm[] _iPrgmArry; 
        protected DActn[] _dPrmArry;
        protected PrgmMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iPrgmArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iPrgmArry[ePrm] = null;
        }
    }
}