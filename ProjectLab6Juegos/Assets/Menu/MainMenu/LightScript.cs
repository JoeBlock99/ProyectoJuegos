using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    Light myLight;
    Transform myTransform;

    void Start()
    {
        myLight = GetComponent<Light>();
        myTransform = GetComponent<Transform>();
        myLight.intensity = 3.09f;
        myTransform.position = new Vector3(2.3f, 6.1f, -.078f);
        
    }

    // Update is called once per frame
    void Update()
    {
        myLight.intensity = 1+(0.5f*Mathf.PingPong(Time.time,8));
        //Debug.Log(Time.deltaTime);
        //Debug.Log(Mathf.PingPong(Time.time,1));
    }
}
