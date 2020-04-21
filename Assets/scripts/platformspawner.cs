using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformspawner : MonoBehaviour
{
    public GameObject platform;
    Vector3 lastpos;
    float size;
    public bool Gameover;
    public GameObject diamonds;

    // Start is called before the first frame update
    void Start()
    {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;
        /*for(int i=0;i<5;i++)
        {
            spawnx();
        }*/
        for (int i = 0; i < 20; i++)
        {
            spawnPlatform();
        }
        //InvokeRepeating("spawnPlatform",2f,0.2f);//this will call spawn platform ever 0.2 sec after having an initial wait of 2 sec

    }
    public void Startspawningplatform()
    {
        InvokeRepeating("spawnPlatform", 0.2f, 0.2f);//this will call spawn platform ever 0.2 sec after having an initial wait of 2 sec
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver==true)
        {
            CancelInvoke("spawnPlatform");
        }
    }
    void spawnPlatform()
    {
        
       int rand=Random.Range(0, 6);
        if(rand<3)
        {
            spawnx();
        }
        else if(rand>=3)
        {
            spawnz();
        }

    }
    void spawnx()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos,Quaternion.identity);//make a new plaform at location pos and rotate it by 0 deg
        int rand = Random.Range(0, 4);
        if(rand<1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }
    void spawnz()
    {

        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);//make a new plaform at location pos and rotate it by 0 deg
        int rand = Random.Range(0, 4);
        if(rand<1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }
}
