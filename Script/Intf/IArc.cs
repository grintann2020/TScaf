using UnityEngine;

namespace T {

    public interface IArc { // archive interface

        ArcMng Mng { set; } // set archive manager
        bool IsOpn { get; } // return is opened or not
        void Opn(); // open
        void Cls(); // close
        void Rd(); // read
        void Wrt(); // write
    }
}