namespace T {

    public class TxtPrm { // text prime
        
        public ITxt[] ITxtArr { get { return _iTxtArr; } }
        public DAct[] DPrmArr { get { return _dPrmArr; } }
        public IMng IMng { set { _mng = (TxtMng)value; } }
        public byte[] ELngArr { get { return _eLngArr; } }
        protected ITxt[] _iTxtArr;
        protected DAct[] _dPrmArr;
        protected TxtMng _mng;
        protected byte[] _eLngArr;

        public void Prm(byte ePrm) { // prime
            if (_dPrmArr[ePrm] != null) {
                _dPrmArr[ePrm].Invoke();
                _iTxtArr[ePrm].Mng = _mng;
            }
        }

        public void Omt(byte ePrm) { // omit
            _iTxtArr[ePrm] = null;
        }
    }
}
