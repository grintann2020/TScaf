// using System;
using UnityEngine;

namespace T {

    public abstract class Spc { // space

        public IUnt[][][] IUntArry { get { return _iUntArry; } }
        public IScn IScn { set { _iScn = value; } }
        public float UntWdth { get { return _sUntSz.X; } } // get unit width
        public float UntLngt { get { return _sUntSz.Z; } } // get unit length
        public float UntHght { get { return _sUntSz.Y; } } // get unit height
        public float UntXSpcn { get { return _sUntSpcn.X; } } // get unit x axis spacing
        public float UntZSpcn { get { return _sUntSpcn.Z; } } // get unit z axis spacing
        public float UntYSpcn { get { return _sUntSpcn.Y; } } // get unit y axis spacing
        public byte Clmns { get { return _sScl.Clmn; } } // get amount of columns
        public byte Rws { get { return _sScl.Rw; } } // get amount of rows
        public byte Lyrs { get { return _sScl.Lyr; } } // get amount of layers
        public bool[][][] IsExstArry { get { return _isExstArry; } }
        public bool IsCnst { get { return _isCnst; } } // get is construct or not
        protected IUnt[][][] _iUntArry = null; // an array of units
        protected DActn[] _dGnrtExstArry = null; // an array of action delegates
        protected IScn _iScn = null;
        protected SVctr3 _sUntSz; // unit size
        protected SVctr3 _sUntSpcn; // unit space
        protected SVctr3 _sCntrCrd; // center coordinate
        protected SGrd3 _sScl; // space scale
        protected float _crcmrds = 0.0f; // circumradius
        protected bool[][][] _isExstArry = null; // an array of is unit exist or not
        private bool _isCnst = false; // is construct or not

        public Spc(float crcmrds, SVctr3 sUntSz, SVctr3 sUntSpcn) { // space
            _crcmrds = crcmrds;
            _sUntSz = sUntSz;
            _sUntSpcn = sUntSpcn;
        }

        public void Cnst(byte eExst) { // construct
            if (_isCnst) {
                return;
            }
            _dGnrtExstArry[eExst]?.Invoke(); // generate specific exist array by enum, _sScl and _isExstArry will be mount
            _sCntrCrd = CntrCrd(_sScl.Clmn, _sScl.Rw, _crcmrds); // find center coordinate
            // _iUntArry = new IUnt[_sScl.Clmn][][];
            // for (byte c = 0; c < _sScl.Clmn; c++) {
            //     _iUntArry[c] = new IUnt[_sScl.Rw][];
            //     for (byte r = 0; r < _sScl.Rw; r++) {
            //         _iUntArry[c][r] = new IUnt[_sScl.Lyr];
            //         for (byte l = 0; l < _sScl.Lyr; l++) {
            //             if (_isExstArry[c][r][l] == false) {
            //                 _iUntArry[c][r][l] = null;
            //             } else {
            //                 float x = _sCntrCrd.X + c * _sUntSpcn.X;
            //                 float z = _sCntrCrd.Z + r * _sUntSpcn.Z;
            //                 float y = _sCntrCrd.Y + l * _sUntSpcn.Y;
            //                 _iUntArry[c][r][l] = CrtIUnt(
            //                     new SGrd3(c, r, l),
            //                     new SVctr3(
            //                         _sCntrCrd.X + c * _sUntSpcn.X + XOffst(r),
            //                         _sCntrCrd.Y + l * _sUntSpcn.Y,
            //                         _sCntrCrd.Z + r * _sUntSpcn.Z
            //                     )
            //                 );
            //             }
            //         }
            //     }
            // }
            _iUntArry = new IUnt[_sScl.Lyr][][];
            for (byte l = 0; l < _sScl.Lyr; l++) {
                _iUntArry[l] = new IUnt[_sScl.Clmn][];
                for (byte c = 0; c < _sScl.Clmn; c++) {
                    _iUntArry[l][c] = new IUnt[_sScl.Rw];
                    for (byte r = 0; r < _sScl.Rw; r++) {
                        if (_isExstArry[l][c][r] == false) {
                            _iUntArry[l][c][r] = null;
                        } else {
                            float y = _sCntrCrd.Y + l * _sUntSpcn.Y;
                            float x = _sCntrCrd.X + c * _sUntSpcn.X;
                            float z = _sCntrCrd.Z + r * _sUntSpcn.Z;
                            _iUntArry[l][c][r] = CrtIUnt(
                                new SGrd3(l, c, r),
                                new SVctr3(
                                    _sCntrCrd.Y + l * _sUntSpcn.Y,
                                    _sCntrCrd.X + c * _sUntSpcn.X + XOffst(r),
                                    _sCntrCrd.Z + r * _sUntSpcn.Z
                                )
                            );
                        }
                    }
                }
            }
            LnkTgth();
            _isCnst = true;
        }

        public void Dcnst() { // deconstruct
            if (!_isCnst) {
                return;
            }
            // _isExstArry = null;
            // for (int c=0; c<_iUntArry.Length; c++) {
            //     for (int r=0; r<_iUntArry[c].Length; r++) {
            //         for (int l=0; l<_iUntArry[c][r].Length; l++) {
            //             _iUntArry[c][r][l].Omt();
            //         }
            //     }
            // }
            _isExstArry = null;
            for (int l=0; l<_iUntArry.Length; l++) {
                for (int c=0; c<_iUntArry[c].Length; c++) {
                    for (int r=0; r<_iUntArry[c][r].Length; r++) {
                        _iUntArry[l][c][r].Omt();
                    }
                }
            }
            _iUntArry = null;
            _isCnst = false;
        }

        protected void GnrtExst(SGrd3 sScl) { // generate exist
            _sScl = sScl;
            // _isExstArry = new bool[_sScl.Clmn][][];
            // for (byte c = 0; c < _sScl.Clmn; c++) {
            //     _isExstArry[c] = new bool[_sScl.Rw][];
            //     for (byte r = 0; r < _sScl.Rw; r++) {
            //         _isExstArry[c][r] = new bool[_sScl.Lyr];
            //         for (byte l = 0; l < _sScl.Lyr; l++) {
            //             _isExstArry[c][r][l] = true;
            //         }
            //     }
            // }
            _isExstArry = new bool[_sScl.Lyr][][];
            for (byte l = 0; l < _sScl.Lyr; l++) {
                _isExstArry[l] = new bool[_sScl.Clmn][];
                for (byte c = 0; c < _sScl.Clmn; c++) {
                    _isExstArry[l][c] = new bool[_sScl.Rw];
                    for (byte r = 0; r < _sScl.Rw; r++) {
                        _isExstArry[l][c][r] = true;
                    }
                }
            }
        }
        protected abstract IUnt CrtIUnt(SGrd3 sPstn, SVctr3 sCrd); // create interface of unit
        protected abstract SVctr3 CntrCrd(byte clmn, byte rw, float crcmrds); // center coordinate
        protected abstract void LnkTgth(); // link together
        protected abstract float XOffst(byte rw); // x offset
    }
}