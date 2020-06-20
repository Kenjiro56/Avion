using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stageselectscriptforpvp : MonoBehaviour
{
    //public static int Stage;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tos1() {
        //Stage = 1;
        SceneManager.LoadScene("PvP_S1");
    }
    
    public void back() {
        SceneManager.LoadScene("Start");
    }
}
