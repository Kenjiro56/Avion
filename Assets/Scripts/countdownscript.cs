﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownscript : MonoBehaviour
{
    public Text countdown;
    
    // Start is called before the first frame update
    void Start()
    {
        countdown.text = "";
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CountDown() {
        countdown.text = "3";
        yield return new WaitForSeconds(1.0f);

        countdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        countdown.text = "1";
        yield return new WaitForSeconds(1.0f);

        countdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        countdown.text = "";
        if (stageselectscript.Stage == 1) {
            TimeChecker1.isRacing = true;
        } else if (stageselectscript.Stage == 2) {
            TimeChecker2.isRacing = true;
        }
    }
}
