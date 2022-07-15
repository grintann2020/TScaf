using UnityEngine;

namespace T {

    public class TxtMngr : Sngltn<TxtMngr>, IMngr { // text manager

        public bool IsIntl { get { return _isIntl; } }
        private TxtPrm _txtPrm = null;
        private ITxt[] _iTxts = null;
        private byte[] _lnggs = null;
        private byte _eCrrnLngg = 0;
        private bool _isIntl = false;

        public void Rst() {
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            _txtPrm = null;
            _iTxts = null;
            _lnggs = null;
        }

        public void Intl(IPrm iPrm) {
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _txtPrm = (TxtPrm)iPrm;
            _iTxts = _txtPrm.ITxts;
            _lnggs = _txtPrm.ELnggs;
            _eCrrnLngg = LnggIndx(0);
        }

        public void Appl(byte eTxt) {
            if (_iTxts[eTxt] != null) {
                return;
            }
            _txtPrm.Prm(eTxt);
            _iTxts[eTxt].Appl();
        }

        public void Cncl(byte eTxt) {
            if (_iTxts[eTxt] == null) {
                return;
            }
            _iTxts[eTxt].Cncl();
            _txtPrm.Omt(eTxt);
        }

        public bool IsAppl(byte eTxt) { // return specific text is applied or not
            return _iTxts[eTxt] == null ? false : true;
        }

        public void Chng(byte eLngg) { // change to specific language by enum
            if (_eCrrnLngg == eLngg || Arry.Indx<byte>(_lnggs, eLngg) == -1) {
                return;
            }
            _eCrrnLngg = eLngg;
        }

        public void Chng(SystemLanguage systLngg) { // change to specific language by (unity) system language
            if (_eCrrnLngg == (byte)systLngg || Arry.Indx<byte>(_lnggs, (byte)systLngg) == -1) {
                return;
            }
            _eCrrnLngg = (byte)systLngg;
        }

        public string Strn(byte eTxt, ushort eStrn) { // return specific string in specific text by enum
            if (_iTxts[eTxt] == null) {
                return "disapplied";
            }
            return _iTxts[eTxt].Strns[eStrn][LnggIndx(_eCrrnLngg)];
        }

        public string Strn(byte eTxt, ushort eStrn, byte eLngg) {
            if (_iTxts[eTxt] == null) {
                return "disapplied";
            }
            return _iTxts[eTxt].Strns[eStrn][LnggIndx(eLngg)];
        }

        private byte LnggIndx(byte eLngg) {
            for (byte l = 0; l < _lnggs.Length; l++) {
                if (_lnggs[l] == eLngg) {
                    return l;
                }
            }
            return 0;
        }
    }
}