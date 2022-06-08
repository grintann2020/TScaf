namespace T {

    public static class Arry {

        public static T[] Add<T>(T[] orgnArry, T itm) { // add
            if (orgnArry == null) {
                return new T[] { itm };
            }
            T[] rsltArry = new T[orgnArry.Length + 1];
            for (int i = 0; i < orgnArry.Length; i++) {
                rsltArry[i] = orgnArry[i];
            }
            rsltArry[orgnArry.Length] = itm;
            return rsltArry;
        }

        public static T[] Rmv<T>(T[] orgnArry, int indx) { // remove
            if (orgnArry == null) {
                return null;
            } else if (orgnArry.Length == 0) {
                return orgnArry;
            }
            T[] rsltArry = new T[orgnArry.Length - 1];
            int r = 0;
            for (int i = 0; i < orgnArry.Length; i++) {
                if (i != indx) {
                    rsltArry[r] = orgnArry[i];
                    r++;
                }
            }
            return rsltArry;
        }

        public static T[] Apnd<T>(T[] orgnArryA, T[] orgnArryB) { // append
            if (orgnArryA == null && orgnArryB == null) {
                return null;
            } else if (orgnArryB == null) {
                return orgnArryA;
            } else if (orgnArryA == null) {
                return orgnArryB;
            }
            T[] rsltArry = new T[orgnArryA.Length + orgnArryB.Length];
            for (int i = 0; i < rsltArry.Length; i++) {
                if (i < orgnArryA.Length) {
                    rsltArry[i] = orgnArryA[i];
                } else {
                    rsltArry[i] = orgnArryB[i - orgnArryA.Length];
                }
            }
            return rsltArry;
        }

        public static int Indx<T>(T[] orgnArry, T itm) { // return index
            if (orgnArry == null) {
                return -1;
            }
            for (int i = 0; i < orgnArry.Length; i++) {
                if (orgnArry[i].Equals(itm)) {
                    return i;
                }
            }
            return -1;
        }

        public static T[] Clmn<T>(T[][] orgnArry, int indx) { // return column
            if (orgnArry == null || orgnArry.Length == 0) {
                return null;
            }
            T[] rsltArry = new T[orgnArry.Length];
            for (int i = 0; i < orgnArry.Length; i++) {
                rsltArry[i] = orgnArry[i][indx];
            }
            return rsltArry;
        }

        public static T[] Ct<T>(T[] orgnArry, int indx, bool hlf = false) { // cut at indx and keep second half or not
            T[] rsltArry = new T[hlf ? orgnArry.Length - indx : indx];
            for (int i = 0; i < rsltArry.Length; i++) {
                rsltArry[i] = orgnArry[i + (hlf ? indx : 0)];
            }
            return rsltArry;
        }
    }
}