namespace T {

    public class StgMng : Sng<StgMng>, IMng { // stage manager

        public bool IsInt { get { return _isInt; } } // get is initialized or not
        private IStg[] _iStgArr = null; // an array of stage
        private StgPrm _stgPrm = null;  // prime of stage
        private byte _eCrrStg = 0; // enum of stage
        private bool _isInt = false; // is initialized or not

        public void Rst() { // reset
            if (!_isInt) {
                return;
            }
            _isInt = false;
            Abrt();
            _stgPrm = null;
            _iStgArr = null;
        }

        public void Int(IPrm iPrm) { // initialize
            if (_isInt) {
                return;
            }
            _isInt = true;
            _stgPrm = (StgPrm)iPrm;
            _iStgArr = _stgPrm.IStgArr;
        }

        public void Imp(byte eStg) { // implement specific stage by enum
            if (_iStgArr[_eCrrStg] != null) {
                if (_eCrrStg == eStg) {
                    return;
                }
                _iStgArr[_eCrrStg].Abr();
                _stgPrm.Omt(_eCrrStg);
            }
            _eCrrStg = eStg;
            _stgPrm.Prm(_eCrrStg);
            _iStgArr[_eCrrStg].Imp();
        }

        public void Impl(byte eStg, byte ePrgs) { // implement specific stage by enum
            if (_iStgArr[_eCrrStg] != null) {
                if (_eCrrStg == eStg) {
                    if (_iStgArr[_eCrrStg].ECrrPrg == ePrgs) {
                        return;
                    } else {
                        _iStgArr[_eCrrStg].Imp(ePrgs);
                        return;
                    }
                } else {
                    _iStgArr[_eCrrStg].Abr();
                    _stgPrm.Omt(_eCrrStg);
                }
            }
            _eCrrStg = eStg;
            _stgPrm.Prm(_eCrrStg);
            _iStgArr[_eCrrStg].Imp(ePrgs);
        }

        public void Abrt() { // abort current stage
            if (_iStgArr[_eCrrStg] != null) {
                _iStgArr[_eCrrStg].Abr();
                _stgPrm.Omt(_eCrrStg);
            }
        }

        public void PrpUpd() { // prop update
            _iStgArr[_eCrrStg]?.PrpUpd();
        }

        public IStg GtIStg() { // return current stage
            return _iStgArr[_eCrrStg];
        }

        public bool IsImp(byte eStg) { // return specific stage is implemented or not
            return _iStgArr[eStg] == null ? false : true;
        }

        public void DlgtRn(byte eStg, byte ePrgs, DAct rn) { // delegate, add method to delegate run
            _iStgArr[eStg].DPrgArr2[ePrgs][0] += rn;
        }

        public void DvdRn(byte eStg, byte ePrgs, DAct rn) { // divide, remove method to delegate run
            _iStgArr[eStg].DPrgArr2[ePrgs][0] -= rn;
        }

        public void DlgtStp(byte eStg, byte ePrgs, DAct stp) { // delegate, add method to delegate step
            _iStgArr[eStg].DPrgArr2[ePrgs][1] += stp;
        }

        public void DvdStp(byte eStg, byte ePrgs, DAct stp) {// divide, remove method to delegate step
            _iStgArr[eStg].DPrgArr2[ePrgs][1] -= stp;
        }
    }
}