using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraftcontroller : MonoBehaviour
{


    // Start is called before the first frame update
    public float speed;
    public GameObject navigator;
    void Start(){
       
    }

    // Update is called once per frame
    void Update(){
        Vector3 ang = this.transform.localEulerAngles;
        //ang.x = 0;
        this.transform.Translate(Vector3.right * Time.deltaTime * -speed);
        float angle = 1.0f;
        if (Input.GetKey(KeyCode.UpArrow)) {
            //transform.position += new Vector3(0.0f, 0.1f, 0.0f);
            transform.Rotate(Vector3.forward, -angle);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position += new Vector3(0.0f, -0.1f, 0.0f);
            transform.Rotate(Vector3.forward, angle);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, angle);
           // transform.Rotate(transform.right, -angle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            this.transform.localEulerAngles = ang;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up,-angle);
           // transform.Rotate(transform.right, angle);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.transform.localEulerAngles = ang;
        }

    }
}
