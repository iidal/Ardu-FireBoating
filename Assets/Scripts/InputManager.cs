using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO.Ports;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

   SerialPort serPort = new SerialPort("COM3", 9600);

    [SerializeField] public float steerVar = 0;
    [SerializeField]public float flameVar = 0;
    [SerializeField]public bool buttonPressed = false;

    string s = " ";


    void Awake()
    {
        serPort.Open();
        StartCoroutine(ReadArduino());
    }
    void Start(){
        if(instance != null){
            Destroy(this);
        }
        else{
            instance = this;
        }
    }

    IEnumerator ReadArduino()
    {
        
        while (true)
        {
            s = serPort.ReadLine();
            string [] values = s.Split(',');
            flameVar = (float.Parse(values[0]));
            
            if(values[1] == "pressing"){
                buttonPressed = true;
            }
            else{buttonPressed = false;}

            steerVar = (float.Parse(values[2]));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
