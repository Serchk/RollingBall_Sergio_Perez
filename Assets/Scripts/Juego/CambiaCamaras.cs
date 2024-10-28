using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCamaras : MonoBehaviour
{
    [SerializeField] GameObject virtualCamera, otherCamera;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (virtualCamera.activeSelf)
            {
                virtualCamera.SetActive(false);
                otherCamera.SetActive(true);
            }
            else if (otherCamera.activeSelf)
            {
                virtualCamera.SetActive(true);
                otherCamera.SetActive(false);
            }
        }
    }
}
