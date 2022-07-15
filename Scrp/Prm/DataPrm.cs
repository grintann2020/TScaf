namespace T {

    public class DataPrm { // data prime
        
        public IData[] IDatas { get { return _iDatas; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (DataMngr)value; } }
        protected IData[] _iDatas;
        protected DActn[] _dPrms;
        protected DataMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iDatas[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iDatas[ePrm] = null;
        }
    }
}