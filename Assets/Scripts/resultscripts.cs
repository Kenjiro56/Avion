using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resultscripts : MonoBehaviour{
    public Text resultime;
    
        // Start is called before the first frame update
    void Start(){
        resultime.text = "結果は" + TimeChecker.time.ToString("f2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick() {
        SceneManager.LoadScene("Start");
    }
}
