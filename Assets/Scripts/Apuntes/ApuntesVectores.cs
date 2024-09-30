using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntesVectores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(5, 0, 0);
        transform.eulerAngles = new Vector3(45, 0, 0);
        transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
