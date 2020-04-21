using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startgame()
    {
        UIManager.instance.GameStart();
        Scoremanager.instance.startscore();
        GameObject.Find("platformspawner").GetComponent<platformspawner>().Startspawningplatform();
    }
    public void gameover()
    {
        UIManager.instance.GameOver();
        Scoremanager.instance.stopscore();
        gameOver = true;
    }

       
}
