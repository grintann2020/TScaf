using UnityEngine;

namespace T {

    public interface IUI {

        UIMng Mng { set; }
        bool IsAtt { get; }
        void Att(Canvas canv, DAct dAtt = null);  // attach UI by generating all objects group, dAE = after attached
        void Att(Canvas canv, byte eObjs, DAct dAtt = null); // attach UI by generating specific objects group by enum, dAE = after attached
        void Dtc(); // detach UI by release all object groups
        void Dtc(byte eGrp); // detach UI by release specific object group by enum
        void PrpUpd(); // prop update
        bool IsGrpAtt(byte eGrp); // return is group attached or not
        GameObject GtGO(byte eGrp, byte eObj); // return specific gameObject in specific group by enum
        T GtCmp<T>(byte eGrp, byte eCmpn); // return component
        void Act(byte eGrp); // activate specific behavior group by enum
        void Hlt(byte eGrp); // halt specific behavior group by enum
        void Act(byte eGrp, byte eBhvr); // activate specific behavior in specific group by enum
        void Hlt(byte eGrp, byte eBhvr); // halt specific behavior in specific group by enum
        void Enb(byte eObj); // enable specific object group by enum
        void Dsb(byte eObj); // disable specific object group by enum
        void Enb(byte eGrp, byte eObj);  // enable specific object in specific group by enum
        void Dsb(byte eGrp, byte eObj);  // disable specific object in specific group by enum
        void Frn(byte eGrp);
        void Bck(byte eGrp);
        void Frn(byte eGrp, byte eObj);
        void Bck(byte eGrp, byte eObj);
    }
}