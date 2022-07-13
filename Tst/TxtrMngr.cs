using System;
using UnityEngine;

namespace T {

    public enum ETxtrGrp : byte {
        Sd
    }

    public enum ETxtr : byte {
        RdSd00, RdSd01, RdSd02,
        GrnSd00, GrnSd01, GrnSd02,
        BlSd00, BlSd01, BlSd02,
        CynSd00, CynSd01, CynSd02,
        MgntSd00, MgntSd01, MgntSd02,
        YllwSd00, YllwSd01, YllwSd02,
        BlckSd00, BlckSd01, BlckSd02,
    }

    public class TxtrMngr : Sngltn<TxtrMngr> {

        

        private Texture[][] _txtrGrpArry = new Texture[Enum.GetNames(typeof(ETxtrGrp)).Length][];
        private Sprite[][][] _sprtGrpArry = new Sprite[Enum.GetNames(typeof(ETxtrGrp)).Length][][];

        private string[] _kyArry = new string[] {
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

        private byte[][] _eKyGrpArry = new byte[][] {
            // side group
            new byte[] {
                (byte)ETxtr.RdSd00, (byte)ETxtr.RdSd01, (byte)ETxtr.RdSd02,
                (byte)ETxtr.GrnSd00, (byte)ETxtr.GrnSd01, (byte)ETxtr.GrnSd02,
                (byte)ETxtr.BlSd00, (byte)ETxtr.BlSd01, (byte)ETxtr.BlSd02,
                (byte)ETxtr.CynSd00, (byte)ETxtr.CynSd01, (byte)ETxtr.CynSd02,
                (byte)ETxtr.MgntSd00, (byte)ETxtr.MgntSd01, (byte)ETxtr.MgntSd02,
                (byte)ETxtr.YllwSd00, (byte)ETxtr.YllwSd01, (byte)ETxtr.YllwSd02,
                (byte)ETxtr.BlckSd00, (byte)ETxtr.BlckSd01, (byte)ETxtr.BlckSd02,
            }
        };

        public void LoadTxtr(byte eGrp, DActn<Texture[]> dLoad = null) {
            Rsrc.Load<Texture>(GrpKy(_eKyGrpArry[eGrp]), (txtrArry) => {
                _txtrGrpArry[eGrp] = txtrArry;
                dLoad?.Invoke(_txtrGrpArry[eGrp]);
            });
        }

        public void LoadSprt(byte eGrp, DActn<Sprite[][]> dLoad = null) {
            Rsrc.Load<Sprite[]>(GrpKy(_eKyGrpArry[eGrp]), (sprtArry) => {
                _sprtGrpArry[eGrp] = sprtArry;
                dLoad?.Invoke(_sprtGrpArry[eGrp]);
            });
        }

        public Sprite[] GtSprtArry(byte eGrp, byte ETxtr) {
            return _sprtGrpArry[eGrp][ETxtr];
        }

        private string[] GrpKy(byte[] eKyArry) {
            string[] kyArry = new string[eKyArry.Length];
            for (byte e = 0; e < eKyArry.Length; e++) {
                kyArry[e] = _kyArry[eKyArry[e]];
            }
            return kyArry;
        }
    }
}