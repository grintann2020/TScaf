using UnityEngine;

namespace T {

    public static class Anm {

        private static ITwn[] _iTwnArr = new ITwn[0];
        private static int _id = 0;

        public static void PrpUpd() {
            for (int t = 0; t < _iTwnArr.Length; t++) {
                _iTwnArr[t].PrpUpd(Time.time);
            }
        }

        public static int PstTwn(Transform tf, SVct3 sOrg, SVct3 sTrg, int nOIv, float drt, DAct dEnd = null) {
            int id = GtId();
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, new ITrc[] { new SPstTrc(tf, sOrg, sTrg, nOIv) }, nOIv, drt, 0.0f, Time.time, true, true, dEnd));
            return id;
        }

        public static int PstTwn(Transform tf, SVct3 sOrg, SVct3 sTrg, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, new ITrc[] { new SPstTrc(tf, sOrg, sTrg, nOIv) }, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int PstTwn(Transform[] tfArr, SVct3 sOrg, SVct3 sTrg, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            ITrc[] iTrcArr = new ITrc[tfArr.Length];
            for (int t = 0; t < iTrcArr.Length; t++) {
                iTrcArr[t] = new SPstTrc(tfArr[t], sOrg, sTrg, nOIv);
            }
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, iTrcArr, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int PstTwn(Transform[] tfArr, SVct3 sOrg, SVct3[] sTrgArr, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            ITrc[] iTrcArr = new ITrc[tfArr.Length];
            for (int t = 0; t < iTrcArr.Length; t++) {
                iTrcArr[t] = new SPstTrc(tfArr[t], sOrg, sTrgArr[t], nOIv);
            }
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, iTrcArr, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int RttnTwn(Transform tf, Quaternion sOrg, Quaternion sTrg, int nOIv, float drt, DAct dEnd = null) {
            int id = GtId();
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, new ITrc[] { new SRttTrc(tf, sOrg, sTrg, nOIv) }, nOIv, drt, 0.0f, Time.time, true, true, dEnd));
            return id;
        }

        public static int RttnTwn(Transform tf, Quaternion sOrg, Quaternion sTrg, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, new ITrc[] { new SRttTrc(tf, sOrg, sTrg, nOIv) }, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int RttnTwn(Transform[] tfArr, Quaternion sOrg, Quaternion sTrg, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            ITrc[] iTrcArr = new ITrc[tfArr.Length];
            for (int t = 0; t < iTrcArr.Length; t++) {
                iTrcArr[t] = new SRttTrc(tfArr[t], sOrg, sTrg, nOIv);
            }
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, iTrcArr, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int RttnTwn(Transform[] tfArr, Quaternion sOrg, Quaternion[] sTrgArr, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            ITrc[] iTrcArr = new ITrc[tfArr.Length];
            for (int t = 0; t < iTrcArr.Length; t++) {
                iTrcArr[t] = new SRttTrc(tfArr[t], sOrg, sTrgArr[t], nOIv);
            }
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, iTrcArr, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int SclTwn(Transform tf, SVct3 sOrg, SVct3 sTrg, int nOIv, float drt, DAct dEnd = null) {
            int id = GtId();
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, new ITrc[] { new SSclTrc(tf, sOrg, sTrg, nOIv) }, nOIv, drt, 0.0f, Time.time, true, true, dEnd));
            return id;
        }

        public static int SclTwn(Transform tf, SVct3 sOrg, SVct3 sTrg, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, new ITrc[] { new SSclTrc(tf, sOrg, sTrg, nOIv) }, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int SclTwn(Transform[] tfArr, SVct3 sOrg, SVct3 sTrg, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            ITrc[] iTrcArr = new ITrc[tfArr.Length];
            for (int t = 0; t < iTrcArr.Length; t++) {
                iTrcArr[t] = new SSclTrc(tfArr[t], sOrg, sTrg, nOIv);
            }
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, iTrcArr, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int SclTwn(Transform[] tfArr, SVct3 sOrg, SVct3[] sTrgArr, int nOIv, float drt, float dly, bool isExc = true, bool isDps = true, DAct dEnd = null) {
            int id = GtId();
            ITrc[] iTrcArr = new ITrc[tfArr.Length];
            for (int t = 0; t < iTrcArr.Length; t++) {
                iTrcArr[t] = new SSclTrc(tfArr[t], sOrg, sTrgArr[t], nOIv);
            }
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STfTwn(id, iTrcArr, nOIv, drt, dly, Time.time, isExc, isDps, dEnd));
            return id;
        }

        public static int TtTwn(SpriteRenderer sprtRndr, Sprite[] sprtArr, float drt, DAct dEnd = null) {
            int id = GtId();
            _iTwnArr = Arr.Add<ITwn>(_iTwnArr, new STtTwn(id, new ITrc[] { new SSprTrc(sprtRndr, sprtArr) }, sprtArr.Length, drt, 0.0f, Time.time, true, true, dEnd));
            return id;
        }

        public static void RmvTwn(int id) {
            int idx = GtIdx(id);
            if (idx < 0) {
                return;
            }
            _iTwnArr = Arr.Rmv<ITwn>(_iTwnArr, idx);
            if (_iTwnArr.Length == 0) {
                _id = 0;
            }
        }

        public static void StrTwn(int id, bool isDly = true) { // start counter
            int idx = GtIdx(id);
            if (idx < 0) {
                return;
            }
            _iTwnArr[idx].Str(Time.time, isDly);
        }

        public static void PSTwn(int id) { // pause counter
            int idx = GtIdx(id);
            if (idx < 0) {
                return;
            }
            _iTwnArr[idx].Ps(Time.time);
        }

        public static void RsmTwn(int id) { // resume counter
            int idx = GtIdx(id);
            if (idx < 0) {
                return;
            }
            _iTwnArr[idx].Rsm(Time.time);
        }

        private static int GtIdx(int id) { // find an index of the counter in the array by identity
            int str = 0;
            int end = _iTwnArr.Length - 1;
            int mdd;
            while (end >= str) {
                mdd = str + ((end - str) >> 1);
                if (id == _iTwnArr[mdd].Id) {
                    return mdd;
                } else if (id > _iTwnArr[mdd].Id) {
                    str = mdd + 1;
                } else {
                    end = mdd - 1;
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