using UnityEngine;

namespace T {

    public struct SSprTrc : ITrc {

        private SpriteRenderer _sprRnd;
        private Sprite[] _sprArr;

        public SSprTrc(SpriteRenderer sprRnd, Sprite[] sprArr) {
            _sprRnd = sprRnd;
            _sprArr = sprArr;
        }

        public void Trd(int stp) {
            _sprRnd.sprite = _sprArr[stp];
        }
    }
}