using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetGameobject : MonoBehaviour
{
    [SerializeField] private GameObject portalRojo;
    [SerializeField] TMP_Text textoPortal;
    //[SerializeField] TMP_Text textoPortal2;
    [SerializeField] SetGameobject contadorr;
    int contador = 0;

    public int Contador { get => contador; set => contador = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
       
        if (other.gameObject.CompareTag("Player"))
        {
            contador = contadorr.Contador + 1;
            portalRojo.SetActive(true);
            Destroy(gameObject);
            if (contador == 1)
            {
                textoPortal.SetText("Este no");
            }
            else if (contador == 2)
            {
                textoPortal.SetText("Tampoco");
            }


        }
       
    }
}
