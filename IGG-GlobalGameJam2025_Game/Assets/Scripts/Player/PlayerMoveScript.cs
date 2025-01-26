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
    public bool equippedMine = false;
    public GameObject proximityMine;

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
        if (isPlayer1 && Input.GetKeyDown(KeyCode.W) && ammoCount > 0 && equippedMine == true)
        {
            SpawnMine();
            equippedMine=false;
        }
        if (!isPlayer1 && Input.GetKeyDown(KeyCode.UpArrow) && ammoCount > 0 && equippedMine == true)
        {
            SpawnMine();
            equippedMine = false;
        }

        if (ammoCount <= 0)
        {
            StartCoroutine(Reload());
        }

        if (!isProtected)
        {
            bubbleBurster.SetBool("BubblePop", true);
        }
        else
        {
            bubbleBurster.SetBool("BubblePop", false);
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

    void SpawnMine()
    {
        Instantiate(proximityMine, transform.position, transform.rotation);
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
