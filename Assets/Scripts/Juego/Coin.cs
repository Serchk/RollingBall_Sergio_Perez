using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Vector3 direccion;
    [SerializeField] int velocidad;

    [SerializeField] Vector3 direccionAltura;
    [SerializeField] float velocidadAltura;
    [SerializeField] float timerLimite;
    float timer = 0f;

    [SerializeField] private AudioClip sonidoCoin;
    [SerializeField] private AudioManager miManager;
    //bool cambiarDireccion = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccion * velocidad * Time.deltaTime, Space.World);
        Oscilar();
    }
    void Oscilar()
    {
        if (timer <= -timerLimite)
        {
            timer = timerLimite;
        }

        timer -= Time.deltaTime;

        if (timer > 0)
        {
            transform.Translate(direccionAltura.normalized * velocidadAltura * Time.deltaTime, Space.World);

        }
        else if (timer <= 0)
        {
            transform.Translate(direccionAltura.normalized * -velocidadAltura * Time.deltaTime, Space.World);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            miManager.ReproducirSonido(sonidoCoin);
            Destroy(gameObject);
        }
    }
}
