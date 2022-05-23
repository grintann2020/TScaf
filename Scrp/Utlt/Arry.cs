namespace T {

    public static class Arry {

        public static T[] Add<T>(T[] arry, T itm) {
            if (arry == null) {
                return new T[] { itm };
            }
            T[] rslt = new T[arry.Length + 1];
            for (ushort i = 0; i < arry.Length; i++) {
                rslt[i] = arry[i];
            }
            rslt[arry.Length] = itm;
            return rslt;
        }

        public static T[] Rmv<T>(T[] arry, ushort indx) {
            if (arry == null) {
                return null;
            } else if (arry.Length == 0) {
                return arry;
            }
            T[] rslt = new T[arry.Length - 1];
            ushort r = 0;
            for (ushort i = 0; i < arry.Length; i++) {
                if (i != indx) {
                    rslt[r] = arry[i];
                    r++;
                }
            }
            return rslt;
        }

        public static T[] Apnd<T>(T[] arryA, T[] arryB) {
            if (arryA == null && arryB == null) {
                return null;
            } else if (arryB == null) {
                return arryA;
            } else if (arryA == null) {
                return arryB;
            }
            T[] rslt = new T[arryA.Length + arryB.Length];
            for (ushort i = 0; i < rslt.Length; i++) {
                if (i < arryA.Length) {
                    rslt[i] = arryA[i];
                } else {
                    rslt[i] = arryB[i - arryA.Length];
                }
            }
            return rslt;
        }

        public static int Indx<T>(T[] arry, T itm) {
            if (arry == null) {
                return -1;
            }
            for (ushort i = 0; i < arry.Length; i++) {
                if (arry[i].Equals(itm)) {
                    return (int)i;
                }
            }
            return -1;
        }

        public static T[] Clmn<T>(T[][] arry, ushort indx) { // get column
            if (arry == null || arry.Length == 0) {
                return null;
            }
            T[] rslt = new T[arry.Length];
            for (ushort i = 0; i < arry.Length; i++) {
                rslt[i] = (T)arry[i][indx];
            }
            return rslt;
        }

        // dismiss need to rewrite 

        // public static T[] Dim<T>(object[][] arry, ushort indx) { // dismiss 
        //     T[] rslt = new T[arry.Length];
        //     for (ushort i = 0; i < arry.Length; i++) {
        //         rslt[i] = (T)arry[i][indx];
        //     }
        //     return rslt;
        // }
    }
}