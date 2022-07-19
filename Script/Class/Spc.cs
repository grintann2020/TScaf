using System;
using UnityEngine;

namespace T {

    public abstract class Spc { // space

        public IUnt[][][] IUntArr3 { get { return _iUntArr3; } } // get the array of unit interface
        public IUnt[] IUntPrArr { get { return _iUntPrArr; } } // get the pure array of unit interfaces
        public IUnt ICntUnt { get { return _iCntUnt; } } // get center unit interface
        public SpcMng Mng { set { _mng = value; } } // set manager
        public SGrd3 SCntGrd { get { return _sCntGrd; } } // get center grid struct
        public SGrd3 SScl { get { return _sScl; } } // get scale struct
        public float UntWdt { get { return _sUntSz.X; } } // get unit width
        public float UntLng { get { return _sUntSz.Z; } } // get unit length
        public float UntHgh { get { return _sUntSz.Y; } } // get unit height
        public float UntXSpc { get { return _sUntSpc.X; } } // get unit x axis spacing
        public float UntZSpc { get { return _sUntSpc.Z; } } // get unit z axis spacing
        public float UntYSpc { get { return _sUntSpc.Y; } } // get unit y axis spacing
        public int Clm { get { return _sScl.Clm; } } // get amount of columns
        public int Rw { get { return _sScl.Rw; } } // get amount of rows
        public int Lyr { get { return _sScl.Lyr; } } // get amount of layers
        public bool[][][] IsExsArr3 { get { return _isExsArr3; } }
        public bool IsCnst { get { return _isCnst; } } // get is construct or not
        protected DAct[] _dGnrExsArr = null; // an array of action delegates
        protected IUnt[][][] _iUntArr3 = null; // an array of units
        protected IUnt[] _iUntPrArr = null;
        protected SpcMng _mng = null; // registered scene manager
        protected IUnt _iCntUnt = null;
        protected SVct3 _sUntSz; // unit size
        protected SVct3 _sUntSpc; // unit space
        protected SVct3 _sCntCrd; // center coordinate
        protected SGrd3 _sCntGrd;
        protected SGrd3 _sScl; // space scale
        protected float _crc = 0.0f; // circumradius
        protected bool[][][] _isExsArr3 = null; // an array of is unit exist or not
        private bool _isCnst = false; // is construct or not

        public Spc(float crc, SVct3 sUntSz, SVct3 sUntSpc) { // space
            _crc = crc;
            _sUntSz = sUntSz;
            _sUntSpc = sUntSpc;
        }

        public void Cnst(byte eExs) { // construct
            if (_isCnst || _dGnrExsArr == null || _dGnrExsArr[eExs] == null) {
                return;
            }
            _isCnst = true;
            _dGnrExsArr[eExs]?.Invoke(); // generate specific exist array by enum, _sScl and _isExsArr3 will be mount
            _sCntCrd = GtCntCrd(_sScl.Clm, _sScl.Rw, _crc); // find center coordinate
            _sCntGrd = new SGrd3(0, (int)Math.Floor((float)_sScl.Clm / 2), (int)Math.Floor((float)_sScl.Rw / 2));
            _iUntArr3 = new IUnt[_sScl.Lyr][][];
            _iUntPrArr = new IUnt[_sScl.Lyr * _sScl.Clm * _sScl.Rw];
            int cnt = 0;
            for (byte l = 0; l < _sScl.Lyr; l++) {
                _iUntArr3[l] = new IUnt[_sScl.Clm][];
                for (byte c = 0; c < _sScl.Clm; c++) {
                    _iUntArr3[l][c] = new IUnt[_sScl.Rw];
                    for (byte r = 0; r < _sScl.Rw; r++) {
                        if (_isExsArr3[l][c][r] == false) {
                            _iUntArr3[l][c][r] = null;
                        } else {
                            _iUntArr3[l][c][r] = CrtIUnt(
                                new SGrd3(l, c, r),
                                new SVct3(
                                    _sCntCrd.X + c * _sUntSpc.X + XOff(r),
                                    _sCntCrd.Y + l * _sUntSpc.Y,
                                    _sCntCrd.Z + r * _sUntSpc.Z - ZOff(c)
                                )
                            );
                            _iUntPrArr[cnt] = _iUntArr3[l][c][r];
                            cnt += 1;
                        }
                    }
                }
            }
            _iUntPrArr = Arr.Ct<IUnt>(_iUntPrArr, cnt);
            _iCntUnt = _iUntArr3[0][_sCntGrd.Clm][_sCntGrd.Rw];
            Strc();
        }

        public void Dcns() { // deconstruct
            if (!_isCnst) {
                return;
            }
            _isCnst = true;
            for (int l = 0; l < _iUntArr3.Length; l++) {
                for (int c = 0; c < _iUntArr3[c].Length; c++) {
                    for (int r = 0; r < _iUntArr3[c][r].Length; r++) {
                        _iUntArr3[l][c][r].Omt();
                    }
                }
            }
            _iUntArr3 = null;
            _iUntPrArr = null;
            _dGnrExsArr = null;
            _crc = 0.0f;
            _isExsArr3 = null;
        }

        protected void CrtExsArr(SGrd3 sScl) { // generate exist
            _isExsArr3 = new bool[sScl.Lyr][][];
            for (byte l = 0; l < sScl.Lyr; l++) {
                _isExsArr3[l] = new bool[sScl.Clm][];
                for (byte c = 0; c < sScl.Clm; c++) {
                    _isExsArr3[l][c] = new bool[sScl.Rw];
                    for (byte r = 0; r < sScl.Rw; r++) {
                        _isExsArr3[l][c][r] = true;
                    }
                }
            }
        }

        public abstract SVct3 GtCntCrd(int clm, int rw, float crc); // center coordinate
        protected abstract IUnt CrtIUnt(SGrd3 sCrd, SVct3 sPst); // create interface of unit
        protected abstract void Strc(); // link together
        protected abstract float XOff(int rw); // x offset
        protected abstract float ZOff(int clm); // z offset
    }
}