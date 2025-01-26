using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffPowerUp : MonoBehaviour
{
    PlayerMoveScript player;
    public Animator powerUpAnimator;
    public AudioSource AudioSource;
    public AudioClip pickUpPowerUpClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerMoveScript>();
        if(player != null && collision.tag == "Player")
        {
            player.speed = 10f;
            powerUpAnimator.SetBool("isTaken", true);
            AudioSource.PlayOneShot(pickUpPowerUpClip);
            Destroy(gameObject, 0.2f);
        }

    }
}
