namespace T {

    public class VwPrm { // view prime

        public IVw[] IVws { get { return _iVwArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (VwMng)value; } }
        protected IVw[] _iVwArr;
        protected DAct[] _dPrmArr;
        protected VwMng _mng;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iVwArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iVwArr[ePrm] = null;
        }
    }
}