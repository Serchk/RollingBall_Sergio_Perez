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
    [SerializeField] int vidasIniciales;
    int vidas;

    Vector3 posicionInicial;
    [SerializeField] float distanciaRaycast;

    [SerializeField] GameObject canvasHUD;
    [SerializeField] TMP_Text textMonedas, textVidas;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        canvasHUD.SetActive(true);
        vidas = vidasIniciales;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(direccionF * fuerza, ForceMode.TipoF);
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        ReaparecerMuerte();
    
        
         if (Input.GetKeyDown(KeyCode.Space))
         {
             if(DetectarSuelos())
             {
                 rb.AddForce(new Vector3(0, 1, 0) * fuerzaVelocidad, ForceMode.Impulse);
             }
         }
        

    }
  
    void ReaparecerMuerte()
    {
        if (vidas == 0)
        {
            transform.position = posicionInicial;
            vidas = vidasIniciales;
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(x, 0, z) * fuerzaVelocidad, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            //textMonedas.text = "Monedas: " + monedas;
            monedas++;
            textMonedas.SetText("Monedas: " + monedas);
        }
        
        if (other.gameObject.CompareTag("Trampa"))
        {
            vidas--;
            textVidas.SetText("Vidas: " + vidas);
            //textVidas.text = "Vidas: " + vidas;
        }
        if (other.gameObject.CompareTag("Vacio"))
        {
            transform.position = posicionInicial;
        }

    }
    private bool DetectarSuelos()
    {
       bool detectaSuelo = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaRaycast);
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0), Color.red, 2f);
       return detectaSuelo;
    }

}
