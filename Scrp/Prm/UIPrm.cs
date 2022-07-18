namespace T {

    public class UIPrm { // UI prime

        public IUI[] IUIArr { get { return _iUIArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (UIMng)value; } }
        protected IUI[] _iUIArr;
        protected DAct[] _dPrmArr;
        protected UIMng _mng;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iUIArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iUIArr[ePrm] = null;
        }
    }
}