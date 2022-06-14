namespace T {

    public struct SCntr { // counter struct

        public int Id { get { return _id; } } // get identity
        public int Cnt { get { return _cnt; } } // get current count
        public bool IsCntng { get { return !float.IsNaN(_strtTm) && float.IsNaN(_psTm); } } // get is counting or not
        public bool IsEnd { get { return _cnt == _fnlCnt; } } // get is end or not
        private DActn<int> _dEchCnt; // each count
        private DActn _dLstCnt; // final count
        private float _strtTm; // begin time
        private float _psTm; // pause time
        private float _psDrtn; // pause duration
        private float _updtTm; // updt time
        private float _intrvl; // interval
        private int _id; // identity
        private int _strtCnt; // start count
        private int _fnlCnt; // last count
        private int _cnt; // current count
        private int _stpVl; // step value

        public SCntr(int id, int strtCnt, int fnlCnt, float intrvl, DActn dLstCnt = null, DActn<int> dEchCnt = null) {
            _id = id;
            _strtCnt = strtCnt;
            _fnlCnt = fnlCnt;
            _intrvl = intrvl;
            _dLstCnt = dLstCnt;
            _dEchCnt = dEchCnt;

            _strtTm = float.NaN;
            _psTm = float.NaN;
            _psDrtn = 0.0f;
            _updtTm = float.NaN;
            _cnt = 0;
            _stpVl = (fnlCnt - strtCnt >= 0) ? 1 : -1;
        }

        public void Strt(float tm) { // start
            _strtTm = tm;
            _updtTm = tm;
            _cnt = _strtCnt;
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
            _psTm = float.NaN;
            _psDrtn = 0.0f;
            _cnt = 0;
        }

        public void PrpUpdt(float tm) { // prop update with current time
            if (!IsCntng) {
                return;
            }

            if ((CrrnTm(tm) - _updtTm) >= _intrvl) {
                _updtTm = CrrnTm(tm);
                _cnt += _stpVl;
                _dEchCnt?.Invoke(_cnt);
                if (IsEnd) {
                    _dLstCnt?.Invoke();
                    Zr();
                }
            }
        }

        private float CrrnTm(float tm) { // return current time
            return tm - _strtTm - _psDrtn;
        }
    }
}