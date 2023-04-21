using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmove : MonoBehaviour
{
    Material material;
    //adjust the material ball, need get its material first
    Vector2 movement;
    //give the movement a variable of x,y, 2D vector
    public Vector2 speed;
    //want to edit in Unity, add public
    //
    void Start()
    {
        material = GetComponent<Renderer>().material;
        //get the component, dont have 'material' on 'Quad', need to adjust material in render
    }

    void Update()
    {
        movement += speed * Time.deltaTime;
        //initial movement x=0,y=0, we want it to have speed
        //1 min/50times

        material.mainTextureOffset = movement;
        //use "movement" to  adjust material 'offset'
    }
    
}

