using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCamaras : MonoBehaviour
{
    [SerializeField] GameObject virtualCamera, otherCamera;
    int contador1, contador2;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (virtualCamera.activeSelf && contador1 == 0)
            {
                virtualCamera.SetActive(false);
                otherCamera.SetActive(true);
                
            }
            else if (otherCamera.activeSelf && contador2 == 0)
            {
                
                virtualCamera.SetActive(true);
                otherCamera.SetActive(false);
            }
        }
    }
}
