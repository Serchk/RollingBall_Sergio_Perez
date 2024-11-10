using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActivation : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    int contador;
    void Start()
    {
        canvas.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(other.gameObject);
            
            canvas.SetActive(true);
        }
    }
}
