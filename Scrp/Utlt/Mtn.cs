using UnityEngine;

namespace T {

    public static class Mtn {

        private static System.Random _rndm = new System.Random();
        private static ITwn[] _iTwnArry = new ITwn[0];
        private static ITrck[] _tmpITrckArry = null;
        private static int _tmpId = 0; // temp identity
        private static int _tmpIndx = 0; // temp identity

        public static void PrpUpdt() {
            for (int t = 0; t < _iTwnArry.Length; t++) {
                _iTwnArry[t].PrpUpdt(Time.time);
            }
        }

        public static int PstnTwn(Transform trnsfrm, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, new ITrck[] { new SPstnTrck(trnsfrm, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static int PstnsTwn(Transform[] trnsfrmArry, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _tmpITrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < _tmpITrckArry.Length; t++) {
                _tmpITrckArry[t] = new SPstnTrck(trnsfrmArry[t], sTrgt, nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, _tmpITrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static int PstnsTwn(Transform[] trnsfrmArry, SVctr3[] sTrgtArry, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _tmpITrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < _tmpITrckArry.Length; t++) {
                _tmpITrckArry[t] = new SPstnTrck(trnsfrmArry[t], sTrgtArry[t], nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, _tmpITrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static int RttnTwn(Transform trnsfrm, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, new ITrck[] { new SRttnTrck(trnsfrm, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static int RttnsTwn(Transform[] trnsfrmArry, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _tmpITrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < _tmpITrckArry.Length; t++) {
                _tmpITrckArry[t] = new SRttnTrck(trnsfrmArry[t], sTrgt, nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, _tmpITrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static int RttnsTwn(Transform[] trnsfrmArry, SVctr3[] sTrgtArry, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _tmpITrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < _tmpITrckArry.Length; t++) {
                _tmpITrckArry[t] = new SRttnTrck(trnsfrmArry[t], sTrgtArry[t], nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, _tmpITrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static int SclTwn(Transform trnsfrm, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, new ITrck[] { new SSclTrck(trnsfrm, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static int SclsTwn(Transform[] trnsfrmArry, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _tmpITrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < _tmpITrckArry.Length; t++) {
                _tmpITrckArry[t] = new SSclTrck(trnsfrmArry[t], sTrgt, nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, _tmpITrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static int SclsTwn(Transform[] trnsfrmArry, SVctr3[] sTrgtArry, int nmbrOfIntrvl, float drtn, float dly = 0.0f, bool isExct = true, bool isDpsb = true) {
            RndmId();
            _tmpITrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < _tmpITrckArry.Length; t++) {
                _tmpITrckArry[t] = new SSclTrck(trnsfrmArry[t], sTrgtArry[t], nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STwn(_tmpId, _tmpITrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb));
            return _tmpId;
        }

        public static void RmvTwn(int id) {
            _tmpIndx = TwnIndx(id);
            if (_tmpIndx < 0) {
                return;
            }
            _iTwnArry = Arry.Rmv<ITwn>(_iTwnArry, _tmpIndx);
        }

        public static void StrtTwn(int id, bool isDly = true) { // start counter
            _tmpIndx = TwnIndx(id);
            if (_tmpIndx < 0) {
                return;
            }
            _iTwnArry[_tmpIndx].Strt(Time.time, isDly);
        }

        public static void PsTwn(int id) { // pause counter
            _tmpIndx = TwnIndx(id);
            if (_tmpIndx < 0) {
                return;
            }
            _iTwnArry[_tmpIndx].Ps(Time.time);
        }

        public static void RsmTwn(int id) { // resume counter
            _tmpIndx = TwnIndx(id);
            if (_tmpIndx < 0) {
                return;
            }
            _iTwnArry[_tmpIndx].Rsm(Time.time);
        }

        private static int TwnIndx(int id) { // find an index of the counter in the array by identity
            for (int t = 0; t < _iTwnArry.Length; t++) {
                if (id == _iTwnArry[t].Id) {
                    return t;
                }
            }
            return -1;
        }

        private static void RndmId() {
            do {
                _tmpId = _rndm.Next();
            } while (TwnIndx(_tmpId) >= 0);
        }
    }
}