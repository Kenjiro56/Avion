using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aircraftcontroller : MonoBehaviour
{


    // Start is called before the first frame update
    public float speed;
    float angle = 1.0f;
    public float boost;
    public Text boostText;
    public Slider oilgage;
    public float Maxoil;
    float oilmeter;

    void Start(){
        oilmeter = Maxoil;
    }

    // Update is called once per frame
    void Update(){

        oilgage.maxValue = Maxoil;
        oilgage.value = oilmeter;
        //oilmeter -= 0.1f;

        boostText.enabled = false;
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
        if (Input.GetKey(KeyCode.Space)) {
            boostText.enabled = true;
            transform.Translate(Vector3.right* Time.deltaTime*-boost);
            oilmeter--;
        }

    }
}
