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
    public GameObject Hp;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
    }
     
    // Update is called once per frame
    void Update()
    {
        //if (WaveIndex < WaveSize-3)
        //{            
        //    InvokeRepeating("Spawn", startTime, enemyInterval);
        //    Pointmanager.Instance.EnemyNotDestroyed = WaveSize;
        //    WaveIndex++;
        //}
        //if (enemyCount == WaveSize) CancelInvoke("Spawn");
    }
    public void NextSpawn(int WaveIndex)
    {
        WaveSize = WaveIndex + 4;        
            InvokeRepeating("Spawn", startTime, enemyInterval);
            Pointmanager.Instance.EnemyNotDestroyed = WaveSize;
            WaveIndex++;
        
        //if (enemyCount == WaveSize) CancelInvoke("Spawn");
    }
    void Spawn()
    {
        enemyCount++;
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<MOveToThePoint>().waypoints = WayPoints;
        GameObject hp = GameObject.Instantiate(Hp, Vector3.zero, Quaternion.identity) as GameObject;
        hp.transform.SetParent(canvas.transform);
        hp.GetComponent<Hpbar>().Enemy = enemy;
        enemy.GetComponent<MOveToThePoint>().hp = hp;
        if (enemyCount == WaveSize)
        {
            CancelInvoke("Spawn");
            enemyCount = 0;
        }
    }
   
}
