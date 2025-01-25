using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed = 5f;

    public string inputNameHorizontal;
    public string inputNameVertical;

    public float inputHorizontal;
    public float inputVertical;

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


        
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = player.transform.up;
        rb.AddForce(moveDir * speed * 10, ForceMode2D.Force);
    }
}
