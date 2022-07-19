using System;
using UnityEngine;

namespace T {

    public class ObjScnr : Scnr { // Scene Scanner
        
        void Start() {
            _pth = DP + PrjNm + "\\" + ExtPth + FlNm + EXT;
            _str += NS + " " + PrjNm + " {\n";
            _str += CLS + " " + ClsNm + " {\n";
            _str += Code(Rt);
            _str += "}\n}\n";
            Wrt(_str, false);
        }

        private string Code(Transform rt) {
            _enmStr = "public enum E" + ArrNm + " : byte {\n";
            _objStr = "public static object[][] " + ArrNm + "Arr = new object[][] {\n";
            Adm[] admArr = rt.GetComponentsInChildren<Adm>(); // admit object array
            for (int a = 0; a < admArr.Length; a++) {
                _enmStr += CdObjEnm(admArr[a].transform);
                _objStr += CdObj(admArr[a].transform);
            }

            //---------- subobjects enum ----------
            for (int a = 0; a < admArr.Length; a++) {
                _enmStr += CdSobjEnm(admArr[a].transform);
            }
            _enmStr += "}\n";
            _objStr += "};\n";

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

        private string CdObj(Transform tf) {
            string str = "";
            str += "new object[4]{";
            str += "\"" + tf.name.Split(new[] { "_c" }, StringSplitOptions.RemoveEmptyEntries)[0] + "\", ";
            str += "new float[3]{" + tf.transform.position.x + "f, " + tf.transform.position.y + "f, " + tf.transform.position.z + "f}, ";
            str += "new float[4]{" + tf.transform.rotation.x + "f, " + tf.transform.rotation.y + "f, " + tf.transform.rotation.z + "f, " + tf.transform.rotation.w + "f}, ";
            str += "E" + ArrNm + "." + tf.name;
            str += "},\n";
            return str;
        }
    }
}