using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    float timer = 1;
    float currentTime = 0;
    public GameObject snowflake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime>timer)
        {
            currentTime = 0;
            Instantiate(snowflake, new Vector3(Random.Range(0, 420),450,0), Quaternion.identity, transform);
            currentTime = Random.Range(0, .9f);
        }
    }
}
