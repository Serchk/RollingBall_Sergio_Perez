using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;


public class Jugador : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fuerzaVelocidad;
    float x, z;
    [SerializeField] int monedas;
    [SerializeField] int vidas;
    Vector3 posicionInicial;
    [SerializeField] GameObject canvasHUD;
    [SerializeField] TMP_Text textMonedas, textVidas;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        canvasHUD.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        textMonedas.text = "Monedas: " + monedas;
        textVidas.text = "Vidas: " + vidas;
        //rb.AddForce(direccionF * fuerza, ForceMode.TipoF);
        
        
       

    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * fuerzaVelocidad, ForceMode.Impulse);
        }
        rb.AddForce(new Vector3(x, 0, z) * fuerzaVelocidad, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            monedas++;
        }
        
        if (other.gameObject.CompareTag("Trampa"))
        {
            vidas--;
        }
        if (other.gameObject.CompareTag("Vacio"))
        {
            transform.position = posicionInicial;
        }

    }
}
