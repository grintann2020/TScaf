using UnityEngine;

namespace T {

    [CreateAssetMenu(fileName = "DispAR", menuName = "ScriptableObject/DispAR", order = 0)]
    public class DispAR : ScriptableObject {

        public float Long = 0; // long side length
        public float Short = 0; // short side length

        public float ToFloat(bool isPort) {
            return isPort ?　Long / Short : Short / Long;
        }
    }
}