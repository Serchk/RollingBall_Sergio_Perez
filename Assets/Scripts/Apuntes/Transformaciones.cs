using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformaciones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(dirección * velocidad * Time.deltaTime);
        transform.Translate(new Vector3(1, 0, 0) * 1 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
