namespace T {

    public class IntractnPrm { // interaction prime

        public IMngr IMngr { set { _mngr = (IntractnMngr)value; } }
        public IIntractn[] IIntractnArry { get { return _iIntractnArry; } } // return array of interaction interface
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        protected IntractnMngr _mngr;
        protected IIntractn[] _iIntractnArry; // array of interaction interface
        protected IInpt[] _iInptArry; // array of input interface
        protected DActn[] _dPrmArry;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iIntractnArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iIntractnArry[ePrm] = null;
        }
    }
}