namespace T {

    public class ArchPrm { // archive prime
        
        public IArch[] IArchs { get { return _iArchs; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (ArchMngr)value; } }
        protected IArch[] _iArchs;
        protected DActn[] _dPrms;
        protected ArchMngr _mngr;

        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iArchs[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iArchs[ePrm] = null;
        }
    }
}