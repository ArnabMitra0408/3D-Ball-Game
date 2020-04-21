using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public GameObject ball;
    public bool gameover;
    Vector3 offset;//distance between camera and ball
    public float lerprate;//rate by which the camera will change its position to follow the ball
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        offset = ball.transform.position - transform.position;// position of ball - position of camera= distance between two
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameover)
        {
            Follow();
        }
    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetpos =ball.transform.position-offset;
        pos=Vector3.Lerp(pos,targetpos,lerprate*Time.deltaTime);
        transform.position = pos;
    }
}
