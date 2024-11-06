using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetGameobject2 : MonoBehaviour
{
    [SerializeField] private GameObject portalRojo;
    [SerializeField] TMP_Text textoPortal;
    //[SerializeField] TMP_Text textoPortal2;
    [SerializeField] SetGameobject contador;
    int contadorr = 0;

    
    public int Contadorr { get => contadorr; set => contadorr = value; }

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
            contadorr = contador.Contador + 1;
            portalRojo.SetActive(true);
            Destroy(gameObject);
            if (contadorr == 1)
            {
                textoPortal.SetText("Este no");
            }
            else if (contadorr == 2)
            {
                textoPortal.SetText("Tampoco");
            }


        }

    }
}
