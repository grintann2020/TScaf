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
        private byte _eCrrnUI = 0;
        private bool _isIntl = false;

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Dtch();
            _uIPrm = null;
            _iUIArry = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _uIPrm = (UIPrm)iPrm;
            _iUIArry = _uIPrm.IUIArry;
        }

        public void Attc(Canvas cnvs, byte eUI, DActn dAftrAttc = null) {  // attach UI by generating all object groups, dAE = after attached
            if (_iUIArry[_eCrrnUI] != null) {
                _iUIArry[_eCrrnUI].Dtch();
                _uIPrm.Omt(_eCrrnUI);
            }
            _eCrrnUI = eUI;
            _uIPrm.Prm(_eCrrnUI);
            _iUIArry[_eCrrnUI].Attc(cnvs, dAftrAttc);
        }

        public void Attc(Canvas cnvs, byte eUI, byte eGrp, DActn dAftrAttc = null) {  // attach UI by generating specific object group by enum, dAE = after attached
            if (_iUIArry[_eCrrnUI] != null) {
                if (_eCrrnUI == eUI) {
                    if (_iUIArry[_eCrrnUI].IsGrpAttc(eGrp)) {
                        return;
                    } else {
                        _iUIArry[_eCrrnUI].Attc(cnvs, eGrp, dAftrAttc);
                        return;
                    }
                } else {
                    _iUIArry[_eCrrnUI].Dtch();
                    _uIPrm.Omt(_eCrrnUI);
                }
            }
            _eCrrnUI = eUI;
            _uIPrm.Prm(_eCrrnUI);
            _iUIArry[_eCrrnUI].Attc(cnvs, eGrp, dAftrAttc);
        }

        public void Dtch() {  // detach current UI from canvas
            if (_iUIArry[_eCrrnUI] != null) {
                _iUIArry[_eCrrnUI].Dtch();
                _uIPrm.Omt(_eCrrnUI);
            };
        }

        public void Dtch(byte eGrp) {  // detach specific UI from canvas by enum
            if (_iUIArry[_eCrrnUI] != null) {
                _iUIArry[_eCrrnUI].Dtch(eGrp);
                if (!_iUIArry[_eCrrnUI].IsAttc) {
                    _uIPrm.Omt(_eCrrnUI);
                }
            };
        }

        public void PrpUpdt() { // prop update
            _iUIArry[_eCrrnUI]?.PrpUpdt();
        }

        public IUI GtIUI() { // return specific UI by enum
            return _iUIArry[_eCrrnUI];
        }

        public GameObject GtGmObjc(byte eGrp, byte eObj) { // return specific gameObject in specific group by enum
            return _iUIArry[_eCrrnUI].GtGmObjc(eGrp, eObj);
        }

        public T GtCmpn<T>(byte eGrp, byte eCmpn) { // return specific component bye enum
            return _iUIArry[_eCrrnUI].GtCmpn<T>(eGrp, eCmpn);
        }

        public bool IsAttc(byte eUI) { // return specific UI is attached or not
            return _iUIArry[eUI] == null ? false : true;
        }

        public bool IsGrpAttc(byte eGrp) {
            if (_iUIArry[_eCrrnUI] == null) {
                return false;
            }
            return _iUIArry[_eCrrnUI].IsGrpAttc(eGrp);
        }

        public void Actv(byte eGrp) { // activate specific behavior group by enum
            _iUIArry[_eCrrnUI].Actv(eGrp);
        }

        public void Hlt(byte eGrp) { // halt specific behavior group by enum
            _iUIArry[_eCrrnUI].Hlt(eGrp);
        }

        public void Actv(byte eGrp, byte eBhvr) { // activate specific behavior in specific group by enum
            _iUIArry[_eCrrnUI].Actv(eGrp, eBhvr);
        }

        public void Hlt(byte eGrp, byte eBhvr) { // halt specific behavior in specific group by enum
            _iUIArry[_eCrrnUI].Hlt(eGrp, eBhvr); 
        }

        public void Enbl(byte eGrp) { // enable specific object group by enum
            _iUIArry[_eCrrnUI].Enbl(eGrp);
        }

        public void Dsbl(byte eGrp) { // disable specific object group by enum
            _iUIArry[_eCrrnUI].Dsbl(eGrp);
        }

        public void Enbl(byte eGrp, byte eObj) { // enable specific object in specific group by enum
            _iUIArry[_eCrrnUI].Enbl(eGrp, eObj);
        }

        public void Dsbl(byte eGrp, byte eObj) { // disable specific object in specific group by enum
            _iUIArry[_eCrrnUI].Dsbl(eGrp, eObj);
        }

        public void Frnt(byte eGrp) {
            _iUIArry[_eCrrnUI].Frnt(eGrp);
        }

        public void Bck(byte eGrp) {
            _iUIArry[_eCrrnUI].Bck(eGrp);
        }

        public void Frnt(byte eGrp, byte eObj) {
            _iUIArry[_eCrrnUI].Frnt(eGrp, eObj);
        }

        public void Bck(byte eGrp, byte eObj) {
            _iUIArry[_eCrrnUI].Bck(eGrp, eObj);
        }
    }
}