using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class aircraftcontroller : MonoBehaviour
{


    // Start is called before the first frame update
    public float speed;
    float angle = 1.0f;
    public float boost;
    public Text boostText;
    public Slider oilgage;
    public float Maxoil;
    public static float oilmeter;
    float time = 0.0f;
    bool burstitemchecker = false;
    float bursttime=0.0f;

    void Start(){
        oilmeter = Maxoil;
    }

    // Update is called once per frame
    void Update(){

        time += Time.deltaTime;
        oilgage.maxValue = Maxoil;
        oilgage.value = oilmeter;
        oilmeter -= 0.01f;

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
            oilmeter -= 0.5f; ;
        }
        if (oilmeter <=0.0f) {
            SceneManager.LoadScene("GameOver");
        }
        if (burstitemchecker) {
            transform.Translate(Vector3.right * Time.deltaTime * -boost);
            if (bursttime >= 2.0f) {
                burstitemchecker = false;
            }
            bursttime += Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision collision) {

        SceneManager.LoadScene("GameOver");        
        
    }
    private void OnTrggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fillitem") {
            oilmeter += 50;
        }
    }
    public void filloil(int fillpoint) {

        oilmeter += fillpoint;

    }
    public void burst() {
        burstitemchecker = true;
    }
}
