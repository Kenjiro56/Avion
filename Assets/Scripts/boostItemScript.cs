using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostItemScript : MonoBehaviour
{
    public aircraftcontroller controllerscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
       
        controllerscript.burst();  
        Destroy(gameObject);
    }
}
