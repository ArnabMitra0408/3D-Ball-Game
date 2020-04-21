using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{   [SerializeField]
    private float speed;
    Rigidbody rb;
    bool started;
    bool gameover;
    public GameObject particle;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                GameManager.instance.startgame();
            }
        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))//origin position: ball origin, ray dirction, ray lenght. ray cast returns true if its colliding with any other game object
        {
            gameover = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<camerafollow>().gameover = true;
            GameManager.instance.gameover();
        }
        if(Input.GetMouseButtonDown(0)& !gameover)//0 mouse button is LMB 
        {
            SwitchDirection();
        }
    }
    void SwitchDirection()
    {
        if(rb.velocity.z>0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x>0)
        {
            rb.velocity = new Vector3(0,0,speed);
        }
    }
    void OnTriggerEnter(Collider col)
    {
      if(col.gameObject.tag=="diamond")
        {
            GameObject par= Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(par, 1f);

            
        }
    }

}
