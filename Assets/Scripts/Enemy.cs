using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hits = 10;

    ScoreBoard scoreBoard;

    // Use this for initialization
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits < 1)
        {
            Death();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits -= 1;
    }

    private void Death()
    {
        GameObject explosion = Instantiate(deathFX, gameObject.transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        Destroy(gameObject);
    }
}
