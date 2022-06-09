namespace T {

    public class DtPrm { // data prime
        
        public IDt[] IDtArry { get { return _iDtArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        public IMngr IMngr { set { _mngr = (DtMngr)value; } }
        protected IDt[] _iDtArry;
        protected DActn[] _dPrmArry;
        protected DtMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iDtArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iDtArry[ePrm] = null;
        }
    }
}