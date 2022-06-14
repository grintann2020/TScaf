namespace T {

    public class StgMngr : Sngltn<StgMngr>, IMngr { // stage manager

        public bool IsIntl { get { return _isIntl; } } // get is initialized or not
        private IStg[] _iStgArry = null; // an array of stage
        private StgPrm _stgPrm = null;  // prime of stage
        private byte _eCrrnStg = 0; // enum of stage
        private bool _isIntl = false; // is initialized or not

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            _isIntl = false;
            Abrt();
            _stgPrm = null;
            _iStgArry = null;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _isIntl = true;
            _stgPrm = (StgPrm)iPrm;
            _iStgArry = _stgPrm.IStgArry;
        }

        public void Impl(byte eStg) { // implement specific stage by enum
            if (_iStgArry[_eCrrnStg] != null) {
                if (_eCrrnStg == eStg) {
                    return;
                }
                _iStgArry[_eCrrnStg].Abrt();
                _stgPrm.Omt(_eCrrnStg);
            }
            _eCrrnStg = eStg;
            _stgPrm.Prm(_eCrrnStg);
            _iStgArry[_eCrrnStg].Impl();
        }

        public void Impl(byte eStg, byte ePrgs) { // implement specific stage by enum
            if (_iStgArry[_eCrrnStg] != null) {
                if (_eCrrnStg == eStg) {
                    if (_iStgArry[_eCrrnStg].ECrrnPrgs == ePrgs) {
                        return;
                    } else {
                        _iStgArry[_eCrrnStg].Impl(ePrgs);
                        return;
                    }
                } else {
                    _iStgArry[_eCrrnStg].Abrt();
                    _stgPrm.Omt(_eCrrnStg);
                }
            }
            _eCrrnStg = eStg;
            _stgPrm.Prm(_eCrrnStg);
            _iStgArry[_eCrrnStg].Impl(ePrgs);
        }

        public void Abrt() { // abort current stage
            if (_iStgArry[_eCrrnStg] != null) {
                _iStgArry[_eCrrnStg].Abrt();
                _stgPrm.Omt(_eCrrnStg);
            }
        }

        public void PrpUpdt() { // prop update
            _iStgArry[_eCrrnStg]?.PrpUpdt();
        }

        public IStg GtIStg() { // return current stage
            return _iStgArry[_eCrrnStg];
        }

        public bool IsImp(byte eStg) { // return specific stage is implemented or not
            return _iStgArry[eStg] == null ? false : true;
        }

        public void DlgtRn(byte eStg, byte ePrgs, DActn rn) { // delegate, add method to delegate run
            _iStgArry[eStg].DPrgsArry[ePrgs][0] += rn;
        }

        public void DvdRn(byte eStg, byte ePrgs, DActn rn) { // divide, remove method to delegate run
            _iStgArry[eStg].DPrgsArry[ePrgs][0] -= rn;
        }

        public void DlgtStp(byte eStg, byte ePrgs, DActn stp) { // delegate, add method to delegate step
            _iStgArry[eStg].DPrgsArry[ePrgs][1] += stp;
        }

        public void DvdStp(byte eStg, byte ePrgs, DActn stp) {// divide, remove method to delegate step
            _iStgArry[eStg].DPrgsArry[ePrgs][1] -= stp;
        }
    }
}