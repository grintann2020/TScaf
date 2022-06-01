using UnityEngine;

namespace T {

    public class SpcPrm { // stage prime
        
        public ISpc[] ISpcArry { get { return _iSpcArry; } }
        public DActn[] DPrmArry { get { return _dPrmArry; } }
        public IMngr IMngr { set { _mngr = (SpcMngr)value; } }
        protected ISpc[] _iSpcArry;
        protected DActn[] _dPrmArry;
        protected SpcMngr _mngr;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArry[ePrm] != null) {
                _dPrmArry[ePrm].Invoke();
                _iSpcArry[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iSpcArry[ePrm] = null;
        }
    }
}