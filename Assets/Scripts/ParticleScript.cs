using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public GameObject smoke;
    public GameObject explosion;
    public GameObject body;
    bool gameover = false;
    float smoke_time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover) {
            smoke_time += Time.deltaTime;
            if (smoke_time >=1.5f) {
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                Destroy(body);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameover = true;
        Instantiate(smoke,this.transform.position,Quaternion.identity);
        
    }
}
