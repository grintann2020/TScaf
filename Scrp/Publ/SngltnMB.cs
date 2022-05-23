using UnityEngine;

namespace T {

    public class SngltnMB<T> : MonoBehaviour where T : MonoBehaviour { // singleton base class
                                                                     // derive this class with MonoBehaviour to make it singleton
            protected static T _inst;
            public static T Ins {
            get {
                if (_inst == null) {
                    _inst = (T)FindObjectOfType(typeof(T));
                    if (_inst == null) {
                        GameObject objc = new GameObject(typeof(T).ToString());
                        _inst = objc.AddComponent<T>();
                    }
                    DontDestroyOnLoad(_inst); // keep the object alive.
                }
                return _inst; // returns the insttance of this singleton.
            }
        }
    }
}