using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeChecker2 : MonoBehaviour
{
    public Text timelabel;
    public Text Lapcount;
    public static float time = 0.0f;
    int flag = 0;
    int lapcount = 1;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
            time += Time.deltaTime;
            timelabel.text = "Time:" + time.ToString("f2");
            Lapcount.text = "LapCount:" + lapcount.ToString();
        
        }

    private void OnTriggerEnter(Collider other){
        switch(flag){
            case 0:
                flag++;
                break;
            case 1:
                flag++;
                lapcount++;
                break;
            case 2:
                SceneManager.LoadScene("result2");
                break;                

        }
    }

}
