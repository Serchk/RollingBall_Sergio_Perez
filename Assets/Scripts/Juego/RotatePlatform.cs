using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    //Rigidbody rb;
    [SerializeField] Vector3 direccionR;
    [SerializeField] int velocidad;
    [SerializeField] float fuerzaR;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(direccionR * fuerzaR, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(direccion * velocidad * Time.deltaTime);

    }
}
