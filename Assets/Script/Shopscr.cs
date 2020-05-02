using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopscr : MonoBehaviour
{
    public GameObject ItemPref;
    public Transform ItemGrid;
    public GameController gc;
    public int i = -1;

    // Start is called before the first frame update
    void Start()
    {
        gc= FindObjectOfType<GameController>();
       
        foreach(Towercl tower in gc.allTowers)
        {
            GameObject tmpitem = Instantiate(ItemPref);
            tmpitem.transform.SetParent(ItemGrid, false);
            tmpitem.GetComponent<ShopItemscr>().SetStartData(tower, ++i, gc);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
