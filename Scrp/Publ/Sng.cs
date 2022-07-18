namespace T {

    public class Sng<T> where T : new() { // singleton base class
        
        protected static T _ins;
        public static T Ins {
            get {
                if (_ins == null) {
                    _ins = new T();
                }
                return _ins; // returns the instance of this singleton.
            }
            set {
                _ins = value;
            }
        }
    }
}