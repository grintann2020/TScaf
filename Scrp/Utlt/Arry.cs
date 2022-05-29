namespace T {

    public static class Arry {

        public static T[] Add<T>(T[] orgn, T itm) { // add
            if (orgn == null) {
                return new T[] { itm };
            }
            T[] rslt = new T[orgn.Length + 1];
            for (ushort i = 0; i < orgn.Length; i++) {
                rslt[i] = orgn[i];
            }
            rslt[orgn.Length] = itm;
            return rslt;
        }

        public static T[] CntnAdd<T>(T[] orgn, T itm, T[] tmp) { // continuous add
            if (orgn == null) {
                return new T[] { itm };
            }
            tmp = new T[orgn.Length + 1];
            for (ushort i = 0; i < orgn.Length; i++) {
                tmp[i] = orgn[i];
            }
            tmp[orgn.Length] = itm;
            return tmp;
        }

        public static T[] Rmv<T>(T[] orgn, ushort indx) { // remove
            if (orgn == null) {
                return null;
            } else if (orgn.Length == 0) {
                return orgn;
            }
            T[] rslt = new T[orgn.Length - 1];
            ushort r = 0;
            for (ushort i = 0; i < orgn.Length; i++) {
                if (i != indx) {
                    rslt[r] = orgn[i];
                    r++;
                }
            }
            return rslt;
        }

        public static T[] Apnd<T>(T[] orgnA, T[] orgnB) { // append
            if (orgnA == null && orgnB == null) {
                return null;
            } else if (orgnB == null) {
                return orgnA;
            } else if (orgnA == null) {
                return orgnB;
            }
            T[] rslt = new T[orgnA.Length + orgnB.Length];
            for (ushort i = 0; i < rslt.Length; i++) {
                if (i < orgnA.Length) {
                    rslt[i] = orgnA[i];
                } else {
                    rslt[i] = orgnB[i - orgnA.Length];
                }
            }
            return rslt;
        }

        public static int Indx<T>(T[] orgn, T itm) { // return index
            if (orgn == null) {
                return -1;
            }
            for (ushort i = 0; i < orgn.Length; i++) {
                if (orgn[i].Equals(itm)) {
                    return (int)i;
                }
            }
            return -1;
        }

        public static T[] Clmn<T>(T[][] orgn, ushort indx) { // return column
            if (orgn == null || orgn.Length == 0) {
                return null;
            }
            T[] rslt = new T[orgn.Length];
            for (ushort i = 0; i < orgn.Length; i++) {
                rslt[i] = (T)orgn[i][indx];
            }
            return rslt;
        }

        // dismiss need to rewrite 

        // public static T[] Dim<T>(object[][] orgn, ushort indx) { // dismiss 
        //     T[] rslt = new T[orgn.Length];
        //     for (ushort i = 0; i < orgn.Length; i++) {
        //         rslt[i] = (T)orgn[i][indx];
        //     }
        //     return rslt;
        // }
    }
}