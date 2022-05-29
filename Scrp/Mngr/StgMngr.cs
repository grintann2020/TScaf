namespace T {

    public class StgMngr : Sngltn<StgMngr>, IMngr { // stage manager

        public bool IsIntl { get { return _isIntl; } }
        private IStg[] _iStgArry = null; // array of stage
        private StgPrm _stgPrm = null;  // prime of stage
        private byte _eStg = 0; // enum of stage
        private bool _isIntl = false; // is initialized or not

        public void Rst() { // reset
            if (!_isIntl) {
                return;
            }
            Abrt();
            _stgPrm = null;
            _iStgArry = null;
            _isIntl = false;
        }

        public void Intl(IPrm iPrm) { // initialize
            if (_isIntl) {
                return;
            }
            _stgPrm = (StgPrm)iPrm;
            _iStgArry = _stgPrm.IStgArry;
            _isIntl = true;
        }

        public void Impl(byte eStg) { // implement specific stage by enum
            if (_iStgArry[_eStg] != null) {
                if (_eStg == eStg) {
                    return;
                }
                _iStgArry[_eStg].Abrt();
                _stgPrm.Omt(_eStg);
            }
            _eStg = eStg;
            _stgPrm.Prm(_eStg);
            _iStgArry[_eStg].Impl();
        }

        public void Abrt() { // abort current stage
            if (_iStgArry[_eStg] != null) {
                _iStgArry[_eStg].Abrt();
                _stgPrm.Omt(_eStg);
            }
        }

        public void PrpUpdt() { // prop update
            _iStgArry[_eStg]?.PrpUpdt();
        }

        public bool IsImp() { // return current stage is implemented or not
            return _iStgArry[_eStg] == null ? false : true;
        }

        public bool IsImp(byte eStg) { // return specific stage is implemented or not
            return _iStgArry[eStg] == null ? false : true;
        }

        public IStg Stg() { // return current stage
            return _iStgArry[_eStg];
        }

        public IStg Stg(byte eStg) { // return specific stage by enum
            return _iStgArry[eStg];
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