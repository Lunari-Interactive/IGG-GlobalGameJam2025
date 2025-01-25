using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour
{
    public float speed = 0.095f;
    public float lifeTime = 50f;

    public int targetPlayer;

    public GameObject particleEffect;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMoveScript player = collision.gameObject.GetComponent<PlayerMoveScript>();
        if(collision.gameObject.layer == targetPlayer && player != null && player.isProtected != true)
        {
            player.Die();
            Instantiate(particleEffect, gameObject.transform.position, transform.rotation);
        }
        if(collision.gameObject.layer == 6)
        {
            Die();
        }
    }

    void SelfDestruct()
    {
        Destroy(gameObject, lifeTime);
    }

    void Die()
    {
        Instantiate(particleEffect, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
