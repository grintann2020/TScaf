namespace T {

    public class DtPrm { // data prime
        
        public IDt[] IDtArr { get { return _iDtArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (DtMng)value; } }
        protected IDt[] _iDtArr;
        protected DAct[] _dPrmArr;
        protected DtMng _mng;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iDtArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iDtArr[ePrm] = null;
        }
    }
}