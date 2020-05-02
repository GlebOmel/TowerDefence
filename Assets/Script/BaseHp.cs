using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHp : MonoBehaviour
{
    public int HP = 100;
    public Text HPText;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            HP -= 10;
            Destroy(other.gameObject);
            Destroy(other.GetComponent<MOveToThePoint>().hp);
            Pointmanager.Instance.Enemyinform.text = "Enemy left:" + (--Pointmanager.Instance.EnemyNotDestroyed).ToString();
            HPText.text = HP.ToString();
            if (HP <= 0) Pointmanager.Instance.GameOver();
        }
    }
            

    // Update is called once per frame
    void Update()
    {
        //HPText.text = HP.ToString();
        //if (HP <= 0) Pointmanager.Instance.GameOver();
    }
}
