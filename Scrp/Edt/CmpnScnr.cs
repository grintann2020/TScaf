using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace T {

    public class CmpnScnr : Scnr { // UI Scanner

        void Start() {
            _pth = DFLTPTH + PrjcNm + "\\" + ExtnPth + FlNm + EXTN;
            _strn += NMSPC + " " + PrjcNm + " {\n";
            _strn += CLSS + " " + ClssNm + " {\n";
            _strn += Code(Rt);
            _strn += "}\n}\n";
            Wrt(_strn, false);
        }

        private string Code(Transform root) {
            //---------- objects ----------
            _enmStrn = "public enum E" + ArryNm + " : byte {\n";
            _objcStrn = "public static object[][] " + ArryNm + "Arry = new object[][] {\n";
            Admt[] admtArry = root.GetComponentsInChildren<Admt>(); // admit element array
            for (int a = 0; a < admtArry.Length; a++) {
                _enmStrn += CodeObjEnum(admtArry[a].transform);
                _objcStrn += CodeObj(admtArry[a].transform);
            }

            //---------- subobjects enum ----------
            for (int a = 0; a < admtArry.Length; a++) {
                _enmStrn += CodeSobjEnum(admtArry[a].transform);
            }
            _enmStrn += "}\n";
            _objcStrn += "};\n";

            //---------- components enum ----------
            _enmStrn += "public enum E" + ArryNm + "Comp : byte {\n";
            _enmStrn += CodeCompEnum();
            _enmStrn += "}\n";
            return _enmStrn + _objcStrn;
        }

        private string CodeObjEnum(Transform trnsfrm) {
            _trnsfrms = Arry.Add<Transform>(_trnsfrms, trnsfrm);
            return trnsfrm.name + ",\n";
        }

        private string CodeSobjEnum(Transform trnsfrm) {
            string strn = "";
            Transform[] childArry = trnsfrm.GetComponentsInChildren<Transform>();
            for (byte t = 1; t < childArry.Length; t++) {
                _trnsfrms = Arry.Add<Transform>(_trnsfrms, childArry[t]);
                strn += PrntStrn(childArry[t], "");
                strn += childArry[t].name;
                strn += ",\n";
            }
            return strn;
        }

        private string CodeCompEnum() {
            string strn = "";
            for (byte t = 0; t < _trnsfrms.Length; t++) {
                for (int e = 0; e < UIMngr.Inst.Typs.Length; e++) {
                    if (_trnsfrms[t].GetComponent(UIMngr.Inst.Typs[e])) {
                        strn += PrntStrn(_trnsfrms[t], "");
                        strn += _trnsfrms[t].name + "_" + CompNm(UIMngr.Inst.Typs[e]) + ",\n";
                    }
                }
            }
            return strn;
        }

        private string CodeObj(Transform trnsfrm) {
            string strn = "";
            strn += "new object[3]{";
            strn += "\"" + trnsfrm.name.Split(new[] { "_c" }, StringSplitOptions.RemoveEmptyEntries)[0] + "\", ";
            strn += "new short[2]{" + trnsfrm.transform.position.x + ", " + trnsfrm.transform.position.y + "}, ";
            strn += "E" + ArryNm + "." + trnsfrm.name;
            strn += "},\n";
            return strn;
        }

        private string CompNm(Type typ) {
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