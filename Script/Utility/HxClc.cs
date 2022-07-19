using System;
using UnityEngine;

namespace T {

    public static class HxClc {

        public static float Sqr3 { get { return 1.732050807568877f; } }

        private static int[][][] _drcPs = new int[][][] {
            new int[][] {
                new int[] {+1,  0}, new int[] { 0, +1}, new int[] {-1, +1},
                new int[] {-1,  0}, new int[] {-1, -1}, new int[] { 0, -1},
            },
            new int[][] {
                new int[] {+1,  0}, new int[] {+1, +1}, new int[] { 0, +1},
                new int[] {-1,  0}, new int[] { 0, -1}, new int[] {+1, -1},
            }
        };

        private static int[][][] _drcFs = new int[][][] {
            new int[][] {
                new int[] {+1,  0}, new int[] {+1, +1}, new int[] { 0, +1},
                new int[] {-1, +1}, new int[] {-1,  0}, new int[] { 0, -1},
            },
            new int[][] {
                new int[] {+1, -1}, new int[] {+1,  0}, new int[] { 0, +1},
                new int[] {-1,  0}, new int[] {-1, -1}, new int[] { 0, -1},
            }
        };

        private static double _rdn = 0.0f; // radian 

        public static float HrzDstP(float crc) { // horizontal dstance
            return SctWdtP(HxWdtP(crc)) * 2;
        }

        public static float VrtDstP(float crc) { // vertical dstance
            return SctHghP(HxHghP(crc)) * 3;
        }

        public static float HrzDstF(float crc) { // horizontal dstance
            return SctWdtF(HxWdtF(crc)) * 3;
        }

        public static float VrtDstF(float crc) { // vertical dstance
            return SctHghF(HxHghF(crc)) * 2;
        }

        public static float SctWdtP(float hxWdt) { // return section width when point topped
            return hxWdt / 2;
        }

        public static float SctHghP(float hxHgh) { // return section height when point topped
            return hxHgh / 4;
        }

        public static float SctWdtF(float hxWdt) { // return section width when flat topped
            return hxWdt / 4;
        }

        public static float SctHghF(float hxHgh) { // return section height when flat topped
            return hxHgh / 2;
        }

        public static float HxWdtP(float crc) { // return hexagon width by circumradius
            return crc * Sqr3;
        }

        public static float HxHghP(float crc) { // return hexagon height by circumradius
            return crc * 2;
        }

        public static float HxWdtF(float crc) { // hexagon width
            return crc * 2;
        }

        public static float HxHghF(float crc) { // hexagon height
            return crc * Sqr3;
        }

        public static SVct3 GtCntCrdP(int hrzUnts, int vrtUnts, float crc) { // return center coordinate
            return new SVct3(
                -((HrzDstP(crc) * (float
                )hrzUnts) / 2) + SctWdtP(HxWdtP(crc)),
                0.0f,
                -((VrtDstP(crc) * (float)vrtUnts) / 2) + SctHghP(HxHghP(crc)) + (SctHghP(HxHghP(crc)) / 2)
            );
        }

        public static SVct3 GtCntCrdF(int hrzUnts, int vrtUnts, float crc) { // return center coordinate
            return new SVct3(
                -((HrzDstF(crc) * (float)hrzUnts) / 2) + SctWdtF(HxWdtF(crc)) + (SctWdtF(HxWdtF(crc)) / 2),
                0.0f,
                -((VrtDstF(crc) * (float)vrtUnts) / 2) + SctHghF(HxHghF(crc))
            );
        }

        public static byte HxPDrc(float dstY, float dstX) {
            _rdn = Math.Atan2(dstY, dstX) + 0.523599; // + 30 degree
            if (_rdn <= 0) {
                _rdn = Math.PI * 2 + _rdn;
            }
            return (byte)Math.Floor(_rdn / (Math.PI * 2) * 6);
        }

        public static byte HxFDrc(float dstY, float dstX) {
            _rdn = Math.Atan2(dstY, dstX) + 1.0472; // + 60 degree
            if (_rdn <= 0) {
                _rdn = Math.PI * 2 + _rdn;
            }
            return (byte)Math.Floor(_rdn / (Math.PI * 2) * 6);
        }

        public static int[] AdjP(int rw, int drc) {
            return _drcPs[rw & 1][drc]; // parity, direction
        }

        public static int[] AdjF(int clmn, int drc) {
            return _drcFs[clmn & 1][drc]; // parity, direction
        }

        public static SHxGrd ToHxFGrd(SGrd3 sGrd, int hlf) {
            int clmn = sGrd.Clm - hlf;
            int rw = sGrd.Rw - hlf;
            int hxClm = clmn;
            int hxRw = rw - (clmn - (clmn & 1)) / 2;
            return new SHxGrd(sGrd.Lyr, hxClm, hxRw, -hxClm - hxRw);
        }

        public static SGrd3 ToOffGrd(SGrd3 sHxGrd, int hlf) {
            int hxClm = sHxGrd.Clm;
            int hxRw = sHxGrd.Rw + (sHxGrd.Clm - (sHxGrd.Clm & 1)) / 2;
            int clmn = hxClm + hlf;
            int rw = hxRw + hlf;
            return new SGrd3(sHxGrd.Lyr, clmn, rw);
        }

        // public static (float hrzDist, float vrtDist) DstrDst(float sz) { // return dstribute dstance
        //     return (HrzDst(sz), VrtDst(sz));
        // }
    }
}