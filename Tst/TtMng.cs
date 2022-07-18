using System;
using UnityEngine;

namespace T {

    public enum ETtGrp : byte {
        Sd
    }

    public enum ETt : byte {
        RdSd00, RdSd01, RdSd02,
        GrnSd00, GrnSd01, GrnSd02,
        BlSd00, BlSd01, BlSd02,
        CynSd00, CynSd01, CynSd02,
        MgntSd00, MgntSd01, MgntSd02,
        YllwSd00, YllwSd01, YllwSd02,
        BlckSd00, BlckSd01, BlckSd02,
    }

    public class TtMng : Sng<TtMng> {
        private Texture[][] _ttGrpArr = new Texture[Enum.GetNames(typeof(ETtGrp)).Length][];
        private Sprite[][][] _sprGrpArr = new Sprite[Enum.GetNames(typeof(ETtGrp)).Length][][];
        private string[] _kyArr = new string[] {
            "RedSide00", "RedSide01", "RedSide02",
            "RedSide00", "RedSide01", "RedSide02",
            "RedSide00", "RedSide01", "RedSide02",
            "RedSide00", "RedSide01", "RedSide02",
            "RedSide00", "RedSide01", "RedSide02",
            "RedSide00", "RedSide01", "RedSide02",
            "RedSide00", "RedSide01", "RedSide02",
            // "GreenSide00", "GreenSide01", "GreenSide02",
            // "BlueSide00", "BlueSide01", "BlueSide02",
            // "CyanSide00", "CyanSide01", "CyanSide02",
            // "MagentaSide00", "MagentaSide01", "MagentaSide02",
            // "YellowSide00", "YellowSide01", "YellowSide02",
            // "BlackSide00", "BlackSide01", "YellowSide02",
        };

        private byte[][] _eKyGrpArr = new byte[][] {
            // side group
            new byte[] {
                (byte)ETt.RdSd00, (byte)ETt.RdSd01, (byte)ETt.RdSd02,
                (byte)ETt.GrnSd00, (byte)ETt.GrnSd01, (byte)ETt.GrnSd02,
                (byte)ETt.BlSd00, (byte)ETt.BlSd01, (byte)ETt.BlSd02,
                (byte)ETt.CynSd00, (byte)ETt.CynSd01, (byte)ETt.CynSd02,
                (byte)ETt.MgntSd00, (byte)ETt.MgntSd01, (byte)ETt.MgntSd02,
                (byte)ETt.YllwSd00, (byte)ETt.YllwSd01, (byte)ETt.YllwSd02,
                (byte)ETt.BlckSd00, (byte)ETt.BlckSd01, (byte)ETt.BlckSd02,
            }
        };

        public void LdTt(byte eGrp, DRct<Texture[]> dLd = null) {
            Rs.Ld<Texture>(GrpKy(_eKyGrpArr[eGrp]), (ttArr) => {
                _ttGrpArr[eGrp] = ttArr;
                dLd?.Invoke(_ttGrpArr[eGrp]);
            });
        }

        public void LdSpr(byte eGrp, DRct<Sprite[][]> dLd = null) {
            Rs.Ld<Sprite[]>(GrpKy(_eKyGrpArr[eGrp]), (sprArr) => {
                _sprGrpArr[eGrp] = sprArr;
                dLd?.Invoke(_sprGrpArr[eGrp]);
            });
        }

        public Sprite[] GtSprArr(byte eGrp, byte ETt) {
            return _sprGrpArr[eGrp][ETt];
        }

        private string[] GrpKy(byte[] eKyArr) {
            string[] kyArr = new string[eKyArr.Length];
            for (byte e = 0; e < eKyArr.Length; e++) {
                kyArr[e] = _kyArr[eKyArr[e]];
            }
            return kyArr;
        }
    }
}