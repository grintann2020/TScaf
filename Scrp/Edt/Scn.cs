using System.IO;
using System.Text;
using UnityEngine;

namespace T {

    public class Scnr : MonoBehaviour { // Scanner
        
        
        public string ExtPth; // extend path
        public string PrjNm;
        public string FlNm;
        public string ClsNm;
        public string ArrNm;
        public Transform Rt; // root
        protected  string _pth;
        protected string _enmStr;
        protected string _objStr;
        protected string _str;
        protected Transform[] _tfArr;
        
        protected const string DP = @"Assets\"; //default path
        protected const string EXT = ".cs"; // extends
        protected const string NS = "namespace"; // namespace
        protected const string CLS = "public partial class"; // class

        protected void Wrt(string cd, bool chk) {
            using (FileStream fs = File.Create(_pth)) {
                byte[] inf = new UTF8Encoding(true).GetBytes(cd);
                // Add some information to the file.
                fs.Write(inf, 0, inf.Length);
            }
            if (chk) {
                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(_pth)) {
                    string s = "";
                    while ((s = sr.ReadLine()) != null) {
                        Debug.Log(s);
                    }
                }
            }
            _enmStr = "";
            _objStr = "";
            _str = "";
        }

        protected string PrnStr(Transform tf, string str) {
            if (tf.parent != null && tf.parent != Rt) {
                if(tf.parent.GetComponent<Canvas>() == null || tf.parent == null) {
                    str = PrnStr(tf.parent, str) + tf.parent.name + "_" + str;
                }
            }
            return str;
        }
    }
}