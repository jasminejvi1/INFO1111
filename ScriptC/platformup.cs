using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformup : MonoBehaviour
{
    Vector3 movement;
    //3D vector, because we need to change position of the platforms,x,y,z
    GameObject upperlimit;
    //when reach the upperlimit part, objects will not continue moving up
    public float speed;
    
    void Start()
    {
        movement.y = speed;
        //can move upwards
        upperlimit = GameObject.Find("UpperLimit");
    }
    void Update()
    {
        MovePlatform();
        //use the method
    }
    void MovePlatform()
    //create a method
    {
        transform.position += movement * Time.deltaTime;
        if (transform.position.y >= upperlimit.transform.position.y)
        {
            Destroy(gameObject);
            //if any object over the upperlimit, it will be destoryed
        }
    }
}

