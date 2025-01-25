using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagManager : MonoBehaviour
{
    public float timeToDie = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
