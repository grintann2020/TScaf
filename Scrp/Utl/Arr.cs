namespace T {

    public static class Arr {

        public static T[] Add<T>(T[] orgArr, T itm) { // add
            if (orgArr == null) {
                return new T[] { itm };
            }
            T[] rsltArr = new T[orgArr.Length + 1];
            for (int i = 0; i < orgArr.Length; i++) {
                rsltArr[i] = orgArr[i];
            }
            rsltArr[orgArr.Length] = itm;
            return rsltArr;
        }

        public static T[] Rmv<T>(T[] orgArr, int idx) { // remove
            if (orgArr == null) {
                return null;
            } else if (orgArr.Length == 0) {
                return orgArr;
            }
            T[] rsltArr = new T[orgArr.Length - 1];
            int r = 0;
            for (int i = 0; i < orgArr.Length; i++) {
                if (i != idx) {
                    rsltArr[r] = orgArr[i];
                    r++;
                }
            }
            return rsltArr;
        }

        public static T[] Psh<T>(T[] orgArr, T itm) {
            return Add<T>(orgArr, itm);
        }

        public static T[] Pp<T>(T[] orgArr) {
            return Rmv<T>(orgArr, 0);
        }

        public static T[] Apn<T>(T[] orgArrA, T[] orgArrB) { // append
            if (orgArrA == null && orgArrB == null) {
                return null;
            } else if (orgArrB == null) {
                return orgArrA;
            } else if (orgArrA == null) {
                return orgArrB;
            }
            T[] rsltArr = new T[orgArrA.Length + orgArrB.Length];
            for (int i = 0; i < rsltArr.Length; i++) {
                if (i < orgArrA.Length) {
                    rsltArr[i] = orgArrA[i];
                } else {
                    rsltArr[i] = orgArrB[i - orgArrA.Length];
                }
            }
            return rsltArr;
        }

        public static int Idx<T>(T[] orgArr, T itm) { // return index
            if (orgArr == null) {
                return -1;
            }
            for (int i = 0; i < orgArr.Length; i++) {
                if (orgArr[i].Equals(itm)) {
                    return i;
                }
            }
            return -1;
        }

        public static T[] Clm<T>(T[][] orgArr, int idx) { // return column
            if (orgArr == null || orgArr.Length == 0) {
                return null;
            }
            T[] rsltArr = new T[orgArr.Length];
            for (int i = 0; i < orgArr.Length; i++) {
                rsltArr[i] = orgArr[i][idx];
            }
            return rsltArr;
        }

        public static T[] Ct<T>(T[] orgArr, int idx, bool hlf = true) { // cut at idx and keep second half or not
            T[] rsltArr;
            if (hlf) {
                rsltArr = new T[idx];
                for (int i = 0; i < rsltArr.Length; i++) {
                    rsltArr[i] = orgArr[i];
                }
            } else {
                rsltArr = new T[orgArr.Length - idx];
                for (int i = 0; i < rsltArr.Length; i++) {
                    rsltArr[i] = orgArr[i + idx];
                }
            }
            
            return rsltArr;
        }
    }
}