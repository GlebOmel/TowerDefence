using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pointmanager : MonoBehaviour
{
    public static Pointmanager Instance;
    public Text moneytxt;
    public int gamemoney;
    public int EnemyNotDestroyed = 0;
    public GameObject GateofWave;
    public Text Waveinform;
    public Text Enemyinform;
    public int WaveIndex = 1;
    //public int Score =0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        GateofWave.GetComponent<WaveSpawn>().NextSpawn(WaveIndex);
        EnemyNotDestroyed = WaveIndex + 4;
    }

    // Update is called once per frame
    void Update()
    {
        moneytxt.text = gamemoney.ToString();
        if (EnemyNotDestroyed <= 0)
        {
            WaveIndex++;
            GateofWave.GetComponent<WaveSpawn>().NextSpawn(WaveIndex);
            Waveinform.text = "Wave № " + WaveIndex.ToString();
            Enemyinform.text= "Enemy left:" + EnemyNotDestroyed.ToString();
        }
    }
    public void GameOver()
    {
        MainMenu.Score = WaveIndex*5-EnemyNotDestroyed-9;
        //GetComponent<MainMenu>().Score = Score;
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(temp.GetComponent<MOveToThePoint>().hp);
            Destroy(temp);
        }
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag("tower"))
        {
            Destroy(temp);
        }

        EnemyNotDestroyed = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //GetComponent<Shop>().SetActive(false);
    }
}
