// © 2020 Joshua Petersen. All rights reserved.

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assignment1
{
    public class GameManager : Singleton<GameManager>
    {
        private static GameObject singletonsGameObject = null;

        // /// <summary>
        // /// Auto instantiates the singletons prefab in the level, instead of just creating one  <see cref="GameObject"/> per <see cref="Singleton{T}"/> when we first use the singleton.
        // /// </summary>
        // [RuntimeInitializeOnLoadMethod]
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
        //}
    }
}