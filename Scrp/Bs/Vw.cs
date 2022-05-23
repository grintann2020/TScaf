using UnityEngine;

namespace T {

    public class Vw {

        public VwMngr Mngr { set { _mngr = value; } }
        public bool IsStup { get { return _isStup; } }
        public bool IsMv { get { return _isMv; } }
        protected VwMngr _mngr = null;
        protected Camera[] _cmrArry = null;
        protected SCmrPrjc[] _prjcArry = null;
        protected SOrnt3[] _orntArry = null;
        protected byte[][] _stArry = null;
        private bool _isStup = false;

        // protected ushort[] _stpArry;
        // protected SCoord3[][][] _trkArry;
        // protected byte[][] _movArry;

        // private byte _eMov = 0;

        private bool _isMv = false;

        public void Stup(Camera[] cmrArry) {
            if (_isStup || _isMv) {
                return;
            }
            // _eMov = 0;
            _cmrArry = cmrArry;
            Dflt();
            _isStup = true;
            _isMv = false;
        }

        public void Stdwn() {
            if (!_isStup || _isMv) {
                return;
            }
            // _eMov = 0;
            _cmrArry = null;
            _prjcArry = null;
            _orntArry = null;
            _stArry = null;
            _isStup = false;
            _isMv = false;
            // for (byte s = 0; s < _stpArry.Length; s++) {
            //     _stpArry[s] = 0;
            // }
        }

        public void PrpUpdt() { // prop update
            if (!_isStup || !_isMv) {
                return;
            }

            // Ornt(_trkArry[_eMov][_stpArry[_eMov]][0], _trkArry[_eMov][_stpArry[_eMov]][1]);
            // _stpArry[_eMov] += 1;
            // if (_stpArry[_eMov] == _trkArry[_eMov].Length) {
            //     _stpArry[_eMov] = 0;
            //     _isMov = false;
            // }
        }

        public void Dflt() {
            for (byte c = 0; c < _cmrArry.Length; c++) {
                for (byte s = 0; s < _stArry.Length; s++) {
                    if (c == _stArry[s][0]) {
                        Prjc(c, _stArry[s][1]);
                        Ornt(c, _stArry[s][2]);
                        break;
                    }
                }
            }
        }

        public void Prjc(byte ePrjc) {
            CmrPrjc(_cmrArry[0], _prjcArry[ePrjc]);
        }

        public void Prjc(byte eCmr, byte ePrjc) {
            CmrPrjc(_cmrArry[eCmr], _prjcArry[ePrjc]);
        }

        public void Prjc(SCmrPrjc prjc) {
            CmrPrjc(_cmrArry[0], prjc);
        }

        public void Prjc(byte eCmr, SCmrPrjc prjc) {
            CmrPrjc(_cmrArry[eCmr], prjc);
        }

        public void Ornt(byte eOrnt) {
            CmrOrnt(_cmrArry[0], _orntArry[eOrnt]);
        }

        public void Ornt(SOrnt3 ornt) {
            CmrOrnt(_cmrArry[0], ornt);
        }

        public void Ornt(byte eCmr, byte eOrnt) {
            CmrOrnt(_cmrArry[eCmr], _orntArry[eOrnt]);
        }

        public void Ornt(byte eCmr, SOrnt3 ornt) {
            CmrOrnt(_cmrArry[eCmr], ornt);
        }

        public void Set(byte eSet) {
            Prjc(_stArry[eSet][0], _stArry[eSet][1]);
            Ornt(_stArry[eSet][0], _stArry[eSet][2]);
        }

        // public void Mov(byte eMov) {
        //     if (_isMov == true) {
        //         return;
        //     }
        //     _isMov = true;
        //     _eMov = eMov;
        //     _stpArry[_eMov] = 0;
        // }

        private void CmrPrjc(Camera cmr, SCmrPrjc prjc) {
            cmr.orthographic = prjc.Orthgrph;
            cmr.orthographicSize = prjc.Sz;
            cmr.nearClipPlane = prjc.Nr;
            cmr.farClipPlane = prjc.Fr;
            // _cmr.fieldOfView = prj.FOV;
            // _cmr.usePhysicalProperties = prj.PhyCmr;
        }

        private void CmrOrnt(Camera cmr, SOrnt3 ornt) {
            cmr.transform.position = new Vector3(ornt.A.X, ornt.A.Y, ornt.A.Z);
            cmr.transform.LookAt(new Vector3(ornt.B.X, ornt.B.Y, ornt.B.Z));
        }
    }
}