using UnityEngine;

namespace T {

    public struct SSprtTrck : ITrck {

        private SpriteRenderer _sprtRndr;
        private Sprite[] _sprtArry;

        public SSprtTrck(SpriteRenderer sprtRndr, Sprite[] sprtArry) {
            _sprtRndr = sprtRndr;
            _sprtArry = sprtArry;
        }

        public void Trd(int stp) {
            _sprtRndr.sprite = _sprtArry[stp];
        }
    }
}