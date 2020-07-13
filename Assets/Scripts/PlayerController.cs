using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    float steerMin = 0f;
    float steerMax = 120f;

    [SerializeField] GameObject boatObject;

    [SerializeField] Material swampMat;

    [SerializeField] ParticleSystem flameParticles;
    [SerializeField] GameObject flameCollider;
    void Start()
    {
        StartGame();
    }


    public void StartGame()
    {
        StartCoroutine(RotateBoat());
        StartCoroutine(FlameThrower());
         swampMat.SetTextureOffset("_MainTex", new Vector2(0, 0));
    }

    IEnumerator RotateBoat()
    {
        float XoffSet = 0;
         float YoffSet = 0;
        float xTemp = 0;
        float yTemp = 0;
        yield return new WaitForSeconds(0.4f); 
        while (GameManager.instance.gameRunning)
        {
            
            float wheelRot = InputManager.instance.steerVar/8.525f;
            float Zrot = Mathf.Clamp(wheelRot, steerMin, steerMax);
            Quaternion quat = Quaternion.Euler(0, 0, -(Zrot-60f)); // fyysisen ratin keskikohta verrattuna virtuaalimaailmaan on 60 astetta
            boatObject.transform.rotation = quat;


            //setting swamp materials offset so it looks like a repeating background
            //these numbers are p much trial and error, no science here
            xTemp = 0.0015f * (Zrot-60f);

            XoffSet += xTemp;

        
            yTemp =  0.09f +(0.05f-Mathf.Abs(xTemp));

            YoffSet += yTemp;
        
            Debug.Log("X: "+ xTemp + "  Y: " + yTemp);
            
            
            swampMat.SetTextureOffset("_MainTex", new Vector2(XoffSet, YoffSet));

            


            


            yield return null;
        }
    }
    IEnumerator FlameThrower(){

        yield return new WaitForSeconds(0.4f); 
        while (GameManager.instance.gameRunning)
        {
            
            if(InputManager.instance.flameVar>=600){
                FlameThrowerToggle(true);
               // Debug.Log("ON");
            }
            else{
                FlameThrowerToggle(false);
                 //Debug.Log("OFF");
            }
            yield return null;
        }
    }

    void FlameThrowerToggle(bool flameOn){

        if(flameOn){
            flameParticles.Play();
            flameCollider.SetActive(true);
        }
        else{
            flameParticles.Stop();
            flameCollider.SetActive(false);
        }

    }
}
