using UnityEngine;

namespace T {

    public static class Tmr {

        public static float StrtTm { get { return _strtTm; } } // get start time

        public static float CrrntTm { // get current time
            get {
                if (IsTmng) {
                    return Time.time - _strtTm - _psDrtn;
                }
                return _psTm - _psDrtn;
            }
        }

        public static float DrtnTm { // get duration time
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
        private static Cntr[] _sCntrArry = null; // array of counter structs
        private static float _strtTm = float.NaN;  // start time
        private static float _psTm = float.NaN; // pause time
        private static float _psDrtn = 0.0f; // pause duration
        private static int _tmpId = 0; // temp identity for counter

        public static void Strt() { // start
            Zr();
            _sCntrArry = new Cntr[0];
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
            do {
                _tmpId = _rndm.Next();
            } while (CntrIndx(_tmpId) >= 0);
            _sCntrArry = Arry.Add<Cntr>(_sCntrArry, new Cntr(_tmpId, strtCnt, fnlCnt, intrTm, lstCnt, echCnt));
            return _tmpId;
        }

        public static void RmvCntr(int id) { // remove counter struct
            if (CntrIndx(id) < 0) {
                return;
            }
            _sCntrArry = Arry.Rmv<Cntr>(_sCntrArry, (ushort)CntrIndx(id));
        }

        public static void StrtCntr(int id) { // start counter
            if (!IsTmng || CntrIndx(id) < 0) {
                return;
            }
            _sCntrArry[CntrIndx(id)].Strt(Time.time);
        }

        public static void PsCntr(int id) { // pause counter
            if (!IsTmng || CntrIndx(id) < 0) {
                return;
            }
            _sCntrArry[CntrIndx(id)].Ps(Time.time);
        }

        public static void RsmCntr(int id) { // resume counter
            if (!IsTmng || CntrIndx(id) < 0) {
                return;
            }
            _sCntrArry[CntrIndx(id)].Rsm(Time.time);
        }

        public static void ZrCntr(int id) { // zero counter
            if (CntrIndx(id) < 0) {
                return;
            }
            _sCntrArry[CntrIndx(id)].Zr();
        }

        public static void PrpUpdt() { // prop update
            if (!IsTmng) {
                return;
            }
            for (byte c = 0; c < _sCntrArry.Length; c++) {
                _sCntrArry[c].PrpUpdt(Time.time);
            }
        }

        private static int CntrIndx(int id) { // find an index of the counter in the array by identity
            for (int c = 0; c < _sCntrArry.Length; c++) {
                if (id == _sCntrArry[c].Id) {
                    return c;
                }
            }
            return -1;
        }
    }
}