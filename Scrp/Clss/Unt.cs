using UnityEngine;

namespace T {

    public class Unt { // unit
        
        public GameObject[] GmObjcArry { get { return _gmObjcArry; } } // get the array of GameObjects in unit
        public SGrd3 SPstn { get { return _sPstn; } } // get position
        public SVctr3 SCrd { get { return _sCrd; } } // get coordinate
        public float X { get { return _sCrd.X; } } // get x axis
        public float Z { get { return _sCrd.Z; } } // get z axis
        public float Y { get { return _sCrd.Y; } } // get y axis
        public ushort Rw { get { return _sPstn.Rw; } } // get row
        public ushort Clmn { get { return _sPstn.Clmn; } } //get column
        public ushort Lyr { get { return _sPstn.Lyr; } } // get layer
        private GameObject[] _gmObjcArry; // an array of admitted GameObjects
        private SGrd3 _sPstn; // grid3 struct for position 
        private SVctr3 _sCrd; // vector3 struct for coordinate 

        public Unt(SGrd3 sPstn, SVctr3 sCrd) { // unit
            _sPstn = sPstn;
            _sCrd = sCrd;
            _gmObjcArry = new GameObject[0];
        }

        public void Admt(GameObject gmObjc) {
            _gmObjcArry = Arry.Add<GameObject>(_gmObjcArry, gmObjc);
        }

        public void Omt(GameObject gmObjc) {
            _gmObjcArry = Arry.Rmv<GameObject>(_gmObjcArry, (ushort)Arry.Indx<GameObject>(_gmObjcArry, gmObjc));
        }

        public void Omt(byte indx) {
            _gmObjcArry = Arry.Rmv<GameObject>(_gmObjcArry, (ushort)indx);
        }

        public void Omt() {
            _gmObjcArry = new GameObject[0];
        }
    }
}