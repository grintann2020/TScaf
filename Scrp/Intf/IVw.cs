using UnityEngine;

namespace T {

    public interface IVw {

        VwMng Mng { set; }
        bool IsStUp { get; }
        bool IsMv { get; }
        void StUp(Camera[] cmrArr); // setup
        void StDwn(); // setdown
        void PrpUpd();
        void Dfl(); // default
        void Prj(byte ePrj); // set projection
        void Prj(SCmrPrj sCmrPrj); // set projection directly
        void Prj(byte eCmr, byte ePrj); // set projection
        void Prj(byte eCmr, SCmrPrj sCmrPrj);// set projection directly
        void Orn(byte eOrn); // set orient
        void Orn(SOrn3 sOrn); // set orient directly
        void Orn(byte eCmr, byte eOrn); // set orient
        void Orn(byte eCmr, SOrn3 sOrn); // set orient directly
        // void Mov(byte eMov); // movement
    }
}