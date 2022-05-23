using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace T {

    public class UIMngr : Sngltn<UIMngr>, IMngr { // UI manager

        public Type[] TypArry = new Type[] {
            typeof(TMP_Text),
            typeof(Text),
            typeof(Image),
            typeof(Button),
        };
        public bool IsIntl { get { return _isIntl; } }
        private UIPrm _uIPrm = null;
        private IUI[] _iUIArry = null;
        private byte _eUI = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            Dtch();
            _uIPrm = null;
            _iUIArry = null;
            _isIntl = false;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _uIPrm = (UIPrm)iPrm;
            _iUIArry = _uIPrm.IUIArry;
            _isIntl = true;
        }

        public void Attc(Canvas cnvs, byte eUI, DActn dAftrAttc = null) {  // attach UI by generating all object groups, dAE = after attached
            if (_iUIArry[_eUI] != null) {
                _iUIArry[_eUI].Dtch();
                _uIPrm.Omt(_eUI);
            }
            _eUI = eUI;
            _uIPrm.Prm(_eUI);
            _iUIArry[_eUI].Attc(cnvs, dAftrAttc);
        }

        public void Attc(Canvas cnvs, byte eUI, byte eGrp, DActn dAftrAttc = null) {  // attach UI by generating specific object group by enum, dAE = after attached
            if (_iUIArry[_eUI] != null) {
                if (_eUI == eUI) {
                    if (_iUIArry[_eUI].IsGrpAttc(eGrp)) {
                        return;
                    } else {
                        _iUIArry[_eUI].Attc(cnvs, eGrp, dAftrAttc);
                        return;
                    }
                } else {
                    _iUIArry[_eUI].Dtch();
                    _uIPrm.Omt(_eUI);
                }
            }
            _eUI = eUI;
            _uIPrm.Prm(_eUI);
            _iUIArry[_eUI].Attc(cnvs, eGrp, dAftrAttc);
        }

        public void Dtch() {  // detach current UI from canvas
            if (_iUIArry[_eUI] != null) {
                _iUIArry[_eUI].Dtch();
                _uIPrm.Omt(_eUI);
            };
        }

        public void Dtch(byte eGrp) {  // detach specific UI from canvas by enum
            if (_iUIArry[_eUI] != null) {
                _iUIArry[_eUI].Dtch(eGrp);
                if (!_iUIArry[_eUI].IsAttc) {
                    _uIPrm.Omt(_eUI);
                }
            };
        }

        public void PrpUpdt() { // prop update
            _iUIArry[_eUI]?.PrpUpdt();
        }

        public bool IsAttc() { // return current UI is attached or not
            return _iUIArry[_eUI] == null ? false : true;
        }

        public bool IsAttc(byte eUI) { // return specific UI is attached or not
            return _iUIArry[eUI] == null ? false : true;
        }

        public bool IsGrpAttc(byte eGrp) {
            if (_iUIArry[_eUI] == null) {
                return false;
            }
            return _iUIArry[_eUI].IsGrpAttc(eGrp);
        }

        public bool IsGrpAttc(byte eUI, byte eGrp) {
            if (_iUIArry[eUI] == null) {
                return false;
            }
            return _iUIArry[eUI].IsGrpAttc(eGrp);
        }

        public IUI UI() { // return specific UI by enum
            return _iUIArry[_eUI];
        }

        public IUI UI(byte eUI) { // return specific UI by enum
            return _iUIArry[eUI];
        }

        public GameObject GmObjc(byte eGrp, byte eObj) { // return specific gameObject in specific group by enum
            return _iUIArry[_eUI].GmObjc(eGrp, eObj);
        }

        public GameObject GmObjc(byte eUI, byte eGrp, byte eObj) { // return specific gameObject in specific group by enum
            if (_iUIArry[eUI] == null) {
                return null;
            }
            return _iUIArry[eUI].GmObjc(eGrp, eObj);
        }

        public T Cmpn<T>(byte eGrp, byte eCmpn) { // return specific component bye enum
            return _iUIArry[_eUI].Cmpn<T>(eGrp, eCmpn);
        }

        public void Actv(byte eGrp) { // activate specific behavior group by enum
            _iUIArry[_eUI].Actv(eGrp);
        }

        public void Hlt(byte eGrp) { // halt specific behavior group by enum
            _iUIArry[_eUI].Hlt(eGrp);
        }

        public void Actv(byte eGrp, byte eBhvr) { // activate specific behavior in specific group by enum
            _iUIArry[_eUI].Actv(eGrp, eBhvr);
        }

        public void Hlt(byte eGrp, byte eBhvr) { // halt specific behavior in specific group by enum
            _iUIArry[_eUI].Hlt(eGrp, eBhvr); 
        }

        public void Enbl(byte eGrp) { // enable specific object group by enum
            _iUIArry[_eUI].Enbl(eGrp);
        }

        public void Dsbl(byte eGrp) { // disable specific object group by enum
            _iUIArry[_eUI].Dsbl(eGrp);
        }

        public void Enbl(byte eGrp, byte eObj) { // enable specific object in specific group by enum
            _iUIArry[_eUI].Enbl(eGrp, eObj);
        }

        public void Dsbl(byte eGrp, byte eObj) { // disable specific object in specific group by enum
            _iUIArry[_eUI].Dsbl(eGrp, eObj);
        }

        public void Frnt(byte eGrp) {
            _iUIArry[_eUI].Frnt(eGrp);
        }

        public void Bck(byte eGrp) {
            _iUIArry[_eUI].Bck(eGrp);
        }

        public void Frnt(byte eGrp, byte eObj) {
            _iUIArry[_eUI].Frnt(eGrp, eObj);
        }

        public void Bck(byte eGrp, byte eObj) {
            _iUIArry[_eUI].Bck(eGrp, eObj);
        }
    }
}