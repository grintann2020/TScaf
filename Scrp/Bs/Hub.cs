using System;
using UnityEngine;

namespace T {

    public class Hb {
        
        public HbMngr Mngr { set { _mngr = value; } }
        public bool IsCnnc { get { return _isCnnc; } }
        protected HbMngr _mngr = null;
        protected delegate void _dMot(); // step
        protected delegate bool _dFrg(); // forgo
        protected DActn[] _actArry;
        protected _dMot[] _motArry;
        protected _dFrg[] _frgArry;
        protected GameObject[] _gmObjcArry;
        protected object[] _vlArry;
        // private bool[] _mtvArry;
        // private byte _eMot;
        private bool _isCnnc;

        public virtual void Cnnc() {
            _isCnnc = true;
            // RstArry();
        }

        public virtual void Dscn() {
            _isCnnc = false;
            // RstArry();
        }

        public void PrpUpdt() {
            if (_isCnnc == false) {
                return;
            }
            // if (_mtvArry[_eMot] == true) {
            //     if (_motArry[_eMot] != null) {
            //         _motArry[_eMot].Invoke();
            //     }
            //     if (_frgArry[_eMot].Invoke()) {
            //         _mtvArry[_eMot] = false;
            //     }
            // }
        }

        public void Act(byte eAct) {
            _actArry[eAct]();
        }

        // public void Mot(byte eMot) {
        //     if (_mtvArry[eMot] == false) {
        //         _mtvArry[_eMot] = false;
        //         _mtvArry[eMot] = true;
        //         _eMot = eMot;
        //     }
        // }

        public void StGO(byte eGO, GameObject go) {
            _gmObjcArry[eGO] = go;
        }

        public GameObject GtGO(byte eGO) {
            return _gmObjcArry[eGO];
        }

        public void StVal<T>(byte eVal, T val) {
            _vlArry[eVal] = val;
        }

        public T GtVal<T>(byte eVal) {
            return (T)_vlArry[eVal];
        }

        // private void RstArry() {
        //     _mtvArry = new bool[_motArry.Length];
        //     for (byte g = 0; g < _gmObjcArry.Length; g++) {
        //         _gmObjcArry[g] = null;
        //     }
        //     for (byte v = 0; v < _vlArry.Length; v++) {
        //         _vlArry[v] = null;
        //     }
        //     for (byte m = 0; m < _motArry.Length; m++) {
        //         _mtvArry[m] = false;
        //     }
        // }
    }
}