using UnityEngine;

namespace T {

    public static class Tmr { // timer

        public static float StrtTm { get { return _strtTm; } } // get start time
        public static float Drtn { // get duration time
            get {
                if (IsTmng) {
                    return Time.time - _strtTm - _psDrtn;
                }
                return _psTm - _psDrtn;
            }
        }
        public static float Elps { get { return Time.time - _strtTm; } } // get elapsed time
        public static bool IsTmng { get { return !float.IsNaN(_strtTm) && float.IsNaN(_psTm); } } // get is timing or not
        private static System.Random _rndm = new System.Random();
        private static SCntr[] _sCntrArry = null; // array of counter structs
        private static float _strtTm = float.NaN;  // start time
        private static float _psTm = float.NaN; // pause time
        private static float _psDrtn = 0.0f; // pause duration
        private static int _tmpId = 0; // temp identity for counter
        private static int _tmpIndx = 0; // temp index for counter

        public static void PrpUpdt() { // prop update
            if (!IsTmng) {
                return;
            }
            for (byte c = 0; c < _sCntrArry.Length; c++) {
                _sCntrArry[c].PrpUpdt(Time.time);
            }
        }

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

        public static int RgstCntr(int strtCnt, int fnlCnt, float intrTm, DActn lstCnt = null, DActn<int> echCnt = null) { // register counter struct
            RndmId();
            _sCntrArry = Arry.Add<SCntr>(_sCntrArry, new SCntr(_tmpId, strtCnt, fnlCnt, intrTm, lstCnt, echCnt));
            return _tmpId;
        }

        public static void RmvCntr(int id) { // remove counter struct
            _tmpIndx = CntrIndx(id);
            if (_tmpIndx < 0) {
                return;
            }
            _sCntrArry = Arry.Rmv<SCntr>(_sCntrArry, _tmpIndx);
        }

        public static void StrtCntr(int id) { // start counter
            _tmpIndx = CntrIndx(id);
            if (!IsTmng || _tmpIndx < 0) {
                return;
            }
            _sCntrArry[_tmpIndx].Strt(Time.time);
        }

        public static void PsCntr(int id) { // pause counter
            _tmpIndx = CntrIndx(id);
            if (!IsTmng || _tmpIndx < 0) {
                return;
            }
            _sCntrArry[_tmpIndx].Ps(Time.time);
        }

        public static void RsmCntr(int id) { // resume counter
            _tmpIndx = CntrIndx(id);
            if (!IsTmng || _tmpIndx < 0) {
                return;
            }
            _sCntrArry[_tmpIndx].Rsm(Time.time);
        }

        public static void ZrCntr(int id) { // zero counter
            _tmpIndx = CntrIndx(id);
            if (_tmpIndx < 0) {
                return;
            }
            _sCntrArry[_tmpIndx].Zr();
        }

        private static int CntrIndx(int id) { // find an index of the counter in the array by identity
            for (int c = 0; c < _sCntrArry.Length; c++) {
                if (id == _sCntrArry[c].Id) {
                    return c;
                }
            }
            return -1;
        }

        private static void RndmId() {
            do {
                _tmpId = _rndm.Next();
            } while (CntrIndx(_tmpId) >= 0);
        }
    }
}