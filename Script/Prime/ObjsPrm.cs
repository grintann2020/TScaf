namespace T {

    public class ObjsPrm { // objects prime
        
        public IObjs[] IObjsArr { get { return _iObjsArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (ObjsMng)value; } }
        protected IObjs[] _iObjsArr;
        protected DAct[] _dPrmArr;
        protected ObjsMng _mng;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iObjsArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iObjsArr[ePrm] = null;
        }
    }
}