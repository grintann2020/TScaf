namespace T {

    public class TxtPrm { // text prime
        
        public ITxt[] ITxtArry { get { return _iTxtArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        public IMngr IMngr { set { _mngr = (TxtMngr)value; } }
        public byte[] ELnggArry { get { return _eLnggArry; } }
        protected ITxt[] _iTxtArry;
        protected DActn[] _dPrmArry;
        protected TxtMngr _mngr;
        protected byte[] _eLnggArry;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iTxtArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iTxtArry[ePrm] = null;
        }
    }
}
