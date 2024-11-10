using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlOtroPortal : MonoBehaviour
{
    [SerializeField] GameObject teletransPorte;
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            teletransPorte.SetActive(true);
        }
    }
}
