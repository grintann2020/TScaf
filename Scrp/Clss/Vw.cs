using UnityEngine;

namespace T {

    public class Vw {

        public VwMngr Mngr { set { _mngr = value; } } // set manager
        public bool IsStup { get { return _isStup; } } // get is setuped or not
        public bool IsMv { get { return _isMv; } }
        protected Camera[] _cmrArry = null; // the array of cameras
        protected SCmrPrjc[] _prjcArry = null; // the array of projections
        protected SOrnt3[] _orntArry = null; // the array of orients
        protected VwMngr _mngr = null; // view manager
        protected byte[][] _stArry = null; // the array of sets
        private bool _isStup = false; // is setuped or not

        // protected SCoord3[][][] _trkArry;
        // protected byte[][] _movArry;
        // private byte _eMov = 0;
        private bool _isMv = false;

        public void Stup(Camera[] cmrArry) {
            if (_isStup || _isMv || cmrArry == null || _stArry == null) {
                return;
            }
            _isStup = true;
            _isMv = false;
            // _eMov = 0;
            _cmrArry = cmrArry;
            Dflt();
        }

        public void Stdwn() {
            if (!_isStup || _isMv) {
                return;
            }
            _isStup = false;
            _isMv = false;
            // _eMov = 0;
            _cmrArry = null;
            _prjcArry = null;
            _orntArry = null;
            _mngr = null;
            _stArry = null;
            
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

        public void St(byte eSt) {
            Prjc(_stArry[eSt][0], _stArry[eSt][1]);
            Ornt(_stArry[eSt][0], _stArry[eSt][2]);
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
            cmr.orthographicSize = prjc.OrthgrphSz;
            cmr.fieldOfView = prjc.FOV;
            cmr.nearClipPlane = prjc.Nr;
            cmr.farClipPlane = prjc.Fr;
            cmr.usePhysicalProperties = prjc.PhyCmr;
        }

        private void CmrOrnt(Camera cmr, SOrnt3 ornt) {
            cmr.transform.position = new Vector3(ornt.P0.X, ornt.P0.Y, ornt.P0.Z);
            cmr.transform.LookAt(new Vector3(ornt.P1.X, ornt.P1.Y, ornt.P1.Z));
        }
    }
}