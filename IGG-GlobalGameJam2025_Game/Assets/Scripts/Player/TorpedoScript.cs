using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour
{
    public float speed = 0.095f;
    public float lifeTime = 50f;
    public float explosionForce = 100f;
    public float explosionRadius = 10f;

    public int targetPlayer;

    public GameObject particleEffect;
    public AudioSource torpedoAudio;
    public AudioClip torpedoExplosionClip;
    public AudioClip torpedoMovingClip;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SelfDestruct();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(gameObject.transform.up * speed, ForceMode2D.Force);
        torpedoAudio.clip = torpedoMovingClip;
        torpedoAudio.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMoveScript player = collision.gameObject.GetComponent<PlayerMoveScript>();
        if(collision.gameObject.layer == targetPlayer && player != null && player.isProtected != true)
        {
            ExplosionExt.AddExplosionForce(rb, explosionForce, transform.position, explosionRadius, explosionForce);
            player.Die();
            Instantiate(particleEffect, gameObject.transform.position, transform.rotation);
            torpedoAudio.clip = torpedoExplosionClip;
            torpedoAudio.Play();
        }
        if(collision.gameObject.layer == 6)
        {
            Die();
            torpedoAudio.clip = torpedoExplosionClip;
            torpedoAudio.Play();
        }
    }

    void SelfDestruct()
    {
        Destroy(gameObject, lifeTime);
        torpedoAudio.clip = torpedoExplosionClip;
        torpedoAudio.Play();
    }

    void Die()
    {
        Instantiate(particleEffect, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
