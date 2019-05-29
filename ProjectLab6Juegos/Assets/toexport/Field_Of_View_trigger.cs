using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_Of_View_trigger : MonoBehaviour
{
    public Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Human")
        {
            Debug.Log("Tocando al personaje");
        }
    }
}
