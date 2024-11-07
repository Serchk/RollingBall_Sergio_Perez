using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patada : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Vector3 direccion, fuerza;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direccion, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
