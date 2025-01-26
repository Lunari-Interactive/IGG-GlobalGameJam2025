using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffPowerUp : MonoBehaviour
{
    PlayerMoveScript player;
    public float powerUpDuration = 3f;
    float tempValue;

    public SpriteRenderer sprite;
    public CircleCollider2D circleCollider;

    public Animator powerUpAnimator;
    public AudioSource AudioSource;
    public AudioClip pickUpPowerUpClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerMoveScript>();
        if(player != null && collision.tag == "Player")
        {
            tempValue = player.speed;
            player.speed = 1f;
            powerUpAnimator.SetBool("isTaken", true);
            AudioSource.PlayOneShot(pickUpPowerUpClip);
            sprite.sprite = null;
            circleCollider.enabled = false;
            StartCoroutine(TurnOffPowerUp());
        }

    }

    IEnumerator TurnOffPowerUp()
    {
        yield return new WaitForSeconds(powerUpDuration);
        player.speed = tempValue;
        Destroy(gameObject, 0.1f);
    }
}
