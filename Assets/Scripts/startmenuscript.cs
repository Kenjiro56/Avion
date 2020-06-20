using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class startmenuscript : MonoBehaviour
{
    public GameObject system1;
    public GameObject system2;
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
        SceneManager.LoadScene("stageselectPvP");
    }
    public void tosystem1() {
        system1.SetActive(true);
        system2.SetActive(false);
    }
    public void tosystem2()
    {
        system1.SetActive(false);
        system2.SetActive(true);
    }
    public void close() {
        system1.SetActive(false);
        system2.SetActive(false);
    }
}

