using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeGenerator : MonoBehaviour
{
    public GameObject pipeObject;
    private float countdown;
    public float timeDuration;
    public bool enableGenerating;

    private void Awake()
    {
        countdown = 1f;
    }

    // Update is called once per frame
    void Update()
    {  
        if (enableGenerating)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                // sinh ra ong 
                Instantiate(pipeObject, new Vector3(6, Random.Range(-2.4f, 3.4f), 0), Quaternion.identity);
                countdown = timeDuration;
            }
        }
        
    }

}
