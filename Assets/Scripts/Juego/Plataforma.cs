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
        
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        transform.eulerAngles= new Vector3(0, cambiarDireccion ? -90 : 90,0);

        if (timer >= timerLimite)
        {
            cambiarDireccion = !cambiarDireccion;
            timer = 0f;
        }

        //if (cambiarDireccion == true)
        //{
        //    transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        //    //transform.eulerAngles = new Vector3(0f, 90f, 0f);
        //}
        //else if(cambiarDireccion == false)
        //{
        //    transform.Translate(-direccion.normalized * velocidad * Time.deltaTime);
        //    //transform.eulerAngles = new Vector3(0f, 270f, 0f);
        //}


    }
}
