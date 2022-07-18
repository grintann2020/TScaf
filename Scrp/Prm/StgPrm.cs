namespace T {

    public class StgPrm { // stage prime
        
        public IStg[] IStgArr { get { return _iStgArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (StgMng)value; } }
        protected IStg[] _iStgArr;
        protected DAct[] _dPrmArr;
        protected StgMng _mng;
        
        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iStgArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iStgArr[ePrm] = null;
        }
    }
}