using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyrotatescript : MonoBehaviour
{
    float rot_air = 2.0f;
    float max_rotate = 90f;
    float rot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rot < max_rotate)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.right, rot_air);
                rot += rot_air;
            }
        }
        if (rot > -max_rotate) {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.right, -rot_air);
                rot -= rot_air;
            }
        }
    

    }
}
