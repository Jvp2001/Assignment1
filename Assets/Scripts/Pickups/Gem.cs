using System;
using System.Collections;
using System.Collections.Generic;
using Assignment1.Gameplay;
using UnityEngine;
using Logger = Assignment1.Logger;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SphereCollider))]
public class Gem : MonoBehaviour
{

    private SphereCollider sphereCollider;
    private AudioSource pickupAudioSource;
    private MeshRenderer pickupMesh;
    

    public bool CanPickup
    {
        get => sphereCollider.enabled;
        set
        {
            sphereCollider.enabled = value;
        }
    }

    private void OnEnable()
    {
        sphereCollider = GetComponent<SphereCollider>();
        pickupAudioSource = GetComponent<AudioSource>();
        pickupMesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Logger.Log("Collided with player!");
        if (other.gameObject.CompareTag("Player"))
        {
            ++GameplayManager.Instance.PlayerData.AmountCollected;
             pickupAudioSource.Play();
             
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
