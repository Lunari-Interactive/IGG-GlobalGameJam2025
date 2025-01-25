using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed = 5f;

    public string inputNameHorizontal;
    public string inputNameVertical;

    float inputHorizontal;
    float inputVertical;

    public GameObject torpedo;
    public Transform torpedoSpawn;

    public bool isProtected = true;


    public Animator bubbleBurster;
    Transform player; 
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal += Input.GetAxis(inputNameHorizontal);
        inputVertical = Input.GetAxis(inputNameVertical);

        player.localRotation = Quaternion.Euler(0, 0, -inputHorizontal);

        if (inputVertical != 0f)
        {
            LaunchTorpedo();
        }

        if (!isProtected)
        {
            bubbleBurster.SetBool("BubblePop", true);
        }
        
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = player.transform.up;
        rb.AddForce(moveDir * speed * 10, ForceMode2D.Force);
    }

    void LaunchTorpedo()
    {
        Instantiate(torpedo, torpedoSpawn.position, torpedoSpawn.rotation);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
