using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{

    float minSpeed = 0f;
    float maxSpeed = 2f;

    float xTemp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.Translate(Vector2.down* 0.4f);
        float rot = InputManager.instance.steerVar/341;
        float speed= Mathf.Clamp(rot, minSpeed, maxSpeed);

        xTemp = 0.2f * (speed-1f);
        //Debug.Log(xTemp);

        gameObject.transform.Translate(new Vector2(-xTemp, 0)); // y = -1* 0.4f
    }

    
}
