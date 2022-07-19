using UnityEngine;

namespace T {

    public class Unt { // unit

        public object[] CntArr { get { return _cntArr; } } // get the array of contents in unit
        public SGrd3 SGrd { get { return _sGrd; } } // get position
        public SVct3 SPst { get { return _sPst; } } // get coordinate
        public float X { get { return _sPst.X; } } // get x axis
        public float Z { get { return _sPst.Z; } } // get z axis
        public float Y { get { return _sPst.Y; } } // get y axis
        public int Rw { get { return _sGrd.Rw; } } // get row
        public int Clm { get { return _sGrd.Clm; } } //get column
        public int Lyr { get { return _sGrd.Lyr; } } // get layer
        private SGrd3 _sGrd; // grid3 struct for position 
        private SVct3 _sPst; // vector3 struct for coordinate 
        private object[] _cntArr; // an array of admitted contents

        public Unt(SGrd3 sGrd, SVct3 sPst) { // unit
            _sGrd = sGrd;
            _sPst = sPst;
        }

        public void Admt<T>(T objc) {
            _cntArr = Arr.Add<object>(_cntArr, objc);
        }

        public void Omt(object objc) {
            _cntArr = Arr.Rmv<object>(_cntArr, Arr.Idx<object>(_cntArr, objc));
        }

        public void Omt(byte indx) {
            _cntArr = Arr.Rmv<object>(_cntArr, indx);
        }

        public void Omt() {
            _cntArr = new object[0];
        }
    }
}