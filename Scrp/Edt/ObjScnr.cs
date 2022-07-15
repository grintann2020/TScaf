using System;
using UnityEngine;

namespace T {

    public class ObjScnr : Scnr { // Scene Scanner
        
        void Start() {
            _pth = DFLTPTH + PrjcNm + "\\" + ExtnPth + FlNm + EXTN;
            _strn += NMSPC + " " + PrjcNm + " {\n";
            _strn += CLSS + " " + ClssNm + " {\n";
            _strn += Code(Rt);
            _strn += "}\n}\n";
            Wrt(_strn, false);
        }

        private string Code(Transform root) {
            _enmStrn = "public enum E" + ArryNm + " : byte {\n";
            _objcStrn = "public static object[][] " + ArryNm + "Arry = new object[][] {\n";
            Admt[] admtArr = root.GetComponentsInChildren<Admt>(); // admit object array
            for (int a = 0; a < admtArr.Length; a++) {
                _enmStrn += CodeObjEnum(admtArr[a].transform);
                _objcStrn += CodeObj(admtArr[a].transform);
            }

            //---------- subobjects enum ----------
            for (int a = 0; a < admtArr.Length; a++) {
                _enmStrn += CodeSobjEnum(admtArr[a].transform);
            }
            _enmStrn += "}\n";
            _objcStrn += "};\n";

            return _enmStrn + _objcStrn;
        }

        private string CodeObjEnum(Transform trnf) {
            _trnsfrms = Arry.Add<Transform>(_trnsfrms, trnf);
            return trnf.name + ",\n";
        }

        private string CodeSobjEnum(Transform trnf) {
            string str = "";
            Transform[] childArr = trnf.GetComponentsInChildren<Transform>();
            for (byte t = 1; t < childArr.Length; t++) {
                _trnsfrms = Arry.Add<Transform>(_trnsfrms, childArr[t]);
                str += PrntStrn(childArr[t], "");
                str += childArr[t].name;
                str += ",\n";
            }
            return str;
        }

        private string CodeObj(Transform trnf) {
            string str = "";
            str += "new object[4]{";
            str += "\"" + trnf.name.Split(new[] { "_c" }, StringSplitOptions.RemoveEmptyEntries)[0] + "\", ";
            str += "new float[3]{" + trnf.transform.position.x + "f, " + trnf.transform.position.y + "f, " + trnf.transform.position.z + "f}, ";
            str += "new float[4]{" + trnf.transform.rotation.x + "f, " + trnf.transform.rotation.y + "f, " + trnf.transform.rotation.z + "f, " + trnf.transform.rotation.w + "f}, ";
            str += "E" + ArryNm + "." + trnf.name;
            str += "},\n";
            return str;
        }
    }
}