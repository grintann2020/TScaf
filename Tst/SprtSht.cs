using System;
using UnityEngine;
using T;

namespace Hxlc {

    public enum ESprtGrp : byte {
        SprtGrp0, SprtGrp1
    }

    public enum ESprt : byte {
        Rd00_Idl, Rd01_Idl, Rd02_Idl,
        Grn00_Idl, Grn01_Idl, Grn02_Idl,
        Bl00_Idl, Bl01_Idl, Bl02_Idl,
        Rd02_Flp
    }

    public static class SprtSht {

        // private static Sprite[][] _sprtGrpArry = new Sprite[Enum.GetNames(typeof(ESprtGrp)).Length][];
        private static Sprite[][][] _sprtGrpArry = new Sprite[Enum.GetNames(typeof(ESprtGrp)).Length][][];
        private static DActn<string[], DActn>[] DLdArry = new DActn<string[], DActn>[] {
            (kyArry, dLoad) => {
                Rsrc.Load<Sprite[]>(kyArry, (sprtArry) => {
                    _sprtGrpArry[_eGrp] = sprtArry;
                    dLoad?.Invoke();
                });
            }
        };

        private static string[] _kyArry = new string[] {
            "Red00_Idle", "Red01_Idle", "Red02_Idle",
            "Green00_Idle", "Green01_Idle", "Green02_Idle",
            "Blue00_Idle", "Blue01_Idle", "Blue02_Idle",
            "Red02_Flip",
        };

        private static byte[][] _eKyGrpArry = new byte[][] {
            new byte[] {
                (byte)ESprt.Rd00_Idl, (byte)ESprt.Rd01_Idl, (byte)ESprt.Rd02_Idl,
                (byte)ESprt.Grn00_Idl, (byte)ESprt.Grn01_Idl, (byte)ESprt.Grn02_Idl,
                (byte)ESprt.Bl00_Idl, (byte)ESprt.Bl01_Idl, (byte)ESprt.Bl02_Idl,
                (byte)ESprt.Rd02_Flp
            }
        };

        private static byte _eGrp = 0;

        public static void Load(byte eGrp, DActn dActn = null) {
            _eGrp = eGrp;
            string[] kyArry = new string[256];
            byte indx = 0;
            for (byte e = 0; e < _eKyGrpArry[eGrp].Length; e++) {
                kyArry[e] = _kyArry[_eKyGrpArry[eGrp][e]];
                indx += 1;
            }
            DLdArry[eGrp]?.Invoke(Arry.Ct<string>(kyArry, indx), dActn);
        }

        public static Sprite[] GtSprtArry(byte eSprt) {
            return _sprtGrpArry[_eGrp][eSprt];
        }


    }
}