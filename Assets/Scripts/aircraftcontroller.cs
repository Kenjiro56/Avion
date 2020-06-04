using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraftcontroller : MonoBehaviour
{


    // Start is called before the first frame update
    public float speed;
    float angle = 1.0f;
    void Start(){
       
    }

    // Update is called once per frame
    void Update(){

        

        this.transform.Translate(Vector3.right * Time.deltaTime * -speed);
        

        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Rotate(Vector3.forward, -angle);
        }
       
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.forward, angle);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, angle);            
        }
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up,-angle);
        }
        

    }
}
