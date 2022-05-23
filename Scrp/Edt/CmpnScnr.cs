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
            _enmStrn = "public enum E" + Rt.name + " : byte {\n";
            _objcStrn = "public static object[][] " + Rt.name + "Arry = new object[][] {\n";
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
            _enmStrn += "public enum E" + Rt.name + "Comp : byte {\n";
            _enmStrn += CodeCompEnum();
            _enmStrn += "}\n";
            return _enmStrn + _objcStrn;
        }

        private string CodeObjEnum(Transform trnsfrm) {
            _trnsfrmArry = Arry.Add<Transform>(_trnsfrmArry, trnsfrm);
            return trnsfrm.name + ",\n";
        }

        private string CodeSobjEnum(Transform trnsfrm) {
            string strn = "";
            Transform[] childArry = trnsfrm.GetComponentsInChildren<Transform>();
            for (byte t = 1; t < childArry.Length; t++) {
                _trnsfrmArry = Arry.Add<Transform>(_trnsfrmArry, childArry[t]);
                strn += PrntStrn(childArry[t], "");
                strn += childArry[t].name;
                strn += ",\n";
            }
            return strn;
        }

        private string CodeCompEnum() {
            string strn = "";
            for (byte t = 0; t < _trnsfrmArry.Length; t++) {
                for (int e = 0; e < UIMngr.Inst.TypArry.Length; e++) {
                    if (_trnsfrmArry[t].GetComponent(UIMngr.Inst.TypArry[e])) {
                        strn += PrntStrn(_trnsfrmArry[t], "");
                        strn += _trnsfrmArry[t].name + "_" + CompNm(UIMngr.Inst.TypArry[e]) + ",\n";
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
            strn += "E" + Rt.name + "." + trnsfrm.name;
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