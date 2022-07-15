using UnityEngine;

namespace T {

    public class SpcPrm { // stage prime
        
        public ISpc[] ISpcs { get { return _iSpcs; } }
        public DActn[] DPrms { get { return _dPrms; } }
        public IMngr IMngr { set { _mngr = (SpcMngr)value; } }
        protected ISpc[] _iSpcs;
        protected DActn[] _dPrms;
        protected SpcMngr _mngr;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrms[ePrm] != null) {
                _dPrms[ePrm].Invoke();
                _iSpcs[ePrm].Mngr = _mngr;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iSpcs[ePrm] = null;
        }
    }
}