using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorMenu : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fuerzaVelocidad;
    float x, z;

    [SerializeField] float distanciaRaycast;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Play"))
        {
            SceneManager.LoadScene(1);
        }
        if (other.gameObject.CompareTag("Quit"))
        {
            Application.Quit();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(direccionF * fuerza, ForceMode.TipoF);
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DetectarSuelos())
            {
                rb.AddForce(new Vector3(0, 1, 0) * fuerzaVelocidad, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(x, 0, z) * fuerzaVelocidad, ForceMode.Force);
    }    
    private bool DetectarSuelos()
    {
        bool detectaSuelo = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaRaycast);
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0), Color.red, 2f);
        return detectaSuelo;
    }
}
