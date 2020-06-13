using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resultscripts1 : MonoBehaviour{
    public Text resultime;
    public static float Besttime = 0.0f; 
    
        // Start is called before the first frame update
    void Start(){
        resultime.text = "結果は" + TimeChecker1.time.ToString("f2");
        if (Besttime <= TimeChecker1.time) {
            Besttime = TimeChecker1.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick() {
        SceneManager.LoadScene("Start");
    }
}
