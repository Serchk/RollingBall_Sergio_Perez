using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Jugador : MonoBehaviour
{

    
    Rigidbody rb;
    [SerializeField] float fuerzaVelocidadMov;
     float fuerzaVelocidad;
     float fuerzaVelocidadCero = 0;
    [SerializeField] float fuerzaSalto;
    float x, z;
    [SerializeField] int vidasIniciales;
    int vidas;
    [SerializeField] int vidasExtra;
    int contador = 1;
    [SerializeField] GameObject transformable1, transformable2;

    [Header("Impulso")]
    [SerializeField] Vector3 direccionPatadaX;
    //[SerializeField] Vector3 direccionPatadaY;
    [SerializeField] Vector3 direccionPatadaZ;

    [Header("Position")]
    Vector3 posicionInicial;
    Vector3 posicionCheckPoint;
    [SerializeField] bool checkPoint = false;
    [SerializeField] float distanciaRaycast;

    [Header("Canvas")]
    [SerializeField] GameObject canvasHUD;
    [SerializeField] GameObject canvasPausa;
    [SerializeField] GameObject canvasFin;
    [SerializeField] TMP_Text textMonedas, textVidas;

    [Header("Cámaras")]
    [SerializeField] GameObject virtualCamera;
    [SerializeField] GameObject otherCamera;
    CambiaCamaras camara;

    // Start is called before the first frame update
    void Start()
    {
        fuerzaVelocidad  = fuerzaVelocidadMov;
        rb = GetComponent<Rigidbody>();
        camara = GetComponent<CambiaCamaras>();
        posicionInicial = transform.position;
        canvasHUD.SetActive(true);
        vidas = vidasIniciales;
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(direccionF * fuerza, ForceMode.TipoF);
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        //ReaparecerMuerte();
    
        
         if (Input.GetKeyDown(KeyCode.Space))
         {
             if(DetectarSuelos())
             {
                 rb.AddForce(new Vector3(0, 1, 0) * fuerzaSalto, ForceMode.Impulse);
             }
         }
        CanvasPausa();
        canvasUI();
        GameOver();

    }
    private void GameOver()
    {
        if(vidas <= 0)
        {
            Destroy(gameObject);
            canvasFin.SetActive(true);
            virtualCamera.SetActive(false);
            otherCamera.SetActive(true);

        }
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
            if (canvasPausa.activeSelf)
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
            fuerzaVelocidad = fuerzaVelocidadCero;
            transform.position = posicionInicial;
            vidas = vidasIniciales;
            fuerzaVelocidad = fuerzaVelocidadMov;
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(x, 0, z) * fuerzaVelocidad, ForceMode.Force);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("VacioOut"))
        {           
            vidas--;
            if (!checkPoint)
            {
                transform.position = posicionInicial;
                fuerzaVelocidad = fuerzaVelocidadMov;
            }
            else if (checkPoint)
            {
                transform.position = posicionCheckPoint;
                fuerzaVelocidad = fuerzaVelocidadMov;
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            //textMonedas.text = "Monedas: " + monedas;
            vidasExtra++;
            vidas++;
            textMonedas.SetText("Monedas: " + vidasExtra);
        }
        if (other.gameObject.CompareTag("DragManager"))
        {
            if(rb.drag <= 0)
            {
                rb.drag = 1;
            }
            else if (rb.drag >= 1)
            {
                rb.drag = 0;
            }
            
        }    
        if (other.gameObject.CompareTag("DragVoid"))
        {
            rb.drag = 1;
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
            rb.AddForce(direccionPatadaX, ForceMode.Impulse);
        } 
        if (other.gameObject.CompareTag("PatadaZ"))
        {
            rb.AddForce(direccionPatadaZ, ForceMode.Impulse);
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
        if (collision.gameObject.CompareTag("Transformable"))
        {            
            Destroy(collision.gameObject, 0.25f);
            if(contador ==1)
            {
                transformable1.SetActive(true);
                contador++;
            }
            else if(contador == 2)
            {
                transformable2.SetActive(true);
            }
        }
    }
    private bool DetectarSuelos()
    {
       bool detectaSuelo = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaRaycast);
       Debug.DrawRay(transform.position, new Vector3(0, -1, 0), Color.red, 2f);
       return detectaSuelo;
    }
   


}
