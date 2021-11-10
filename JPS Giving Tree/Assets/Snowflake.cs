using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowflake : MonoBehaviour
{
    int rotDir = 1;
    float scale = 1;
    // Start is called before the first frame update
    void Start()
    {
        int rot = Random.Range(0,2);
        if (rot > 0)
            rotDir = -1;

        scale = Random.Range(1, 1.6f);

        gameObject.transform.localScale = new Vector3(scale, scale, 1);

       

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 35 * Time.deltaTime*rotDir));
        transform.position -= new Vector3(0, 100 * Time.deltaTime, 0);

     

        if (gameObject.transform.position.y < -50)
            Destroy(gameObject);
    }
}
