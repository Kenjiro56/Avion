using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class aircraftcontroller : MonoBehaviour
{


    // Start is called before the first frame update
    public float speed;
    public float boost;
    public Text boostText;
    public Slider oilgage;          //oilgauge
    public float Maxoil;            //max of oil
    public Text warning;            //uncontrolabe
    public RawImage dangerimage;    //dangerimage
    public static float oilmeter;   //current_oli
    public AudioClip burst_se;      //加速時のSE
    public GameObject soundmanager;
    float time = 0.0f;              //time
    float angle = 1.0f;             //機体の曲がる角度
    bool burstitemchecker = false;  //burstitemに触れたかチェック
    float bursttime=0.0f;           //burstしている間の時間カウント
    AudioSource audioSource;        
    bool gameovercheck =false;      //接触チェック
    float explosion_time=0.0f;      //接触してからの時間カウント
    public GameObject wind;
    

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
        wind.SetActive(false);

        if ((stageselectscript.Stage ==1&&TimeChecker1.isRacing) ||(stageselectscript.Stage == 2 &&TimeChecker2.isRacing))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * -speed);
            soundmanager.SetActive(true);
        }
       


        //基本的な操作
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



        //boost時の処理
        if (Input.GetKey(KeyCode.Space)) {
            boostText.enabled = true;
            transform.Translate(Vector3.right* Time.deltaTime*-boost);
            oilmeter -= 0.5f;
            wind.SetActive(true);
            // audioSource.PlayOneShot(burst_se);
        }

        //oilmeterが0になったときの処理
        if (oilmeter <=0.0f) {
            SceneManager.LoadScene("GameOver");
        }

        //burstitmを取ったときの挙動
        if (burstitemchecker) {
            transform.Translate(Vector3.right * Time.deltaTime * -boost);
            if (bursttime >= 2.0f) {
                burstitemchecker = false;
            }
            bursttime += Time.deltaTime;
        }

        //接触後の処理
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

    
    }
    //接触時の処理
    void OnCollisionEnter(Collision collision) {
        gameovercheck = true;
    }

    
    /*private void OnTrggerEnter(Collider other){
        if (other.gameObject.tag == "fillitem"){
            oilmeter += 50;
        }
        
    }*/

    //fillitemを取ったときに呼び出される関数
    public void filloil(int fillpoint) {

        oilmeter += fillpoint;

    }

    //burstitem撮ったときに呼び出される関数
    public void burst() {
        burstitemchecker = true;
    }
}
