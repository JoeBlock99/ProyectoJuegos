using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishoriented : MonoBehaviour
{
    Camera myCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        myCamera.GetComponent("Post Processing Behaviour");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
