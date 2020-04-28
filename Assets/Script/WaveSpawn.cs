using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public int WaveSize;
    public GameObject EnemyPrefab;
    public float enemyInterval;
    public float startTime;
    public Transform spawnPoint;
    int enemyCount = 0;
    public Transform[] WayPoints;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, enemyInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == WaveSize) CancelInvoke("Spawn");
    }
    void Spawn()
    {
        enemyCount++;
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<MOveToThePoint>().waypoints = WayPoints;
    }
}
