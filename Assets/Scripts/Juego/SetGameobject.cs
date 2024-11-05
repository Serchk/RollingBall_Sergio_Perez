using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameobject : MonoBehaviour
{
    [SerializeField] private GameObject portalRojo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
       
        if (other.gameObject.CompareTag("Player"))
        {
            portalRojo.SetActive(true);
            Destroy(gameObject);
        }
       
    }
}
