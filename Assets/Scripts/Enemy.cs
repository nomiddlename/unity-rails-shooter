using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
