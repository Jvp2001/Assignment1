

using System;
using UnityEngine;

namespace Assignment1
{
    /// <summary>
    /// <para>
    /// Inherit from this base class to create a singleton.
    /// </para>
    /// <remarks>
    /// <para>
    /// Modified code taken from <a herf="https://wiki.unity3d.com/index.php/Singleton">here</a>
    /// </para>
    /// </remarks>
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        ///<summary>
        /// Check to see if we're about to be destroyed.
        /// </summary>
        private static bool shuttingDown = false;
        private static object lockedObject = new object();
        private static T instance;

        private void OnEnable()
        {
            
        }

        /// <summary>
        /// Access singleton instance through this property.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (shuttingDown)
                {
                    Logger.LogWarning("[Singleton] Instance '" + typeof(T) +
                                      "' already destroyed. Returning null.");
                    return null;
                }

                lock (lockedObject)
                {
                    if (!instance)
                    {
                        // Search for existing instance.
                        instance = (T) FindObjectOfType(typeof(T));

                        // Create new instance if one doesn't already exist.
                        if (instance == null)
                        {
                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T) + " (Singleton)";
                        }
                    }

                    // Make instance persistent.
                    DontDestroyOnLoad(instance);

                    return instance;
                }
            }
        }


        private void OnApplicationQuit()
        {
            shuttingDown = true;
        }


        private void OnDestroy()
        {
            shuttingDown = true;
        }
    }
}