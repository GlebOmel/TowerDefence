using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOveToThePoint : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    int curpoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curpoint < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[curpoint].position, Time.deltaTime * speed);
            transform.LookAt(waypoints[curpoint].position);
            if (Vector3.Distance(transform.position, waypoints[curpoint].position) < 0.5f) curpoint++;
        }
    }
}
