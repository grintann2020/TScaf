namespace T {

    public class Cntr { // counter struct

        public int Id { get { return _id; } } // get identity

        public int CrrnCnt { get { return _crrnCnt; } } // get current count

        public bool IsCntng { // get is counting or not
            get {
                if (!float.IsNaN(_strtTm) && float.IsNaN(_psTm)) {
                    return true;
                }
                return false;
            }
        }

        private DActn<int> _dEchCnt = null; // each count
        private DActn _dLstCnt = null; // final count
        private float _strtTm = float.NaN; // begin time
        private float _psTm = float.NaN; // pause time
        private float _psDrtn = 0.0f; // pause duration
        private float _updtTm = float.NaN; // updt time
        private float _intrTm = float.NaN; // interval time
        private int _id = -1; // identity
        private int _strtCnt = 0; // start count
        private int _fnlCnt = 0; // last count
        private int _crrnCnt = 0; // current count
        private int _stpVl = 0; // step value
        
        public Cntr(int id, int strtCnt, int fnlCnt, float intrTm, DActn dLstCnt = null, DActn<int> dEchCnt = null) {
            _id = id;
            _strtCnt = strtCnt;
            _fnlCnt = fnlCnt;
            _intrTm = intrTm;
            _dLstCnt = dLstCnt;
            _dEchCnt = dEchCnt;
            _crrnCnt = 0;
            _stpVl = (fnlCnt - strtCnt >= 0) ? 1 : -1;
        }

        public void Strt(float tm) { // start
            _strtTm = tm;
            _updtTm = 0.0f;
            _crrnCnt = _strtCnt;
        }

        public void Ps(float tm) { // pause
            if (!float.IsNaN(_strtTm)) {
                _psTm = tm;
            }
        }

        public void Rsm(float tm) { // resume
            if (!float.IsNaN(_psTm)) {
                _psDrtn += tm - _psTm;
                _psTm = float.NaN;
            }
        }

        public void Zr() { // zero
            _strtTm = float.NaN;
            _updtTm = float.NaN;
            _crrnCnt = 0;
        }

        public void PrpUpdt(float tm) { // prop update with current time
            if (!IsCntng) {
                return;
            }
            if ((CrrnTm(tm) - _updtTm) >= _intrTm) {
                _dEchCnt?.Invoke(_crrnCnt);
                if (_fnlCnt == _crrnCnt) {
                    _dLstCnt?.Invoke();
                    Zr();
                } else {
                    _updtTm = CrrnTm(tm);
                    _crrnCnt += _stpVl;
                }
            }
        }

        private float CrrnTm(float tm) {
            return tm - _strtTm - _psDrtn;
        }
    }
}