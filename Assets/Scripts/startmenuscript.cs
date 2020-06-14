using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class startmenuscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToTimeattack() {
        SceneManager.LoadScene("stageselectTA");
    }
    public void ToPvP() {
        SceneManager.LoadScene("PvP_S1");
    }
}

