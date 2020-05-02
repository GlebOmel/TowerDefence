using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    public Tower twr;
    public GameObject curEnemy;
    public bool busy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!curEnemy)
        {
            busy = false;
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("enemy") && !busy)
        {
            twr.target = other.gameObject.transform;
            curEnemy = other.gameObject;
            busy = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemy") && other.gameObject==curEnemy)
        {
            busy = false;
            twr.target = null;
        }
    }
}
