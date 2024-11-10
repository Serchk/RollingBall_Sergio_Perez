using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalMal : MonoBehaviour
{
    [SerializeField] private GameObject portalRojo;
    [SerializeField] private GameObject portalesAltern;
   
    [SerializeField] TMP_Text textoPortal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            portalRojo.SetActive(true);
            portalesAltern.SetActive(true);
            
            Destroy(gameObject);           
           
            textoPortal.SetText("Tanto esfuerzo para que fuese el camino facil. Que rabia."); 
        }

    }
}
