using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace T {

    public class CmpnScnr : Scnr { // UI Scanner

        void Str() {
            _pth = DP + PrjNm + "\\" + ExtPth + FlNm + EXT;
            _str += NS + " " + PrjNm + " {\n";
            _str += CLS + " " + ClsNm + " {\n";
            _str += Cd(Rt);
            _str += "}\n}\n";
            Wrt(_str, false);
        }

        private string Cd(Transform root) {
            //---------- objects ----------
            _enmStr = "public enum E" + ArrNm + " : byte {\n";
            _objStr = "public static object[][] " + ArrNm + "Arr = new object[][] {\n";
            Adm[] admtArr = root.GetComponentsInChildren<Adm>(); // admit element array
            for (int a = 0; a < admtArr.Length; a++) {
                _enmStr += CdObjEnm(admtArr[a].transform);
                _objStr += CdObj(admtArr[a].transform);
            }

            //---------- subobjects enum ----------
            for (int a = 0; a < admtArr.Length; a++) {
                _enmStr += CdSobjEnm(admtArr[a].transform);
            }
            _enmStr += "}\n";
            _objStr += "};\n";

            //---------- components enum ----------
            _enmStr += "public enum E" + ArrNm + "Comp : byte {\n";
            _enmStr += CdCmpEnm();
            _enmStr += "}\n";
            return _enmStr + _objStr;
        }

        private string CdObjEnm(Transform tf) {
            _tfArr = Arr.Add<Transform>(_tfArr, tf);
            return tf.name + ",\n";
        }

        private string CdSobjEnm(Transform tf) {
            string str = "";
            Transform[] chlArr = tf.GetComponentsInChildren<Transform>();
            for (byte t = 1; t < chlArr.Length; t++) {
                _tfArr = Arr.Add<Transform>(_tfArr, chlArr[t]);
                str += PrnStr(chlArr[t], "");
                str += chlArr[t].name;
                str += ",\n";
            }
            return str;
        }

        private string CdCmpEnm() {
            string str = "";
            for (byte t = 0; t < _tfArr.Length; t++) {
                for (int e = 0; e < UIMng.Ins.Typs.Length; e++) {
                    if (_tfArr[t].GetComponent(UIMng.Ins.Typs[e])) {
                        str += PrnStr(_tfArr[t], "");
                        str += _tfArr[t].name + "_" + CmpNm(UIMng.Ins.Typs[e]) + ",\n";
                    }
                }
            }
            return str;
        }

        private string CdObj(Transform tf) {
            string str = "";
            str += "new object[3]{";
            str += "\"" + tf.name.Split(new[] { "_c" }, StringSplitOptions.RemoveEmptyEntries)[0] + "\", ";
            str += "new short[2]{" + tf.transform.position.x + ", " + tf.transform.position.y + "}, ";
            str += "E" + ArrNm + "." + tf.name;
            str += "},\n";
            return str;
        }

        private string CmpNm(Type typ) {
            if (typ == typeof(TMP_Text)) {
                return "TMP";
            } else if (typ == typeof(Text)) {
                return "Txt";
            } else if (typ == typeof(Image)) {
                return "Img";
            } else if (typ == typeof(Button)) {
                return "Btn";
            } else {
                return "undefinied";
            }
        }
    }
}