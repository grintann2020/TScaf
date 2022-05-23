using UnityEngine;

namespace T {
    
    [CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObject/Settings", order = 0)]
    public class SttngsSO : ScriptableObject { // settings scriptable object
        
        public ScrnRsltSO ScrnRslt; // screen resolution
        public byte FrstPrgm; // first program
    }
}