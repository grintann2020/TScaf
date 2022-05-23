namespace T {

    public class Sngltn<T> where T : new() { // singleton base class
        
        protected static T _inst;
        public static T Inst {
            get {
                if (_inst == null) {
                    _inst = new T();
                }
                return _inst; // returns the instance of this singleton.
            }
            set {
                _inst = value;
            }
        }
    }
}