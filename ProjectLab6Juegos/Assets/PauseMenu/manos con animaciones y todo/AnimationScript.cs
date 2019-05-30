using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public bool HasHammer = false;
    public bool IsUnarmed = false;
    public bool HasGun = false;
    public bool HasKnife = false;
    public bool IsHitting = false;
    Animator myAnimator;

    
    void Start()
    {
        myAnimator = GetComponent<Animator>();    
    }

    
    void Update()
    {
       //metodo para tomar y dejar hammer
        if (Input.GetKeyDown(KeyCode.H)){
            if (HasHammer == true)
            {
                
                IsUnarmed = true;
                HasHammer = false;
                myAnimator.SetBool("IsUnarmed", true);
                myAnimator.SetBool("HasHammer", false);
                

            }
            else
            {
                IsUnarmed = false;
                HasHammer = true;
                HasKnife = false;
                myAnimator.SetBool("IsUnarmed", false);
                myAnimator.SetBool("HasKnife", false);
                myAnimator.SetBool("HasHammer", true);
                


            }
                           }
        //metodo para tomar y dejar knife
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (HasKnife == true)
            {

                HasKnife = false;
                IsUnarmed = true;
                myAnimator.SetBool("IsUnarmed", true);
                myAnimator.SetBool("HasKnife", false);
                

            }
            else
            {
                IsUnarmed = false;
                HasKnife = true;
                HasHammer = false;
                myAnimator.SetBool("IsUnarmed", false);
                myAnimator.SetBool("HasHammer", false);
                myAnimator.SetBool("HasKnife", true);
                

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            IsHitting = true;
            myAnimator.SetBool("IsHitting", true);
            StartCoroutine(DelayAnimation());
            
        }


    }
    
    

    IEnumerator DelayAnimation()
    {
        yield return new WaitForSeconds(1);
        myAnimator.SetBool("IsHitting", false);
        Debug.Log("Successfully waited");
    }

    IEnumerator DelayLeavingKnife()
    {
        yield return new WaitForSeconds(1);
        myAnimator.SetBool("IsHitting", false);
        
    }

}
