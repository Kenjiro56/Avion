using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerforpvp1 : MonoBehaviour
{


    // Start is called before the first frame update
    public float speed;
    float angle = 1.0f;
    public float boost;
    public Text boostText;
    public Slider oilgage;
    public float Maxoil;
    public int AirID;
    public static float oilmeter;
    float time = 0.0f;
    bool burstitemchecker = false;
    float bursttime=0.0f;
    int lapcount = 1;
    public Text lap;
    //public AudioClip burst_se;
    //AudioSource audioSource;
    bool gameovercheck =false;
    float explosion_time=0.0f;
    public Text warning;
    public RawImage dangerimage;
   

    //public Collider aircollider;
    void Start(){
        oilmeter = Maxoil;
        //audioSource = GetComponent<AudioSource>();
        warning.enabled = false;
        dangerimage.enabled = false;
    }

    // Update is called once per frame
    void Update(){

        time += Time.deltaTime;
        oilgage.maxValue = Maxoil;
        oilgage.value = oilmeter;
        oilmeter -= 0.01f;

        boostText.enabled = false;
        if (TimeCheckerforpvp.isRacing)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * -speed);
        }

        if (Input.GetButton("Vertical_P" + AirID)) {
            transform.Rotate(Vector3.forward, -angle);
        }

                
        if (Input.GetButton("Horizontal_P" + AirID))
        {
            transform.Rotate(Vector3.up, angle);            
        }

        if (Input.GetButton("boost_P" + AirID)) {
            boostText.enabled = true;
            transform.Translate(Vector3.right* Time.deltaTime*-boost);
            oilmeter -= 0.5f; ;
            //audioSource.PlayOneShot(burst_se);
        }
        if (oilmeter <=0.0f) {
            SceneManager.LoadScene("PvPresult");
        }
        if (burstitemchecker) {
            transform.Translate(Vector3.right * Time.deltaTime * -boost);
            if (bursttime >= 2.0f) {
                burstitemchecker = false;
            }
            bursttime += Time.deltaTime;
        }
        if (gameovercheck)
        {
            explosion_time += Time.deltaTime;
            
                    warning.enabled = true;
                    dangerimage.enabled = true;
            if (explosion_time >= 1.5f)
            {
                warning.enabled = false;
                dangerimage.enabled = false;
            }
            if (explosion_time >= 2.0f) {

                SceneManager.LoadScene("PvPresult");

            }
        }
        lap.text = "LapCount：" + lapcount.ToString();
    }
    void OnCollisionEnter(Collision collision) {
        gameovercheck = true;
    }
    private void OnTrggerEnter(Collider other){
        if (other.gameObject.tag == "fillitem"){
            oilmeter += 50;
        }
        else if (other.gameObject.tag == "checker")
        {
            lapcount++;
        }

    }
    public void filloil(int fillpoint) {

        oilmeter += fillpoint;

    }
    public void burst() {
        burstitemchecker = true;
    }
}
