using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace T {

    public class UIMng : Sng<UIMng>, IMng { // UI manager

        public Type[] Typs = new Type[] {
            typeof(TMP_Text),
            typeof(Text),
            typeof(Image),
            typeof(Button),
        };
        public bool IsInt { get { return _isInt; } }
        private UIPrm _uIPrm = null;
        private IUI[] _iUIs = null;
        private byte _eCrrUI = 0;
        private bool _isInt = false;

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Dtc();
            _uIPrm = null;
            _iUIs = null;
        }

        public void Int(IPrm iPrm) { // initialize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _uIPrm = (UIPrm)iPrm;
            _iUIs = _uIPrm.IUIArr;
        }

        public void Att(Canvas cnv, byte eUI, DAct dAtt = null) {  // attach UI by generating all object groups, dAE = after attached
            if (_iUIs[_eCrrUI] != null) {
                _iUIs[_eCrrUI].Dtc();
                _uIPrm.Omt(_eCrrUI);
            }
            _eCrrUI = eUI;
            _uIPrm.Prm(_eCrrUI);
            _iUIs[_eCrrUI].Att(cnv, dAtt);
        }

        public void Att(Canvas cnv, byte eUI, byte eGrp, DAct dAtt = null) {  // attach UI by generating specific object group by enum, dAE = after attached
            if (_iUIs[_eCrrUI] != null) {
                if (_eCrrUI == eUI) {
                    if (_iUIs[_eCrrUI].IsGrpAtt(eGrp)) {
                        return;
                    } else {
                        _iUIs[_eCrrUI].Att(cnv, eGrp, dAtt);
                        return;
                    }
                } else {
                    _iUIs[_eCrrUI].Dtc();
                    _uIPrm.Omt(_eCrrUI);
                }
            }
            _eCrrUI = eUI;
            _uIPrm.Prm(_eCrrUI);
            _iUIs[_eCrrUI].Att(cnv, eGrp, dAtt);
        }

        public void Dtc() {  // detach current UI from canvas
            if (_iUIs[_eCrrUI] != null) {
                _iUIs[_eCrrUI].Dtc();
                _uIPrm.Omt(_eCrrUI);
            };
        }

        public void Dtc(byte eGrp) {  // detach specific UI from canvas by enum
            if (_iUIs[_eCrrUI] != null) {
                _iUIs[_eCrrUI].Dtc(eGrp);
                if (!_iUIs[_eCrrUI].IsAtt) {
                    _uIPrm.Omt(_eCrrUI);
                }
            };
        }

        public void PrpUpd() { // prop update
            _iUIs[_eCrrUI]?.PrpUpd();
        }

        public IUI GtIUI() { // return specific UI by enum
            return _iUIs[_eCrrUI];
        }

        public GameObject GtGO(byte eGrp, byte eObj) { // return specific gameObject in specific group by enum
            return _iUIs[_eCrrUI].GtGO(eGrp, eObj);
        }

        public T GtCmpn<T>(byte eGrp, byte eCmpn) { // return specific component bye enum
            return _iUIs[_eCrrUI].GtCmp<T>(eGrp, eCmpn);
        }

        public bool IsAtt(byte eUI) { // return specific UI is attached or not
            return _iUIs[eUI] == null ? false : true;
        }

        public bool IsGrpAtt(byte eGrp) {
            if (_iUIs[_eCrrUI] == null) {
                return false;
            }
            return _iUIs[_eCrrUI].IsGrpAtt(eGrp);
        }

        public void Act(byte eGrp) { // activate specific behavior group by enum
            _iUIs[_eCrrUI].Act(eGrp);
        }

        public void Hlt(byte eGrp) { // halt specific behavior group by enum
            _iUIs[_eCrrUI].Hlt(eGrp);
        }

        public void Act(byte eGrp, byte eBhvr) { // activate specific behavior in specific group by enum
            _iUIs[_eCrrUI].Act(eGrp, eBhvr);
        }

        public void Hlt(byte eGrp, byte eBhvr) { // halt specific behavior in specific group by enum
            _iUIs[_eCrrUI].Hlt(eGrp, eBhvr); 
        }

        public void Enb(byte eGrp) { // enable specific object group by enum
            _iUIs[_eCrrUI].Enb(eGrp);
        }

        public void Dsb(byte eGrp) { // disable specific object group by enum
            _iUIs[_eCrrUI].Dsb(eGrp);
        }

        public void Enb(byte eGrp, byte eObj) { // enable specific object in specific group by enum
            _iUIs[_eCrrUI].Enb(eGrp, eObj);
        }

        public void Dsb(byte eGrp, byte eObj) { // disable specific object in specific group by enum
            _iUIs[_eCrrUI].Dsb(eGrp, eObj);
        }

        public void Frn(byte eGrp) {
            _iUIs[_eCrrUI].Frn(eGrp);
        }

        public void Bck(byte eGrp) {
            _iUIs[_eCrrUI].Bck(eGrp);
        }

        public void Frn(byte eGrp, byte eObj) {
            _iUIs[_eCrrUI].Frn(eGrp, eObj);
        }

        public void Bck(byte eGrp, byte eObj) {
            _iUIs[_eCrrUI].Bck(eGrp, eObj);
        }
    }
}