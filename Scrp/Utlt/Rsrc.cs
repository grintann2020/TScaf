using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

namespace T {

    public static class Rsrc {

        public static void Ld<TObj>(string ky, DActn<TObj> dLded = null) {
            Addressables.LoadAssetAsync<TObj>(ky).Completed += (AsyncOperationHandle<TObj> hdl) => {
                dLded?.Invoke(hdl.Result);
            };
        }

        public static async void Ld<TObj>(string[] kyArr, DActns<TObj> dLded = null) {
            TObj[] tObjArr = new TObj[kyArr.Length];
            Task[] taskArr = new Task[kyArr.Length];
            AsyncOperationHandle<TObj>[] hdlArr = new AsyncOperationHandle<TObj>[kyArr.Length];
            for (byte k = 0; k < kyArr.Length; k++) {
                hdlArr[k] = Addressables.LoadAssetAsync<TObj>(kyArr[k]);
                taskArr[k] = hdlArr[k].Task;
            }
            await Task.WhenAll(taskArr);
            for (byte k = 0; k < kyArr.Length; k++) {
                tObjArr[k] = hdlArr[k].Result;
            }
            dLded?.Invoke(tObjArr);
        }

        public static void Inst(string ky, Transform prnt = null, DActn<GameObject> dInsted = null) { // Addressables.InstantiateAsync will clone asset directlty
            Addressables.InstantiateAsync(ky, prnt).Completed += (AsyncOperationHandle<GameObject> hdl) => {
                dInsted?.Invoke(hdl.Result);
            };
        }

        public static void Inst(string ky, Vector3 pstn, Quaternion rtt, Transform prnt = null, DActn<GameObject> dInsted = null) { // Addressables.InstantiateAsync will clone asset directlty
            Addressables.InstantiateAsync(ky, pstn, rtt, prnt).Completed += (AsyncOperationHandle<GameObject> hdl) => {
                dInsted?.Invoke(hdl.Result);
            };
        }

        public static async void Inst(string[] kyArr,  Transform prnt = null, DActns<GameObject> dInsted = null) { // Addressables.InstantiateAsync will clone asset directlty
            GameObject[] goArr = new GameObject[kyArr.Length];
            Task[] taskArr = new Task[kyArr.Length];
            AsyncOperationHandle<GameObject>[] hdlArr = new AsyncOperationHandle<GameObject>[kyArr.Length];
            for (byte k = 0; k < kyArr.Length; k++) {
                hdlArr[k] = Addressables.InstantiateAsync(kyArr[k], prnt);
                taskArr[k] = hdlArr[k].Task;
            }
            await Task.WhenAll(taskArr);
            for (byte k = 0; k < kyArr.Length; k++) {
                goArr[k] = hdlArr[k].Result;
            }
            dInsted?.Invoke(goArr);
        }

        public static async void Inst(object[][] objArr, Transform prnt = null, DActns<GameObject> dInsted = null) {
            GameObject[] goArr = new GameObject[objArr.Length];
            Task[] taskArr = new Task[objArr.Length];
            AsyncOperationHandle<GameObject>[] hdlArr = new AsyncOperationHandle<GameObject>[objArr.Length];
            for (byte k = 0; k < objArr.Length; k++) {
                hdlArr[k] = Addressables.InstantiateAsync((string)objArr[k][0], (Vector3)objArr[k][1], (Quaternion)objArr[k][2], prnt);
                taskArr[k] = hdlArr[k].Task;
            }
            await Task.WhenAll(taskArr);
            for (byte k = 0; k < objArr.Length; k++) {
                goArr[k] = hdlArr[k].Result;
            }
            dInsted?.Invoke(goArr);
        }

        public static void Rls<TObj>(TObj tObj, DActn dRlsed = null) {
            Addressables.Release<TObj>(tObj);
            dRlsed?.Invoke();
        }

        public static void Rls<TObj>(TObj[] tObjArr, DActn dRlsed = null) {
            for (ushort o = 0; o < tObjArr.Length; o++) {
                Addressables.Release<TObj>(tObjArr[o]);
            }
            dRlsed?.Invoke();
        }
    }
}