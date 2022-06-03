using UnityEngine;

namespace T {

    public enum ETrnsfrmPrpr {
        Pstn,
        Rttn,
        Scl
    }

    public struct SMltpTwn {
        // private STwn[] _sTwnArry;
        private bool _isPstn;
        private bool _isRttn;
        private bool _isScl;

        public SMltpTwn(bool isPstn = true, bool isRttn = true, bool isScl = true) {
            _isPstn = isPstn;
            _isRttn = isRttn;
            _isScl = isScl;
        }
    }

    public static class Mtn {

        private static System.Random _rndm = new System.Random();
        private static STwn[] _sTwnArry = null;
        private static int _tmpId = 0; // temp identity for counter

        public static void DoTwn(Transform trnsfrm, byte ePrpr, SVctr3 sOrgn, SVctr3 sTrgt, int intrvls, float drnTm, float dlyTm = 0.0f) {
            do {
                _tmpId = _rndm.Next();
            } while (TwnIndx(_tmpId) >= 0);
            _sTwnArry = Arry.Add<STwn>(_sTwnArry, new STwn(_tmpId, trnsfrm, ePrpr, sOrgn, sTrgt, intrvls, drnTm, dlyTm, Time.time));
        }

        public static int RgstTwn(Transform trnsfrm, byte ePrpr, SVctr3 sOrgn, SVctr3 sTrgt, int intrvls, float drnTm, float dlyTm = 0.0f) {
            do {
                _tmpId = _rndm.Next();
            } while (TwnIndx(_tmpId) >= 0);
            _sTwnArry = Arry.Add<STwn>(_sTwnArry, new STwn(_tmpId, trnsfrm, ePrpr, sOrgn, sTrgt, intrvls, drnTm, dlyTm, Time.time, false));
            return _tmpId;
        }

        public static void RmvTwn(int id) {
            if (TwnIndx(id) < 0) {
                return;
            }
            _sTwnArry = Arry.Rmv<STwn>(_sTwnArry, TwnIndx(id));
        }

        public static void StrtTwn(int id) { // start counter
            if (TwnIndx(id) < 0) {
                return;
            }
            _sTwnArry[TwnIndx(id)].Strt(Time.time);
        }

        public static void PsTwn(int id) { // pause counter
            if (TwnIndx(id) < 0) {
                return;
            }
            _sTwnArry[TwnIndx(id)].Ps(Time.time);
        }

        public static void RsmTwn(int id) { // resume counter
            if (TwnIndx(id) < 0) {
                return;
            }
            _sTwnArry[TwnIndx(id)].Rsm(Time.time);
        }

        public static void PrpUpdt() {
            for (int t = 0; t < _sTwnArry.Length; t++) {
                _sTwnArry[t].PrpUpdt(Time.time);
            }
        }

        private static int TwnIndx(int id) { // find an index of the counter in the array by identity
            for (int t = 0; t < _sTwnArry.Length; t++) {
                if (id == _sTwnArry[t].Id) {
                    return t;
                }
            }
            return -1;
        }

        

        // public static SVctr3[] Trck(SVctr3 a, SVctr3 b, int s) { // Trck
        //     SVctr3[] arr = new SVctr3[s];
        //     float x = (b.X - a.X) / s;
        //     float y = (b.Y - a.Y) / s;
        //     float z = (b.Z - a.Z) / s;
        //     for (int c = 0; c < s; c++) {
        //         arr[c] = new SVctr3((x * c) + a.X, (y * c) + a.Y, (z * c) + a.Z);
        //     }
        //     return arr;
        // }

        public static SVctr3[][] Trck2(SVctr3 a1, SVctr3 b1, SVctr3 a2, SVctr3 b2, int s) {  // Trk
            SVctr3[][] arr = new SVctr3[s][];
            float x1 = (b1.X - a1.X) / s;
            float y1 = (b1.Y - a1.Y) / s;
            float z1 = (b1.Z - a1.Z) / s;
            float x2 = (b2.X - a2.X) / s;
            float y2 = (b2.Y - a2.Y) / s;
            float z2 = (b2.Z - a2.Z) / s;
            for (int c = 0; c < s; c++) {
                arr[c] = new SVctr3[2] {
                    new SVctr3((x1 * c) + a1.X, (y1 * c) + a1.Y, (z1 * c) + a1.Z),
                    new SVctr3((x2 * c) + a2.X, (y2 * c) + a2.Y, (z2 * c) + a2.Z)
                };
            }
            return arr;
        }
    }
}