namespace T {

    public struct SCnt { // counter struct

        public int Id { get { return _id; } } // get identity
        public int Cnt { get { return _cnt; } } // get current count
        public bool IsCnt { get { return !float.IsNaN(_strTm) && float.IsNaN(_psTm); } } // get is counting or not
        public bool IsEnd { get { return _cnt == _fnlCnt; } } // get is end or not
        private DRct<int> _dEchCnt; // each count
        private DAct _dLstCnt; // final count
        private float _strTm; // begin time
        private float _psTm; // pause time
        private float _psDrt; // pause duration
        private float _updTm; // upd time
        private float _iv; // interval
        private int _id; // identity
        private int _strCnt; // start count
        private int _fnlCnt; // last count
        private int _cnt; // current count
        private int _stpVl; // step value

        public SCnt(int id, int strCnt, int fnlCnt, float iv, DAct dLstCnt = null, DRct<int> dEchCnt = null) {
            _id = id;
            _strCnt = strCnt;
            _fnlCnt = fnlCnt;
            _iv = iv;
            _dLstCnt = dLstCnt;
            _dEchCnt = dEchCnt;

            _strTm = float.NaN;
            _psTm = float.NaN;
            _psDrt = 0.0f;
            _updTm = float.NaN;
            _cnt = 0;
            _stpVl = (fnlCnt - strCnt >= 0) ? 1 : -1;
        }

        public void Str(float tm) { // start
            _strTm = tm;
            _updTm = tm;
            _cnt = _strCnt;
        }

        public void Ps(float tm) { // pause
            if (!float.IsNaN(_strTm)) {
                _psTm = tm;
            }
        }

        public void Rsm(float tm) { // resume
            if (!float.IsNaN(_psTm)) {
                _psDrt += tm - _psTm;
                _psTm = float.NaN;
            }
        }

        public void Zr() { // zero
            _strTm = float.NaN;
            _updTm = float.NaN;
            _psTm = float.NaN;
            _psDrt = 0.0f;
            _cnt = 0;
        }

        public void PrpUpd(float tm) { // prop update with current time
            if (!IsCnt) {
                return;
            }

            if ((CrrTm(tm) - _updTm) >= _iv) {
                _updTm = CrrTm(tm);
                _cnt += _stpVl;
                _dEchCnt?.Invoke(_cnt);
                if (IsEnd) {
                    _dLstCnt?.Invoke();
                    Zr();
                }
            }
        }

        private float CrrTm(float tm) { // return current time
            return tm - _strTm - _psDrt;
        }
    }
}