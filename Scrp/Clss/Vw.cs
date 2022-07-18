using UnityEngine;

namespace T {

    public class Vw {

        public VwMng Mng { set { _mng = value; } } // set manager
        public bool IsStUp { get { return _isStUp; } } // get is setuped or not
        public bool IsMv { get { return _isMv; } }
        protected Camera[] _cmrArr = null; // the array of cameras
        protected SCmrPrj[] _prjArr = null; // the array of projections
        protected SOrn3[] _ornArr = null; // the array of orients
        protected VwMng _mng = null; // view manager
        protected byte[][] _stArr = null; // the array of sets
        private bool _isStUp = false; // is setuped or not
        private bool _isMv = false;

        public void StUp(Camera[] cmrArr) {
            if (_isStUp || _isMv || cmrArr == null || _stArr == null) {
                return;
            }
            _isStUp = true;
            _isMv = false;
            _cmrArr = cmrArr;
            Dfl();
        }

        public void StDwn() {
            if (!_isStUp || _isMv) {
                return;
            }
            _isStUp = false;
            _isMv = false;
            _cmrArr = null;
            _prjArr = null;
            _ornArr = null;
            _mng = null;
            _stArr = null;
        }

        public void PrpUpd() { // prop update
            if (!_isStUp || !_isMv) {
                return;
            }
        }

        public void Dfl() {
            for (byte c = 0; c < _cmrArr.Length; c++) {
                for (byte s = 0; s < _stArr.Length; s++) {
                    if (c == _stArr[s][0]) {
                        Prj(c, _stArr[s][1]);
                        Orn(c, _stArr[s][2]);
                        break;
                    }
                }
            }
        }

        public void Prj(byte ePrj) {
            CmrPrj(_cmrArr[0], _prjArr[ePrj]);
        }

        public void Prj(byte eCmr, byte ePrj) {
            CmrPrj(_cmrArr[eCmr], _prjArr[ePrj]);
        }

        public void Prj(SCmrPrj prj) {
            CmrPrj(_cmrArr[0], prj);
        }

        public void Prj(byte eCmr, SCmrPrj prj) {
            CmrPrj(_cmrArr[eCmr], prj);
        }

        public void Orn(byte eOrn) {
            CmrOrn(_cmrArr[0], _ornArr[eOrn]);
        }

        public void Orn(SOrn3 orn) {
            CmrOrn(_cmrArr[0], orn);
        }

        public void Orn(byte eCmr, byte eOrn) {
            CmrOrn(_cmrArr[eCmr], _ornArr[eOrn]);
        }

        public void Orn(byte eCmr, SOrn3 orn) {
            CmrOrn(_cmrArr[eCmr], orn);
        }

        public void St(byte eSt) {
            Prj(_stArr[eSt][0], _stArr[eSt][1]);
            Orn(_stArr[eSt][0], _stArr[eSt][2]);
        }

        private void CmrPrj(Camera cmr, SCmrPrj prj) {
            cmr.orthographic = prj.Og;
            cmr.orthographicSize = prj.OgSz;
            cmr.fieldOfView = prj.FOV;
            cmr.nearClipPlane = prj.NCP;
            cmr.farClipPlane = prj.FCP;
            cmr.usePhysicalProperties = prj.PhyCmr;
        }

        private void CmrOrn(Camera cmr, SOrn3 orn) {
            cmr.transform.position = new Vector3(orn.P0.X, orn.P0.Y, orn.P0.Z);
            cmr.transform.LookAt(new Vector3(orn.P1.X, orn.P1.Y, orn.P1.Z));
        }
    }
}