using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // randomly create the platforms in Unity
    public List<GameObject> allplatforms = new List<GameObject>();
    // a list include prefab of all platforms

    public float spwantime;
    // time between to create a random new platform
    private float recordtime;
    // count time
    private Vector3 sposition;
    // where are the random platforms created

    void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        recordtime += Time.deltaTime;
        sposition = transform.position;
        sposition.x = Random.Range(-3.6f, 3.6f);
        // platforms moving upwards
        // x range from -3.6 to 3.6

        if (recordtime >= spwantime)
        {
            // if satisfy time condition, then new platform created
            CreatePlatform();
            recordtime = 0;
            // let time count be 0 again
        }
    }

    public void CreatePlatform()
    {
        int index = Random.Range(0, allplatforms.Count);
        // 0 to last platform

        GameObject newplatform = Instantiate(allplatforms[index], sposition, Quaternion.identity);
        // create new platform (which one, position, angle), here, no change in angle
        newplatform.transform.SetParent(this.gameObject.transform);
    }
}
