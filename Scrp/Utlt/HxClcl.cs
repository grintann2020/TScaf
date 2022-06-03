using System;

namespace T {

    public static class HxClcl {

        public static float Sqrt3 { get { return 1.732050807568877f; } }
        private static double _rdn = 0.0f; // radian 

        private static int[][][] drctPArry = new int[][][] {
            new int[][] {
                new int[] {+1,  0}, new int[] { 0, +1}, new int[] {-1, +1},
                new int[] {-1,  0}, new int[] {-1, -1}, new int[] { 0, -1},
            },
            new int[][] {
                new int[] {+1,  0}, new int[] {+1, +1}, new int[] { 0, +1},
                new int[] {-1,  0}, new int[] { 0, -1}, new int[] {+1, -1},
            }
        };

        private static int[][][] drctFArry = new int[][][] {
            new int[][] {
                new int[] {+1,  0}, new int[] {+1, +1}, new int[] { 0, -1},
                new int[] {-1, +1}, new int[] {-1,  0}, new int[] { 0, +1},
            },
            new int[][] {
                new int[] {+1, -1}, new int[] {+1,  0}, new int[] { 0, +1},
                new int[] {-1,  0}, new int[] {-1, -1}, new int[] { 0, -1},
            }
        };

        public static int[] AdjcP(int rw, int drct) {
            return drctPArry[rw & 1][drct]; // parity, direction
        }

        public static int[] AdjcF(int clmn, int drct) {
            return drctPArry[clmn & 1][drct]; // parity, direction
        }

        // public static (float hrznDist, float vrtcDist) DstrDstn(float sz) { // return distribute distance
        //     return (HrznDstn(sz), VrtcDstn(sz));
        // }

        public static float HrznDstnP(float crcmrds) { // horizontal distance
            return SctnWdthP(HxWdthP(crcmrds)) * 2;
        }

        public static float VrtcDstnP(float crcmrds) { // vertical distance
            return SctnHghtP(HxHghtP(crcmrds)) * 3;
        }

        public static float HrznDstnF(float crcmrds) { // horizontal distance
            return SctnWdthP(HxWdthF(crcmrds)) * 3;
        }

        public static float VrtcDstnF(float crcmrds) { // vertical distance
            return SctnHghtP(HxHghtF(crcmrds)) * 2;
        }

        public static float SctnWdthP(float hxWdth) { // return section width when point topped
            return hxWdth / 2;
        }

        public static float SctnHghtP(float hxHght) { // return section height when point topped
            return hxHght / 4;
        }

        public static float SctnWdthF(float hxWdth) { // return section width when flat topped
            return hxWdth / 4;
        }

        public static float SctnHghtF(float hxHght) { // return section height when flat topped
            return hxHght / 2;
        }

        public static float HxWdthP(float crcmrds) { // return hexagon width by circumradius
            return crcmrds * Sqrt3;
        }

        public static float HxHghtP(float crcmrds) { // return hexagon height by circumradius
            return crcmrds * 2;
        }

        public static float HxWdthF(float crcmrds) { // hexagon width
            return crcmrds * 2;
        }

        public static float HxHghtF(float crcmrds) { // hexagon height
            return crcmrds * Sqrt3;
        }

        public static SVctr3 CntrCrdP(ushort hrznUnts, ushort vrtcUnts, float crcmrds) { // return center coordinate
            return new SVctr3(
                -((HrznDstnP(crcmrds) * (float)hrznUnts) / 2) + SctnWdthP(HxWdthP(crcmrds)),
                0.0f,
                -((VrtcDstnP(crcmrds) * (float)vrtcUnts) / 2) + SctnHghtP(HxHghtP(crcmrds)) + (SctnHghtP(HxHghtP(crcmrds)) / 2)
            );
        }

        public static byte HxPDrct(float distY, float distX) {
            _rdn = Math.Atan2(distY, distX) + 0.523599; // + 30 degree
            if (_rdn <= 0) {
                _rdn = Math.PI * 2 + _rdn;
            }
            return (byte)Math.Floor(_rdn / (Math.PI * 2) * 6);
        }
    }
}