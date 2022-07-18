using UnityEngine;

namespace T {

    public class SpcPrm { // stage prime
        
        public ISpc[] ISpcArr { get { return _iSpcArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (SpcMng)value; } }
        protected ISpc[] _iSpcArr;
        protected DAct[] _dPrmArr;
        protected SpcMng _mng;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iSpcArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iSpcArr[ePrm] = null;
        }
    }
}