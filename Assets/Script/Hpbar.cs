using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public GameObject Enemy;
    //public RectTransform rect;
    public int curHp = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(Enemy.transform.position);
        GetComponent<Text>().text = curHp.ToString();
    }
    public void Dmg (int dmgval)
    {
        curHp -= dmgval;
    }
}
