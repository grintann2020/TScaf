namespace T {

    public class PrgPrm { // program prime

        public IPrg[] IPrgArr { get { return _iPrgArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (PrgMng)value; } }
        protected IPrg[] _iPrgArr; 
        protected DAct[] _dPrmArr;
        protected PrgMng _mng;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iPrgArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iPrgArr[ePrm] = null;
        }
    }
}