using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorTerceraPrsona : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float smoothTime;
    

    private float velocidadRotacion;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverTRotar();
    }
    void MoverTRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        Vector2 input = new Vector2(h, v).normalized;

        //Calculo el ángulo al que tengo que rotarme en función de los inputs y cámara


        if (input.sqrMagnitude > 0)
        {            
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadRotacion, smoothTime);

            transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            //Mi movimiento tambian ha quedado rotado en la base
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;
        }
       
    }
}
