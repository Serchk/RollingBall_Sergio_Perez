using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] Vector3 direccion; 
    [SerializeField] int velocidad;
    [SerializeField] float timerLimite;
    bool cambiarDireccion = true;

    [Header("Rotación")]
    [SerializeField] float rotarX;
    [SerializeField] float rotarY;
    [SerializeField] float rotarZ;

    [Header("Timer")]
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        //transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        

        if (timer >= timerLimite)
        {
            cambiarDireccion = !cambiarDireccion;
            //transform.eulerAngles = new Vector3(0, cambiarDireccion ? -90 : 90, 0);
            //transform.eulerAngles = new Vector3(rotarX, rotarY, rotarZ);
            timer = 0f;
        }

        if (cambiarDireccion == true)
        {
            transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);
            //transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        else if (cambiarDireccion == false)
        {
            transform.Translate(direccion.normalized * -velocidad * Time.deltaTime, Space.World);
            //transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }


    }
}
