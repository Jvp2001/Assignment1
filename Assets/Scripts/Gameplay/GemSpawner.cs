using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using Assignment1.Pickups;
namespace Assignment1.Gameplay
{
    public class GemSpawner : MonoBehaviour
    {
        [SerializeField] private int totalNumberOfGems;

        private GameObject[] gemContainers;

        private void Start()
        {
            SpawnGems();
        }

        public void SpawnGems()
        {
            gemContainers = GameObject.FindGameObjectsWithTag("GemContainer");
            gemContainers.OrderBy((x) => Random.Range(0, gemContainers.Length)).Take(totalNumberOfGems);
            GameObject gemPickupPrefab = Resources.Load<GameObject>("Prefabs/GemPickup");
            foreach (GameObject gemContainer in gemContainers)
            {
                GameObject gemPickup = Instantiate(gemPickupPrefab, gemContainer.transform);
                Gem gem = gemPickup.GetComponent<Gem>();
                
                gemPickup.transform.parent = gemContainer.transform;
                var localPosition = gemPickup.transform.localPosition;
                gemPickup.transform.localRotation = Quaternion.identity;
                Vector3 position = gemContainer.GetComponent<Renderer>().bounds.center + Vector3.up;
                localPosition = position;
                gemPickup.transform.localPosition = localPosition;
                Logger.Log($"{gemContainer.name}: Spawned Gem!");
                gem.IsTrigger = false;
            }
        }
    }
}