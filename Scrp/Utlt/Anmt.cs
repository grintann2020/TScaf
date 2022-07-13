using UnityEngine;

namespace T {

    public static class Anmt {

        private static ITwn[] _iTwnArry = new ITwn[0];
        private static int _id = 0;

        public static void PrpUpdt() {
            for (int t = 0; t < _iTwnArry.Length; t++) {
                _iTwnArry[t].PrpUpdt(Time.time);
            }
        }

        public static int PstnTwn(Transform trnsfrm, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, DActn dEnd = null) {
            int id = GtId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, new ITrck[] { new SPstnTrck(trnsfrm, sOrgn, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, 0.0f, Time.time, true, true, dEnd));
            return id;
        }

        public static int PstnTwn(Transform trnsfrm, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, new ITrck[] { new SPstnTrck(trnsfrm, sOrgn, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int PstnTwn(Transform[] trnsfrmArry, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            ITrck[] iTrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < iTrckArry.Length; t++) {
                iTrckArry[t] = new SPstnTrck(trnsfrmArry[t], sOrgn, sTrgt, nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, iTrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int PstnTwn(Transform[] trnsfrmArry, SVctr3 sOrgn, SVctr3[] sTrgtArry, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            ITrck[] iTrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < iTrckArry.Length; t++) {
                iTrckArry[t] = new SPstnTrck(trnsfrmArry[t], sOrgn, sTrgtArry[t], nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, iTrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int RttnTwn(Transform trnsfrm, Quaternion sOrgn, Quaternion sTrgt, int nmbrOfIntrvl, float drtn, DActn dEnd = null) {
            int id = GtId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, new ITrck[] { new SRttnTrck(trnsfrm, sOrgn, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, 0.0f, Time.time, true, true, dEnd));
            return id;
        }

        public static int RttnTwn(Transform trnsfrm, Quaternion sOrgn, Quaternion sTrgt, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, new ITrck[] { new SRttnTrck(trnsfrm, sOrgn, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int RttnTwn(Transform[] trnsfrmArry, Quaternion sOrgn, Quaternion sTrgt, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            ITrck[] iTrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < iTrckArry.Length; t++) {
                iTrckArry[t] = new SRttnTrck(trnsfrmArry[t], sOrgn, sTrgt, nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, iTrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int RttnTwn(Transform[] trnsfrmArry, Quaternion sOrgn, Quaternion[] sTrgtArry, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            ITrck[] iTrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < iTrckArry.Length; t++) {
                iTrckArry[t] = new SRttnTrck(trnsfrmArry[t], sOrgn, sTrgtArry[t], nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, iTrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int SclTwn(Transform trnsfrm, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, DActn dEnd = null) {
            int id = GtId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, new ITrck[] { new SSclTrck(trnsfrm, sOrgn, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, 0.0f, Time.time, true, true, dEnd));
            return id;
        }

        public static int SclTwn(Transform trnsfrm, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, new ITrck[] { new SSclTrck(trnsfrm, sOrgn, sTrgt, nmbrOfIntrvl) }, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int SclTwn(Transform[] trnsfrmArry, SVctr3 sOrgn, SVctr3 sTrgt, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            ITrck[] iTrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < iTrckArry.Length; t++) {
                iTrckArry[t] = new SSclTrck(trnsfrmArry[t], sOrgn, sTrgt, nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, iTrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int SclTwn(Transform[] trnsfrmArry, SVctr3 sOrgn, SVctr3[] sTrgtArry, int nmbrOfIntrvl, float drtn, float dly, bool isExct = true, bool isDpsb = true, DActn dEnd = null) {
            int id = GtId();
            ITrck[] iTrckArry = new ITrck[trnsfrmArry.Length];
            for (int t = 0; t < iTrckArry.Length; t++) {
                iTrckArry[t] = new SSclTrck(trnsfrmArry[t], sOrgn, sTrgtArry[t], nmbrOfIntrvl);
            }
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STrnsfrmTwn(id, iTrckArry, nmbrOfIntrvl, drtn, dly, Time.time, isExct, isDpsb, dEnd));
            return id;
        }

        public static int TxtrTwn(SpriteRenderer sprtRndr, Sprite[] sprtArry, float drtn, DActn dEnd = null) {
            int id = GtId();
            _iTwnArry = Arry.Add<ITwn>(_iTwnArry, new STxtrTwn(id, new ITrck[] { new SSprtTrck(sprtRndr, sprtArry) }, sprtArry.Length, drtn, 0.0f, Time.time, true, true, dEnd));
            return id;
        }

        public static void RmvTwn(int id) {
            int indx = GtIndx(id);
            if (indx < 0) {
                return;
            }
            _iTwnArry = Arry.Rmv<ITwn>(_iTwnArry, indx);
            if (_iTwnArry.Length == 0) {
                _id = 0;
            }
        }

        public static void StrtTwn(int id, bool isDly = true) { // start counter
            int indx = GtIndx(id);
            if (indx < 0) {
                return;
            }
            _iTwnArry[indx].Strt(Time.time, isDly);
        }

        public static void PSTwn(int id) { // pause counter
            int indx = GtIndx(id);
            if (indx < 0) {
                return;
            }
            _iTwnArry[indx].Ps(Time.time);
        }

        public static void RsmTwn(int id) { // resume counter
            int indx = GtIndx(id);
            if (indx < 0) {
                return;
            }
            _iTwnArry[indx].Rsm(Time.time);
        }

        private static int GtIndx(int id) { // find an index of the counter in the array by identity
            int strt = 0;
            int end = _iTwnArry.Length - 1;
            int mddl;
            while (end >= strt) {
                mddl = strt + ((end - strt) >> 1);
                if (id == _iTwnArry[mddl].Id) {
                    return mddl;
                } else if (id > _iTwnArry[mddl].Id) {
                    strt = mddl + 1;
                } else {
                    end = mddl - 1;
                }
            }
            return -1;
        }

        private static int GtId() {
            int id = _id;
            _id += 1;
            return id;
        }
    }
}