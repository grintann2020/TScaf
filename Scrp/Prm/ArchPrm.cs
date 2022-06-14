namespace T {

    public class ArchPrm { // archive prime
        
        public IArch[] IArchArry { get { return _iArchArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        public IMngr IMngr { set { _mngr = (ArchMngr)value; } }
        protected IArch[] _iArchArry;
        protected DActn[] _dPrmArry;
        protected ArchMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iArchArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iArchArry[ePrm] = null;
        }
    }
}