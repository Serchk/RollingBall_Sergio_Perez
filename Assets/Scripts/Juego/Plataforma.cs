using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] Vector3 direccion; 
    [SerializeField] int velocidad;
    [SerializeField] float timerLimite;
    float timer = 0f;
    bool cambiarDireccion = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if (timer >= timerLimite)
        //{
        //    transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        //}
        //if (timer <= 0)
        //{
        //    transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        //    timer
        //}
        if (cambiarDireccion == true)
        {
            transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        }
        else if(cambiarDireccion == false)
        {
            transform.Translate(-direccion.normalized * velocidad * Time.deltaTime);
        }

        if (timer >= timerLimite && cambiarDireccion == true)
        {
            cambiarDireccion = false;
            timer  = 0f;
        }
        else if (timer >= timerLimite && cambiarDireccion == false)
        {
            cambiarDireccion = true;
            timer = 0f;
        }

    }
}
