using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject chek, unChek;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            chek.SetActive(true);
            unChek.SetActive(false);            
        }

    }
}
