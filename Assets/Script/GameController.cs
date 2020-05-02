using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.UI;

public class Towercl
{
    public float Range, Cooldown;
    public int Dmg, Price;
    public string Name;
    public GameObject bullet;
    public GameObject Tower;
    //public Sprite Spr;
    public Towercl(string name, int price, float range, float cd, int dmg, GameObject bobj, GameObject tobj)
    {     
        Name=name;
        Price=price;
        Range = range;
        Cooldown = cd;
        Dmg = dmg;
        bullet = bobj;
        Tower = tobj;
    }
}

public enum TowerType
{
    FIRST_TOWER,
    SECOND_TOWER
}
public class GameController : MonoBehaviour
{
    public List<Towercl> allTowers= new List<Towercl>();
    public List<GameObject> bullets = new List<GameObject> ();
    public List<GameObject> towers = new List<GameObject>();
    public int IndexTowerPurchased = -1;//, TowerPrice=0;
    public Color BaseColor, SelectColor, BusyColor;
    void Awake()
    {
        allTowers.Add(new Towercl("Standart", 50, 6, 1, 10, bullets[0], towers[0]));
        allTowers.Add(new Towercl("UpperRange", 75, 10, 1, 5, bullets[1], towers[1]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
