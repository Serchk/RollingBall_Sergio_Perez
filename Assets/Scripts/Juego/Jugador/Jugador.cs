using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Jugador : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fuerzaVelocidad, fuerzaSalto;
    float x, z;

    [SerializeField] int monedas;
    [SerializeField] int vidasIniciales;
    int vidas;
    [SerializeField] int contadorIndcaciones = 0;

    [SerializeField] Vector3 direccionPatada;
    Vector3 posicionInicial;
    Vector3 posicionCheckPoint;
    [SerializeField] bool checkPoint = false;
    [SerializeField] float distanciaRaycast;

    [SerializeField] GameObject canvasHUD, canvasPausa;
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
                 rb.AddForce(new Vector3(0, 1, 0) * fuerzaSalto, ForceMode.Impulse);
             }
         }
        CanvasPausa();
        canvasUI();

    }
    private void canvasUI()
    {
        textVidas.SetText("Vidas: " + vidas);
    }
    private void CanvasPausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            canvasPausa.SetActive(!canvasPausa.activeSelf);
            if (canvasPausa.activeSelf )
            {
                Time.timeScale = 0.2f;
            }
            else
            {
                Time.timeScale = 1;
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
            vidas++;
            textMonedas.SetText("Monedas: " + monedas);
        }
        
        if (other.gameObject.CompareTag("Trampa"))
        {
            vidas--;            
            //textVidas.text = "Vidas: " + vidas;
        }
        if (other.gameObject.CompareTag("Vacio"))
        {
            vidas--;
            if (!checkPoint)
            {
                transform.position = posicionInicial;
            }
            else if (checkPoint)
            {
                transform.position = posicionCheckPoint;
            }
        }
        if (other.gameObject.CompareTag("camDestroy"))
        {
            Destroy(other.gameObject);
        } 
        if (other.gameObject.CompareTag("Destruible"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Patada"))
        {
            rb.AddForce(direccionPatada, ForceMode.Impulse);
        } 
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            if (checkPoint == false)
            {
                checkPoint = true;
            }
            else
            {
                checkPoint = true;
            }
            posicionCheckPoint = transform.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destruible"))
        {
            Destroy(collision.gameObject, 0.25f);
        }
    }
    private bool DetectarSuelos()
    {
       bool detectaSuelo = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaRaycast);
       Debug.DrawRay(transform.position, new Vector3(0, -1, 0), Color.red, 2f);
       return detectaSuelo;
    }
   


}
