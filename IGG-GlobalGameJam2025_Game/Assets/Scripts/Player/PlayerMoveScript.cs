using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveScript : MonoBehaviour
{
    public bool isPlayer1;

    public float speed = 5f;
    public int ammoCount = 3;
    int defaultAmmoCount;
    public float reloadTime = 2f;
    public bool isReloading = false;

    public string inputNameHorizontal;

    float inputHorizontal;

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
        defaultAmmoCount = ammoCount;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal += Input.GetAxis(inputNameHorizontal);
        

        player.localRotation = Quaternion.Euler(0, 0, -inputHorizontal);

        if(isPlayer1 && Input.GetKeyDown(KeyCode.W) && ammoCount > 0 && isReloading == false)
        {
            LaunchTorpedo();
        }
        if(!isPlayer1 && Input.GetKeyDown(KeyCode.UpArrow) && ammoCount > 0 && isReloading == false)
        {
            LaunchTorpedo();
            
        }
        
        if(ammoCount <= 0)
        {
            StartCoroutine(Reload());
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

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammoCount = defaultAmmoCount;
        isReloading = false;
    }

    void LaunchTorpedo()
    {
        Instantiate(torpedo, torpedoSpawn.position, torpedoSpawn.rotation);
        ammoCount -= 1;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
