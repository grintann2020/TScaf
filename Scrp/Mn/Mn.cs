using System;
using UnityEngine;

namespace T {
    
    public class Mn : SngltnMB<Mn> {

        public string GmPrmNm;
        [SerializeField] private SttngsSO _sttngs;

        private void Awake() {
            GmMngr.Inst.Intl((IPrm)Activator.CreateInstance(Type.GetType(GmPrmNm)));
            GmMngr.Inst.Sttngs(_sttngs);
        }

        private void Start() {
            GmMngr.Inst.Strt();
        }

        private void Update() {
            GmMngr.Inst.PrpUpdt();
        }
    }
}