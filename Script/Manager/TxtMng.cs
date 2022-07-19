using UnityEngine;

namespace T {

    public class TxtMng : Sng<TxtMng>, IMng { // text manager

        public bool IsInt { get { return _isInt; } }
        private TxtPrm _txtPrm = null;
        private ITxt[] _iTxtArr = null;
        private byte[] _lngArr = null;
        private byte _eCrrLng = 0;
        private bool _isInt = false;

        public void Rst() {
            if (!_isInt) {
                return;
            }
            _isInt = false;
            _txtPrm = null;
            _iTxtArr = null;
            _lngArr = null;
        }

        public void Int(IPrm iPrm) {
            if (_isInt) {
                return;
            }
            _isInt = true;
            _txtPrm = (TxtPrm)iPrm;
            _iTxtArr = _txtPrm.ITxtArr;
            _lngArr = _txtPrm.ELngArr;
            _eCrrLng = LngIdx(0);
        }

        public void App(byte eTxt) { // apply
            if (_iTxtArr[eTxt] != null) {
                return;
            }
            _txtPrm.Prm(eTxt);
            _iTxtArr[eTxt].App();
        }

        public void Cnc(byte eTxt) { // cancel
            if (_iTxtArr[eTxt] == null) {
                return;
            }
            _iTxtArr[eTxt].Cnc();
            _txtPrm.Omt(eTxt);
        }

        public bool IsApp(byte eTxt) { // return specific text is applied or not
            return _iTxtArr[eTxt] == null ? false : true;
        }

        public void Chn(byte eLng) { // change to specific language by enum
            if (_eCrrLng == eLng || Arr.Idx<byte>(_lngArr, eLng) == -1) {
                return;
            }
            _eCrrLng = eLng;
        }

        public void Chn(SystemLanguage systLng) { // change to specific language by (unity) system language
            if (_eCrrLng == (byte)systLng || Arr.Idx<byte>(_lngArr, (byte)systLng) == -1) {
                return;
            }
            _eCrrLng = (byte)systLng;
        }

        public string Str(byte eTxt, ushort eStr) { // return specific string in specific text by enum
            if (_iTxtArr[eTxt] == null) {
                return "disapplied";
            }
            return _iTxtArr[eTxt].StrArr2[eStr][LngIdx(_eCrrLng)];
        }

        public string Str(byte eTxt, ushort eStr, byte eLng) {
            if (_iTxtArr[eTxt] == null) {
                return "disapplied";
            }
            return _iTxtArr[eTxt].StrArr2[eStr][LngIdx(eLng)];
        }

        private byte LngIdx(byte eLng) {
            for (byte l = 0; l < _lngArr.Length; l++) {
                if (_lngArr[l] == eLng) {
                    return l;
                }
            }
            return 0;
        }
    }
}