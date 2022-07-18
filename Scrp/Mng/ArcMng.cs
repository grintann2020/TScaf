namespace T {

    public class ArcMng : Sng<ArcMng>, IMng { // data manager

        public bool IsInt { get { return _isInt; } }
        private IArc[] _iArcArr = null;
        private ArcPrm _arcPrm = null;
        private byte _eCrrArc = 0;
        private bool _isInt = false;

        public IArc GtIArc() {
            return _iArcArr[_eCrrArc];
        }

        public bool IsOpn(byte eArc) { // return is specific archive opened or not
            return _iArcArr[eArc] == null ? false : true;
        }

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Cls();
            _arcPrm = null;
            _iArcArr = null;
        }

        public void Int(IPrm iPrm) { // inithublize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _arcPrm = (ArcPrm)iPrm;
            _iArcArr = _arcPrm.IArcArr;
        }

        public void Opn(byte eArc) { // open
            if (_iArcArr[_eCrrArc] != null) {
                if (_eCrrArc == eArc) {
                    return;
                }
                _iArcArr[_eCrrArc].Cls();
                _arcPrm.Omt(_eCrrArc);
            }
            _eCrrArc = eArc;
            _arcPrm.Prm(_eCrrArc);
            _iArcArr[_eCrrArc].Opn();
        }
 
        public void Cls() { // close
            if (_iArcArr[_eCrrArc] != null) {
                _iArcArr[_eCrrArc].Cls();
                _arcPrm.Omt(_eCrrArc);
            }
        }
    }
}