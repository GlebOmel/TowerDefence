using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform shootElement;
    public Transform LookAtObj;
    public Transform target;
    public bool isshoot;
    
    //public GameObject bullet;

    public GameController gc;
    public TowerType selfType;
    Towercl selfTower;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController> ();
        selfTower = gc.allTowers[(int)selfType];
    }

    // Update is called once per frame
    void Update()
    {
        if(!target) searchTarget();
        if (target)
        {
            if (selfTower.Range < Vector3.Distance(transform.position, target.position))
            {
                target = null;
                searchTarget();
            }
            LookAtObj.transform.LookAt(target);

            if (!isshoot)
            {
                StartCoroutine(shoot());
            }
        }
    }
    void searchTarget()
    {
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("enemy"))
        {
            if (selfTower.Range >= Vector3.Distance(transform.position, temp.transform.position))
            {
                target = temp.transform;
                break;
            }

        }
    }
    IEnumerator shoot()
    {
        isshoot = true;
        yield return new WaitForSeconds(selfTower.Cooldown);
        GameObject curBullet = GameObject.Instantiate(selfTower.bullet, shootElement.position, Quaternion.identity) as GameObject;
        curBullet.GetComponent<Bullet>().target = target;
        curBullet.GetComponent<Bullet>().dmg = selfTower.Dmg;
        isshoot = false;
    }
}
