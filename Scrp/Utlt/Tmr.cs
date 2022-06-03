using UnityEngine;

namespace T {

    public static class Tmr {

        public static float StrtTm { get { return _strtTm; } } // get start time

        public static float DrtnTm { // get duration time
            get {
                if (IsTmng) {
                    return Time.time - _strtTm - _psDrtn;
                }
                return _psTm - _psDrtn;
            }
        }

        public static float ElpsTm { // get elapsed time
            get {
                return Time.time - _strtTm;
            }
        }

        public static bool IsTmng { // get is timing or not
            get {
                if (!float.IsNaN(_strtTm) && float.IsNaN(_psTm)) {
                    return true;
                }
                return false;
            }
        }

        private static System.Random _rndm = new System.Random();
        private static SCntr[] _sCntrArry = null; // array of counter structs
        private static float _strtTm = float.NaN;  // start time
        private static float _psTm = float.NaN; // pause time
        private static float _psDrtn = 0.0f; // pause duration
        private static int _tmpId = 0; // temp identity for counter

        public static void Strt() { // start
            Zr();
            _sCntrArry = new SCntr[0];
            _strtTm = Time.time;
        }

        public static void Ps() { // pause
            if (!float.IsNaN(_strtTm)) {
                _psTm = Time.time;
            }
        }

        public static void Rsm() { // resume
            if (!float.IsNaN(_psTm)) {
                _psDrtn += Time.time - _psTm;
                _psTm = float.NaN;
            }
        }

        public static void Zr() { // zero
            _sCntrArry = null;
            _strtTm = float.NaN;
            _psTm = float.NaN;
            _psDrtn = 0.0f;
        }

        public static int RgstTmr(int strtCnt, int fnlCnt, float intrTm, DActn lstCnt = null, DActn<int> echCnt = null) { // register counter struct
            do {
                _tmpId = _rndm.Next();
            } while (TmrIndx(_tmpId) >= 0);
            _sCntrArry = Arry.Add<SCntr>(_sCntrArry, new SCntr(_tmpId, strtCnt, fnlCnt, intrTm, lstCnt, echCnt));
            return _tmpId;
        }

        public static void RmvTmr(int id) { // remove counter struct
            if (TmrIndx(id) < 0) {
                return;
            }
            _sCntrArry = Arry.Rmv<SCntr>(_sCntrArry, TmrIndx(id));
        }

        public static void PrpUpdt() { // prop update
            if (!IsTmng) {
                return;
            }
            for (byte c = 0; c < _sCntrArry.Length; c++) {
                _sCntrArry[c].PrpUpdt(Time.time);
            }
        }

        public static void StrtTmr(int id) { // start counter
            if (!IsTmng || TmrIndx(id) < 0) {
                return;
            }
            _sCntrArry[TmrIndx(id)].Strt(Time.time);
        }

        public static void PsTmr(int id) { // pause counter
            if (!IsTmng || TmrIndx(id) < 0) {
                return;
            }
            _sCntrArry[TmrIndx(id)].Ps(Time.time);
        }

        public static void RsmTmr(int id) { // resume counter
            if (!IsTmng || TmrIndx(id) < 0) {
                return;
            }
            _sCntrArry[TmrIndx(id)].Rsm(Time.time);
        }

        public static void ZrTmr(int id) { // zero counter
            if (TmrIndx(id) < 0) {
                return;
            }
            _sCntrArry[TmrIndx(id)].Zr();
        }

        private static int TmrIndx(int id) { // find an index of the counter in the array by identity
            for (int c = 0; c < _sCntrArry.Length; c++) {
                if (id == _sCntrArry[c].Id) {
                    return c;
                }
            }
            return -1;
        }
    }
}