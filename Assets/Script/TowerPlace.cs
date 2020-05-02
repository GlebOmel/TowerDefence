using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public GameObject Tower;
    public Vector3 offset;
    public GameObject CurrTower;
    public bool isempty = true;
    public GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {        
        if (isempty && gc.IndexTowerPurchased >= 0)
        {
            if (Pointmanager.Instance.gamemoney >= gc.allTowers[gc.IndexTowerPurchased].Price)
            {
                CurrTower = GameObject.Instantiate(gc.allTowers[gc.IndexTowerPurchased].Tower, transform.position + offset, Quaternion.identity) as GameObject;
                isempty = false;
                //gc.IndexTowerPurchased = -1;

                Pointmanager.Instance.gamemoney -= gc.allTowers[gc.IndexTowerPurchased].Price;
            }
        }

    }
    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = gc.BaseColor;
    }
    void OnMouseEnter()
    {
        if (isempty)
            GetComponent<MeshRenderer>().material.color = gc.SelectColor;
        
            
        else GetComponent<MeshRenderer>().material.color = gc.BusyColor;
    }
}
