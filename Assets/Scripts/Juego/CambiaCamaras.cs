using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCamaras : MonoBehaviour
{
    [SerializeField] GameObject virtualCamera, camaraCenital;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (virtualCamera.activeSelf)
            {
                virtualCamera.SetActive(false);
                camaraCenital.SetActive(true);
            }
            else
            {
                virtualCamera.SetActive(false);
                camaraCenital.SetActive(true);
            }
        }
    }
}
