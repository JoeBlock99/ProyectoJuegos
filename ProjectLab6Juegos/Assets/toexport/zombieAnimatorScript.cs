using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAnimatorScript : MonoBehaviour
{
    public bool isZombieIddle = true;
    Animator myAnimator;


    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if (isZombieIddle == true)
            {
                isZombieIddle = false;
                myAnimator.SetBool("isIdle", false);
            }
            else
            {
                isZombieIddle = true;
                myAnimator.SetBool("isIdle", true);
            }
            
        }
    }
}
