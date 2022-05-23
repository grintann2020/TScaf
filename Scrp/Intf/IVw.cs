using UnityEngine;

namespace T {

    public interface IVw {

        VwMngr Mngr { set; }
        bool IsStup { get; }
        bool IsMv { get; }
        void Stup(Camera[] cmrArry); // setup
        void Stdwn(); // setdown
        void PrpUpdt();
        void Dflt(); // default
        void Prjc(byte ePrj); // set projection
        void Prjc(SCmrPrjc sCmrPrjc); // set projection directly
        void Prjc(byte eCmr, byte ePrjc); // set projection
        void Prjc(byte eCmr, SCmrPrjc sCmrPrjc);// set projection directly
        void Ornt(byte eOrnt); // set orient
        void Ornt(SOrnt3 sOrnt); // set orient directly
        void Ornt(byte eCmr, byte eOrnt); // set orient
        void Ornt(byte eCmr, SOrnt3 sOrnt); // set orient directly
        // void Mov(byte eMov); // movement
    }
}