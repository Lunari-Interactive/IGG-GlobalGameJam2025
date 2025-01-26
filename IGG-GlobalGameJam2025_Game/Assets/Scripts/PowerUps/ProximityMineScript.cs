using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityMineScript : MonoBehaviour
{
    public float timeBeforeActivation = 3f;
    public CircleCollider2D detectionRadius;
    public float explosionDelay = 1f;
    public bool exploded;

    public GameObject explosionParticles;

    private void Start()
    {
        detectionRadius.enabled = false;
    }

    private void Update()
    {
        timeBeforeActivation -= Time.deltaTime;
        if(timeBeforeActivation <= 0)
        {
            detectionRadius.enabled=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(ExplosionSequence());
        }
        if(collision.tag == "Player" && exploded)
        {
            Instantiate(explosionParticles, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.1f);
        }
    }

    IEnumerator ExplosionSequence()
    {
        yield return new WaitForSeconds(explosionDelay);
        
        exploded = true;
    }

}
