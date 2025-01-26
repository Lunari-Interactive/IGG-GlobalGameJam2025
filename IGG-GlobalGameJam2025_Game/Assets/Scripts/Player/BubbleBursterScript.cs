using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleBursterScript : MonoBehaviour
{
    public GameObject parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMoveScript player = collision.gameObject.GetComponent<PlayerMoveScript>();
        if (collision.gameObject.tag == "Player" && player.isProtected)
        {
            player.isProtected = false;
        }
        if (collision.gameObject.layer == 8)
        {
            Destroy(parent);
            Destroy(collision.gameObject);
        }
    }
}
