using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    float timer;
  

    void Start()
    {
        
    }

    
    void Update()
    {
        timer += 1 * Time.deltaTime; // el 
        Debug.Log(timer);
    }
}
