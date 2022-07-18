using UnityEngine;

namespace T {

    public class SngMB<T> : MonoBehaviour where T : MonoBehaviour { // singleton base class
                                                                     // derive this class with MonoBehaviour to make it singleton
            protected static T _ins;
            public static T Ins {
            get {
                if (_ins == null) {
                    _ins = (T)FindObjectOfType(typeof(T));
                    if (_ins == null) {
                        GameObject gO = new GameObject(typeof(T).ToString());
                        _ins = gO.AddComponent<T>();
                    }
                    DontDestroyOnLoad(_ins); // keep the object alive.
                }
                return _ins; // returns the instance of this singleton.
            }
        }
    }
}