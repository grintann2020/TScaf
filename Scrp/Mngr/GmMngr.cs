using UnityEngine;

namespace T {

    public class GmMngr : Sngltn<GmMngr>, IMngr { // game manager

        public bool IsIntl { get { return _isIntl; } }
        private GmPrm _gmPrm = null;
        private SttngsSO _sttngs = null;
        private bool _isIntl = false;

        public void Rst() {
            if (!_isIntl) {
                return;
            }
            for (byte p = 0; p < _gmPrm.IPrmArry.Length; p++) {
                _gmPrm.IPrmArry[p] = null;
            }
            _gmPrm = null;
            _isIntl = false;
        }

        public void Intl(IPrm iPrm) {
            if (_isIntl) {
                return;
            }
            _gmPrm = (GmPrm)iPrm;
            for (byte p = 0; p < _gmPrm.IPrmArry.Length; p++) {
                _gmPrm.Prm(p);
                if (_gmPrm.IMngrArry[p] != null) {
                    _gmPrm.IMngrArry[p].Intl(_gmPrm.IPrmArry[p]);
                }
            }
            _isIntl = true;
        }

        public void PrpUpdt() { // prop update
            if (!_isIntl) {
                return;
            }
            PrgmMngr.Inst.PrpUpdt();
        }

        public void Sttngs(SttngsSO sttngs) {
            _sttngs = sttngs;
        }

        public void Strt() {
            PrgmMngr.Inst.Exct(_sttngs.FrstPrgm);
            SttngsRslt(2);
        }

        public void SttngsRslt() { // setting resolution
            Screen.SetResolution(_sttngs.ScrnRslt.Wdth, _sttngs.ScrnRslt.Hght, true);
            // Debug.Log("Screen Resolution --> Width: " + _scrRez.Wd + ", Height: " + _scrRez.Ht + ", aspect ratio: " + _scrRez.AR);
        }

        public void SttngsRslt(byte lvl) { // setting resolution
            if (lvl > _sttngs.ScrnRslt.NmbrOfLvl) {
                lvl = _sttngs.ScrnRslt.NmbrOfLvl;
            }
            _sttngs.ScrnRslt.Lvl = lvl;
            Screen.SetResolution(_sttngs.ScrnRslt.Wdth, _sttngs.ScrnRslt.Hght, true);
            // Debug.Log("Screen Resolution --> Width: " + _scrRez.Wd + ", Height: " + _scrRez.Ht + ", aspect ratio: " + _scrRez.AR);
        }
    }
}