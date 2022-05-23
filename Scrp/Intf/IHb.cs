using UnityEngine;

namespace T {

    public interface IHb {

        HbMngr Mngr { set; } // set hub manager
        bool IsCnnc { get; } // return is connected or not
        void Cnnc(); // connect
        void Dscn(); // disconnect
        void PrpUpdt(); // prop update
        // void Act(byte eAct);
        // void Mot(byte eMot);
        void StGO(byte eGO, GameObject go);
        GameObject GtGO(byte eGO);
        void StVal<T>(byte eVal, T val);
        T GtVal<T>(byte eVal);
    }
}