using UnityEngine;

namespace T {

    public class Unt { // unit

        public object[] CntnArry { get { return _cntnArry; } } // get the array of contents in unit
        public SGrd3 SGrd { get { return _sGrd; } } // get position
        public SVctr3 SPstn { get { return _sPstn; } } // get coordinate
        public float X { get { return _sPstn.X; } } // get x axis
        public float Z { get { return _sPstn.Z; } } // get z axis
        public float Y { get { return _sPstn.Y; } } // get y axis
        public int Rw { get { return _sGrd.Row; } } // get row
        public int Clmn { get { return _sGrd.Clmn; } } //get column
        public int Lyr { get { return _sGrd.Lyr; } } // get layer
        private SGrd3 _sGrd; // grid3 struct for position 
        private SVctr3 _sPstn; // vector3 struct for coordinate 
        private object[] _cntnArry; // an array of admitted contents

        public Unt(SGrd3 sGrd, SVctr3 sPstn) { // unit
            _sGrd = sGrd;
            _sPstn = sPstn;
        }

        public void Admt<T>(T objc) {
            _cntnArry = Arry.Add<object>(_cntnArry, objc);
        }

        public void Omt(object objc) {
            _cntnArry = Arry.Rmv<object>(_cntnArry, Arry.Indx<object>(_cntnArry, objc));
        }

        public void Omt(byte indx) {
            _cntnArry = Arry.Rmv<object>(_cntnArry, indx);
        }

        public void Omt() {
            _cntnArry = new object[0];
        }
    }
}