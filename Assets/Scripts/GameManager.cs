using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assignment1
{
    public class GameManager : Singleton<GameManager>
    {
        private static GameObject singletonsGameObject = null;
        //
        // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        // private static void OnLoad()
        // {
        //     if (!singletonsGameObject)
        //     {
        //         singletonsGameObject = Resources.Load<GameObject>("Prefabs/Singletons");
        //         GameObject.Instantiate(singletonsGameObject, Vector3.zero, Quaternion.identity);
        //         DontDestroyOnLoad(singletonsGameObject);
        //     }
        //
        //     SceneManager.sceneLoaded += (scene, mode) =>
        //     {
        //         if (scene.name == "MainLevel")
        //         {
        //             singletonsGameObject.transform.Find("PlayHUD").gameObject.SetActive(true);
        //         }
        //     };
        //
        // }
    }
}