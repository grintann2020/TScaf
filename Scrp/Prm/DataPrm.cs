namespace T {

    public class DataPrm { // data prime
        
        public IData[] IDataArry { get { return _iDataArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        public IMngr IMngr { set { _mngr = (DataMngr)value; } }
        protected IData[] _iDataArry;
        protected DActn[] _dPrmArry;
        protected DataMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iDataArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iDataArry[ePrm] = null;
        }
    }
}