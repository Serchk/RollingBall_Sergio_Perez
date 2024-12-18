using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ParedCubos : MonoBehaviour
{
    private bool iniciarTimer = false;
    private float timer = 0;
    [SerializeField] private Rigidbody[] rbs;


    [SerializeField] private Volume volumen;
    [SerializeField] private ChromaticAberration aberration;
    BoxCollider colisionado;
    void Start()
    {
       colisionado = GetComponent<BoxCollider>();

    }
    private void Update()
    {
        if (iniciarTimer)
        {
            timer += Time.unscaledDeltaTime;
            if (timer >= 2)
            {
                Time.timeScale = 1f;
                timer =0;
                iniciarTimer=false;
                
                for (int i = 0; i < rbs.Length; i++) 
                {
                    rbs[i].useGravity = true;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            //aberration;
            Time.timeScale = 0.2f;
            iniciarTimer = true;
            Destroy(colisionado);
            
        }
    }
}
