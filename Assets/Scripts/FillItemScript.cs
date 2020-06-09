using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillItemScript : MonoBehaviour
{
    public float current_oil;
    public int fillpoint = 50;
    public aircraftcontroller controllerscript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        controllerscript.filloil(fillpoint);
        Destroy(gameObject);
    }
}
