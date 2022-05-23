namespace T {

    public class TxtPrm { // text prime

        public IMngr IMngr { set { _mngr = (TxtMngr)value; } }
        public ITxt[] ITxtArry { get { return _iTxtArry; } }
        public byte[] ELnggArry { get { return _eLnggArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        protected TxtMngr _mngr;
        protected ITxt[] _iTxtArry;
        protected byte[] _eLnggArry;
        protected DActn[] _dPrmArry;

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
