using UnityEngine;

namespace T {

    public static class Tmr { // timer

        public static float StrTm { get { return _strTm; } } // get start time
        public static float Drt { // get duration time
            get {
                if (IsTm) {
                    return Time.time - _strTm - _psDrt;
                }
                return _psTm - _psDrt;
            }
        }
        public static float Elps { get { return Time.time - _strTm; } } // get elapsed time
        public static bool IsTm { get { return !float.IsNaN(_strTm) && float.IsNaN(_psTm); } } // get is timing or not
        private static System.Random _rnd = new System.Random();
        private static SCnt[] _sCntArr = null; // array of counter structs
        private static float _strTm = float.NaN;  // start time
        private static float _psTm = float.NaN; // pause time
        private static float _psDrt = 0.0f; // pause duration
        private static int _tmpId = 0; // temp identity for counter
        private static int _tmpIdx = 0; // temp index for counter

        public static void PrpUpd() { // prop update
            if (!IsTm) {
                return;
            }
            for (byte c = 0; c < _sCntArr.Length; c++) {
                _sCntArr[c].PrpUpd(Time.time);
            }
        }

        public static void Str() { // start
            Zr();
            _sCntArr = new SCnt[0];
            _strTm = Time.time;
        }

        public static void Ps() { // pause
            if (!float.IsNaN(_strTm)) {
                _psTm = Time.time;
            }
        }

        public static void Rsm() { // resume
            if (!float.IsNaN(_psTm)) {
                _psDrt += Time.time - _psTm;
                _psTm = float.NaN;
            }
        }

        public static void Zr() { // zero
            _sCntArr = null;
            _strTm = float.NaN;
            _psTm = float.NaN;
            _psDrt = 0.0f;
        }

        public static int RgstCnt(int strCnt, int fnlCnt, float intrTm, DAct lstCnt = null, DRct<int> echCnt = null) { // register counter struct
            RndId();
            _sCntArr = Arr.Add<SCnt>(_sCntArr, new SCnt(_tmpId, strCnt, fnlCnt, intrTm, lstCnt, echCnt));
            return _tmpId;
        }

        public static void RmvCnt(int id) { // remove counter struct
            _tmpIdx = CntIdx(id);
            if (_tmpIdx < 0) {
                return;
            }
            _sCntArr = Arr.Rmv<SCnt>(_sCntArr, _tmpIdx);
        }

        public static void StrCnt(int id) { // start counter
            _tmpIdx = CntIdx(id);
            if (!IsTm || _tmpIdx < 0) {
                return;
            }
            _sCntArr[_tmpIdx].Str(Time.time);
        }

        public static void PsCnt(int id) { // pause counter
            _tmpIdx = CntIdx(id);
            if (!IsTm || _tmpIdx < 0) {
                return;
            }
            _sCntArr[_tmpIdx].Ps(Time.time);
        }

        public static void RsmCnt(int id) { // resume counter
            _tmpIdx = CntIdx(id);
            if (!IsTm || _tmpIdx < 0) {
                return;
            }
            _sCntArr[_tmpIdx].Rsm(Time.time);
        }

        public static void ZrCnt(int id) { // zero counter
            _tmpIdx = CntIdx(id);
            if (_tmpIdx < 0) {
                return;
            }
            _sCntArr[_tmpIdx].Zr();
        }

        private static int CntIdx(int id) { // find an index of the counter in the array by identity
            for (int c = 0; c < _sCntArr.Length; c++) {
                if (id == _sCntArr[c].Id) {
                    return c;
                }
            }
            return -1;
        }

        private static void RndId() {
            do {
                _tmpId = _rnd.Next();
            } while (CntIdx(_tmpId) >= 0);
        }
    }
}