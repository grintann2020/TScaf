using UnityEngine;

namespace T {

    public interface IUI {

        UIMngr Mngr { set; }
        bool IsAttc { get; }
        void Attc(Canvas canv, DActn dAftrAttc = null);  // attach UI by generating all objects group, dAE = after attached
        void Attc(Canvas canv, byte eObjs, DActn dAftrAttc = null); // attach UI by generating specific objects group by enum, dAE = after attached
        void Dtch(); // detach UI by release all object groups
        void Dtch(byte eGrp); // detach UI by release specific object group by enum
        void PrpUpdt(); // prop update
        bool IsGrpAttc(byte eGrp); // return is group attached or not
        GameObject GmObjc(byte eGrp, byte eObjc); // return specific gameObject in specific group by enum
        T Cmpn<T>(byte eGrp, byte eCmpn); // return component
        void Actv(byte eGrp); // activate specific behavior group by enum
        void Hlt(byte eGrp); // halt specific behavior group by enum
        void Actv(byte eGrp, byte eBhvr); // activate specific behavior in specific group by enum
        void Hlt(byte eGrp, byte eBhvr); // halt specific behavior in specific group by enum
        void Enbl(byte eObj); // enable specific object group by enum
        void Dsbl(byte eObj); // disable specific object group by enum
        void Enbl(byte eGrp, byte eObjc);  // enable specific object in specific group by enum
        void Dsbl(byte eGrp, byte eObjc);  // disable specific object in specific group by enum
        void Frnt(byte eGrp);
        void Bck(byte eGrp);
        void Frnt(byte eGrp, byte eObjc);
        void Bck(byte eGrp, byte eObjc);
    }
}