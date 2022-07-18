using UnityEngine;

namespace T {

    public class GmMng : Sng<GmMng>, IMng { // game manager

        public bool IsInt { get { return _isInt; } }
        private GmPrm _gmPrm = null;
        private SttSO _stt = null;
        private bool _isInt = false;

        public void Rst() {
            if (!_isInt) {
                return;
            }
            for (byte p = 0; p < _gmPrm.IPrmArr.Length; p++) {
                _gmPrm.IPrmArr[p] = null;
            }
            _gmPrm = null;
            _isInt = false;
        }

        public void Int(IPrm iPrm) {
            if (_isInt) {
                return;
            }
            _gmPrm = (GmPrm)iPrm;
            for (byte p = 0; p < _gmPrm.IPrmArr.Length; p++) {
                _gmPrm.Prm(p);
                if (_gmPrm.IMngArr[p] != null) {
                    _gmPrm.IMngArr[p].Int(_gmPrm.IPrmArr[p]);
                }
            }
            _isInt = true;
        }

        public void PrpUpd() { // prop update
            if (!_isInt) {
                return;
            }
            PrgMng.Ins.PrpUpd();
        }

        public void Stt(SttSO stt) {
            _stt = stt;
        }

        public void Str() {
            PrgMng.Ins.Exc(_stt.FrsPrg);
            SttRslt(2);
        }

        public void SttRslt() { // setting resolution
            Screen.SetResolution(_stt.ScrRslt.Wdt, _stt.ScrRslt.Hgh, true);
            // Debug.Log("Screen Resolution --> Width: " + _scrRez.Wd + ", Height: " + _scrRez.Ht + ", aspect ratio: " + _scrRez.AR);
        }

        public void SttRslt(byte lvl) { // setting resolution
            if (lvl > _stt.ScrRslt.NOL) {
                lvl = _stt.ScrRslt.NOL;
            }
            _stt.ScrRslt.Lvl = lvl;
            Screen.SetResolution(_stt.ScrRslt.Wdt, _stt.ScrRslt.Hgh, true);
            // Debug.Log("Screen Resolution --> Width: " + _scrRez.Wd + ", Height: " + _scrRez.Ht + ", aspect ratio: " + _scrRez.AR);
        }
    }
}