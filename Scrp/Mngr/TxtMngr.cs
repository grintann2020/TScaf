using UnityEngine;

namespace T {

    public class TxtMngr : Sngltn<TxtMngr>, IMngr { // text manager

        public bool IsIntl { get { return _isIntl; } }
        private TxtPrm _txtPrm = null;
        private ITxt[] _iTxtArry = null;
        private byte[] _lnggArry = null;
        private byte _eCrrnLngg = 0;
        private bool _isIntl = false;

        public void Rst() {
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            _txtPrm = null;
            _iTxtArry = null;
            _lnggArry = null;
        }

        public void Intl(IPrm iPrm) {
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _txtPrm = (TxtPrm)iPrm;
            _iTxtArry = _txtPrm.ITxtArry;
            _lnggArry = _txtPrm.ELnggArry;
            _eCrrnLngg = LnggIndx(0);
        }

        public void Appl(byte eTxt) {
            if (_iTxtArry[eTxt] != null) {
                return;
            }
            _txtPrm.Prm(eTxt);
            _iTxtArry[eTxt].Appl();
        }

        public void Cncl(byte eTxt) {
            if (_iTxtArry[eTxt] == null) {
                return;
            }
            _iTxtArry[eTxt].Cncl();
            _txtPrm.Omt(eTxt);
        }

        public bool IsAppl(byte eTxt) { // return specific text is applied or not
            return _iTxtArry[eTxt] == null ? false : true;
        }

        public void Chng(byte eLngg) { // change to specific language by enum
            if (_eCrrnLngg == eLngg || Arry.Indx<byte>(_lnggArry, eLngg) == -1) {
                return;
            }
            _eCrrnLngg = eLngg;
        }

        public void Chng(SystemLanguage systLngg) { // change to specific language by (unity) system language
            if (_eCrrnLngg == (byte)systLngg || Arry.Indx<byte>(_lnggArry, (byte)systLngg) == -1) {
                return;
            }
            _eCrrnLngg = (byte)systLngg;
        }

        public string Strn(byte eTxt, ushort eStrn) { // return specific string in specific text by enum
            if (_iTxtArry[eTxt] == null) {
                return "disapplied";
            }
            return _iTxtArry[eTxt].StrnArry[eStrn][LnggIndx(_eCrrnLngg)];
        }

        public string Strn(byte eTxt, ushort eStrn, byte eLngg) {
            if (_iTxtArry[eTxt] == null) {
                return "disapplied";
            }
            return _iTxtArry[eTxt].StrnArry[eStrn][LnggIndx(eLngg)];
        }

        private byte LnggIndx(byte eLngg) {
            for (byte l = 0; l < _lnggArry.Length; l++) {
                if (_lnggArry[l] == eLngg) {
                    return l;
                }
            }
            return 0;
        }
    }
}