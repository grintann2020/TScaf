using UnityEngine;

namespace T {
    
    [CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObject/Settings", order = 0)]
    public class SttSO : ScriptableObject { // settings scriptable object
        
        public ScrRslSO ScrRsl; // screen resolution
        public byte FrsPrg; // first program
    }
}