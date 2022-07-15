using System.IO;
using System.Text;
using UnityEngine;

namespace T {

    public class Scnr : MonoBehaviour { // Scanner
        
        
        public string ExtnPth; // extend path
        public string PrjcNm;
        public string FlNm;
        public string ClssNm;
        public string ArryNm;
        public Transform Rt; // root
        protected  string _pth;
        protected string _enmStrn;
        protected string _objcStrn;
        protected string _strn;
        protected Transform[] _trnsfrms;
        
        protected const string DFLTPTH = @"Assets\"; //default path
        protected const string EXTN = ".cs"; // extends
        protected const string NMSPC = "namespace"; // namespace
        protected const string CLSS = "public partial class"; // class

        protected void Wrt(string code, bool chk) {
            using (FileStream fs = File.Create(_pth)) {
                byte[] info = new UTF8Encoding(true).GetBytes(code);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
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
            _enmStrn = "";
            _objcStrn = "";
            _strn = "";
        }

        protected string PrntStrn(Transform trnsfrm, string strn) {
            if (trnsfrm.parent != null && trnsfrm.parent != Rt) {
                if(trnsfrm.parent.GetComponent<Canvas>() == null || trnsfrm.parent == null) {
                    strn = PrntStrn(trnsfrm.parent, strn) + trnsfrm.parent.name + "_" + strn;
                }
            }
            return strn;
        }
    }
}