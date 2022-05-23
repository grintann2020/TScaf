using System;
using UnityEngine;

namespace T {

    public class Blck {
        
        public SGrd3 Grd { get { return _grid; } }
        public SCrdn3 Crdn { get { return _crdn; } }
        public GameObject[] GmObjcArry { get { return _gmObjcArry; } }
        public ushort Rw { get { return _grid.Rw; } }
        public ushort Clmn { get { return _grid.Clmn; } }
        public ushort Lyr { get { return _grid.Lyr; } }
        public float X { get { return _crdn.X; } }
        public float Z { get { return _crdn.Z; } }
        public float Y { get { return _crdn.Y; } }
        public byte EUnt { get; set; }
        private SGrd3 _grid;
        private SCrdn3 _crdn;
        private GameObject[] _gmObjcArry;

        public Blck(SGrd3 grid, SCrdn3 crdn) {
            _grid = grid;
            _crdn = crdn;
            _gmObjcArry = new GameObject[0];
        }

        public void MvIn(GameObject gmObjc) {
            _gmObjcArry = Arry.Add<GameObject>(_gmObjcArry, gmObjc);
        }

        public void MvOt(GameObject gmObjc) {
            _gmObjcArry = Arry.Rmv<GameObject>(_gmObjcArry, (ushort)Arry.Indx<GameObject>(_gmObjcArry, gmObjc));
        }

        public void MvOt(byte indx) {
            _gmObjcArry = Arry.Rmv<GameObject>(_gmObjcArry, (ushort)indx);
        }

        public void MvOt() {
            _gmObjcArry = new GameObject[0];
        }
    }
}