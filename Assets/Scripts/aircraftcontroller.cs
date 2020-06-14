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
    public AudioClip burst_se;
    AudioSource audioSource;
    bool gameovercheck =false;
    float explosion_time=0.0f;
    public Text warning;
    public RawImage dangerimage;
    public int hp = 2;

    public Collider aircollider;
    void Start(){
        oilmeter = Maxoil;
        audioSource = GetComponent<AudioSource>();
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
        if ((stageselectscript.Stage ==1&&TimeChecker1.isRacing) ||(stageselectscript.Stage == 2 &&TimeChecker2.isRacing))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * -speed);
        }
       
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
            audioSource.PlayOneShot(burst_se);
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

                SceneManager.LoadScene("GameOver");

            }
        }
        Debug.Log(hp);
    }
    void OnCollisionEnter(Collision collision) {
        gameovercheck = true;
    }
    private void OnTrggerEnter(Collider other){
        if (other.gameObject.tag == "fillitem"){
            oilmeter += 50;
        }
        if(other.gameObject.tag == "stage"){
            hp--;
            if (hp == 1){
                aircollider.isTrigger = false;
            }
        }
    }
    public void filloil(int fillpoint) {

        oilmeter += fillpoint;

    }
    public void burst() {
        burstitemchecker = true;
    }
}
