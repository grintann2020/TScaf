namespace T {

    public class ArcPrm { // archive prime
        
        public IArc[] IArcArr { get { return _iArcArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (ArcMng)value; } }
        protected IArc[] _iArcArr;
        protected DAct[] _dPrmArr;
        protected ArcMng _mng;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iArcArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iArcArr[ePrm] = null;
        }
    }
}