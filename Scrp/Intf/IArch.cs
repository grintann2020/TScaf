using UnityEngine;

namespace T {

    public interface IArch { // archive interface

        ArchMngr Mngr { set; } // set archive manager
        bool IsOpn { get; } // return is opened or not
        void Opn(); // open
        void Cls(); // close
        void Rd(); // read
        void Wrt(); // write
    }
}