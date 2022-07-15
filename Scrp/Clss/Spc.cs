using System;
using UnityEngine;

namespace T {

    public abstract class Spc { // space

        public IUnt[][][] IUnts { get { return _iUnts; } } // get the array of unit interface
        public IUnt[] IUntPrs { get { return _iUntPrs; } } // get the pure array of unit interfaces
        public IUnt ICntrUnt { get { return _iCntrUnt; } } // get center unit interface
        public SpcMngr Mngr { set { _mngr = value; } } // set manager
        public SGrd3 SCntrGrd { get { return _sCntrGrd; } } // get center grid struct
        public SGrd3 SScl { get { return _sScl; } } // get scale struct
        public float UntWdth { get { return _sUntSz.X; } } // get unit width
        public float UntLngt { get { return _sUntSz.Z; } } // get unit length
        public float UntHght { get { return _sUntSz.Y; } } // get unit height
        public float UntXSpcn { get { return _sUntSpcn.X; } } // get unit x axis spacing
        public float UntZSpcn { get { return _sUntSpcn.Z; } } // get unit z axis spacing
        public float UntYSpcn { get { return _sUntSpcn.Y; } } // get unit y axis spacing
        public int Clmns { get { return _sScl.Clmn; } } // get amount of columns
        public int Rows { get { return _sScl.Row; } } // get amount of rows
        public int Lyrs { get { return _sScl.Lyr; } } // get amount of layers
        public bool[][][] IsExsts { get { return _isExsts; } }
        public bool IsCnst { get { return _isCnst; } } // get is construct or not
        protected DActn[] _dGnrtExsts = null; // an array of action delegates
        protected IUnt[][][] _iUnts = null; // an array of units
        protected IUnt[] _iUntPrs = null;
        protected SpcMngr _mngr = null; // registered scene manager
        protected IUnt _iCntrUnt = null;
        protected SVctr3 _sUntSz; // unit size
        protected SVctr3 _sUntSpcn; // unit space
        protected SVctr3 _sCntrCrdn; // center coordinate
        protected SGrd3 _sCntrGrd;
        protected SGrd3 _sScl; // space scale
        protected float _crcmrds = 0.0f; // circumradius
        protected bool[][][] _isExsts = null; // an array of is unit exist or not
        private bool _isCnst = false; // is construct or not

        public Spc(float crcmrds, SVctr3 sUntSz, SVctr3 sUntSpcn) { // space
            _crcmrds = crcmrds;
            _sUntSz = sUntSz;
            _sUntSpcn = sUntSpcn;
        }

        public void Cnst(byte eExst) { // construct
            if (_isCnst || _dGnrtExsts == null || _dGnrtExsts[eExst] == null) {
                return;
            }
            _isCnst = true;
            _dGnrtExsts[eExst]?.Invoke(); // generate specific exist array by enum, _sScl and _isExsts will be mount
            _sCntrCrdn = GtCntrCrdn(_sScl.Clmn, _sScl.Row, _crcmrds); // find center coordinate
            _sCntrGrd = new SGrd3(0, (int)Math.Floor((float)_sScl.Clmn / 2), (int)Math.Floor((float)_sScl.Row / 2));
            _iUnts = new IUnt[_sScl.Lyr][][];
            _iUntPrs = new IUnt[_sScl.Lyr * _sScl.Clmn * _sScl.Row];
            int cnt = 0;
            for (byte l = 0; l < _sScl.Lyr; l++) {
                _iUnts[l] = new IUnt[_sScl.Clmn][];
                for (byte c = 0; c < _sScl.Clmn; c++) {
                    _iUnts[l][c] = new IUnt[_sScl.Row];
                    for (byte r = 0; r < _sScl.Row; r++) {
                        if (_isExsts[l][c][r] == false) {
                            _iUnts[l][c][r] = null;
                        } else {
                            _iUnts[l][c][r] = CrtIUnt(
                                new SGrd3(l, c, r),
                                new SVctr3(
                                    _sCntrCrdn.X + c * _sUntSpcn.X + XOffst(r),
                                    _sCntrCrdn.Y + l * _sUntSpcn.Y,
                                    _sCntrCrdn.Z + r * _sUntSpcn.Z - ZOffst(c)
                                )
                            );
                            _iUntPrs[cnt] = _iUnts[l][c][r];
                            cnt += 1;
                        }
                    }
                }
            }
            _iUntPrs = Arry.Cut<IUnt>(_iUntPrs, cnt);
            _iCntrUnt = _iUnts[0][_sCntrGrd.Clmn][_sCntrGrd.Row];
            Strc();
        }

        public void Dcnst() { // deconstruct
            if (!_isCnst) {
                return;
            }
            _isCnst = true;
            for (int l = 0; l < _iUnts.Length; l++) {
                for (int c = 0; c < _iUnts[c].Length; c++) {
                    for (int r = 0; r < _iUnts[c][r].Length; r++) {
                        _iUnts[l][c][r].Omt();
                    }
                }
            }
            _iUnts = null;
            _iUntPrs = null;
            _dGnrtExsts = null;
            _crcmrds = 0.0f;
            _isExsts = null;
        }

        protected void CrtExsts(SGrd3 sScl) { // generate exist
            _isExsts = new bool[sScl.Lyr][][];
            for (byte l = 0; l < sScl.Lyr; l++) {
                _isExsts[l] = new bool[sScl.Clmn][];
                for (byte c = 0; c < sScl.Clmn; c++) {
                    _isExsts[l][c] = new bool[sScl.Row];
                    for (byte r = 0; r < sScl.Row; r++) {
                        _isExsts[l][c][r] = true;
                    }
                }
            }
        }

        public abstract SVctr3 GtCntrCrdn(int clmn, int rw, float crcmrds); // center coordinate
        protected abstract IUnt CrtIUnt(SGrd3 sCrd, SVctr3 sPstn); // create interface of unit
        protected abstract void Strc(); // link together
        protected abstract float XOffst(int rw); // x offset
        protected abstract float ZOffst(int clmn); // z offset
    }
}