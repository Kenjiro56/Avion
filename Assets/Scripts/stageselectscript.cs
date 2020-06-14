using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stageselectscript : MonoBehaviour
{
    public Text best_s1;
    public Text best_s2;
    public static int Stage;
    // Start is called before the first frame update
    void Start()
    {
        best_s1.text = "BestTime：" + resultscripts1.Besttime.ToString("f2");
        best_s2.text = "BestTime：" + resultscripts2.Besttime.ToString("f2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tos1() {
        Stage = 1;
        SceneManager.LoadScene("TimeAttack_S1");
    }
    public void tos2()
    {
        Stage = 2;
        SceneManager.LoadScene("TimeAttack_S2");
    }
}
