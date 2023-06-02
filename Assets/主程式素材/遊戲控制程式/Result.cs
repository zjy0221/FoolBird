using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject result;
    //public Collider2D c;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        result.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D c)
    {
        result.SetActive(false);
    }
}
