namespace T {

    public struct SCntr { // counter struct

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

        private DActn<int> _dEchCnt; // each count
        private DActn _dLstCnt; // final count
        private float _strtTm; // begin time
        private float _psTm; // pause time
        private float _psDrtn; // pause duration
        private float _intrTm; // interval time
        private float _updtTm; // step time
        private int _stpCnt; // step count
        private int _strtCnt; // start count
        private int _fnlCnt; // last count
        private int _crrnCnt; // current count
        private int _id; // index

        public SCntr(int id, int strtCnt, int fnlCnt, float intrTm, DActn dLstCnt = null, DActn<int> dEchCnt = null) {
            _id = id;
            _strtCnt = strtCnt;
            _fnlCnt = fnlCnt;
            _intrTm = intrTm;
            _dLstCnt = dLstCnt;
            _dEchCnt = dEchCnt;
            _strtTm = float.NaN;
            _psTm = float.NaN;
            _psDrtn = 0.0f;
            _updtTm = float.NaN;
            _stpCnt = (fnlCnt - strtCnt >= 0) ? 1 : -1;
            _crrnCnt = 0;
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
                // Debug.Log("crrnTm --> " + CrrnTm(tm) + ", updtTm --> " + _updtTm);
                _dEchCnt?.Invoke(_crrnCnt);
                if (_fnlCnt == _crrnCnt) {
                    _dLstCnt?.Invoke();
                    Zr();
                } else {
                    _updtTm = CrrnTm(tm);
                    _crrnCnt += _stpCnt;
                }
            }
        }

        private float CrrnTm(float tm) {
            return tm - _strtTm - _psDrtn;
        }
    }
}