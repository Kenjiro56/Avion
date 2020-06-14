using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resultscriptsforpvp : MonoBehaviour{
    public Text resultime;
    public static float Besttime = 0.0f;
    public static int winner;
    
        // Start is called before the first frame update
    void Start(){
        resultime.text = winner.ToString()+"P Win！";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick() {
        SceneManager.LoadScene("Start");
    }
}
