using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public  bool gameRunning = true;
    void Start()
    {
        if(instance != null){
            Destroy(this);
        }
        else{
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
