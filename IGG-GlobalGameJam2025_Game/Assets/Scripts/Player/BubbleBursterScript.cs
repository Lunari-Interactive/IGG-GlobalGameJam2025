using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleBursterScript : MonoBehaviour
{
    public GameObject parent;
    public AudioSource bubbleAudioSource;
    public AudioClip bubblePoppingClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMoveScript player = collision.gameObject.GetComponent<PlayerMoveScript>();
        if (collision.gameObject.tag == "Player" && player.isProtected)
        {
            player.isProtected = false;
            bubbleAudioSource.clip = bubblePoppingClip;
            bubbleAudioSource.Play();
        }
        if (collision.gameObject.layer == 8)
        {
            Destroy(parent);
            Destroy(collision.gameObject);
            bubbleAudioSource.PlayOneShot(bubblePoppingClip);
        }
    }
}
