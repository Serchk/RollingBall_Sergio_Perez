using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Jugador : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        //rb.AddForce(direccionF * fuerza, ForceMode.TipoF);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * 5, ForceMode.Impulse);
        }
            rb.AddForce(new Vector3(x, 0, z) * 5, ForceMode.Force);
       

    }
}
