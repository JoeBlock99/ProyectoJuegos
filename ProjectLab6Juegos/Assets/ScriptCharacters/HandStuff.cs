//Implemented by Jose Gabriel Block Staackmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandStuff : MonoBehaviour
{
    public float range;
    private bool OnHand = false;
    private bool mochila = false;
    private bool hasknife = false;
    private bool hashammer = false;
    private bool haslintern = false;
    private bool haspistol = false;
    private bool hasrifle = false;
    private bool haveACard = false;
    private int items = 0;
    private int capacity = 1;
    public Camera fpsCam;
    public GameObject storageFull;
    public GameObject pickTxt;
    public GameObject getCardtxt;
    public GameObject lockedtxt;
    public GameObject handknife;
    public GameObject handhammer;
    public GameObject handlintern;
    public GameObject knife;
    public GameObject hammer;
    public GameObject lintern;
    public GameObject fileAtxt;
    public GameObject fileB;
    public GameObject fileC;
    public GameObject exitDoor;
    public GameObject StartTxt1;
    public GameObject StartTxt2;
    public GameObject wintxt;
    public Transform drop;
    private float damage = 2;
    private float rango = 5;
    RaycastHit hit;
    Animator theAnimator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Begining());
        theAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //To know what weapon is he using...
        if (theAnimator.GetBool("hasknife") == true)
        {
            damage = 3;
            if (Input.GetMouseButtonDown(0))
            {
                theAnimator.SetBool("isA", true);
            }
        }
        if (theAnimator.GetBool("hashammer") == true)
        {
            damage = 4;
            rango = 7;
            if (Input.GetMouseButtonDown(0))
            {
                theAnimator.SetBool("isA", true);
            }
        }
        //----------------------------------------------------------------------------------------------------------*
        //----------------------------------------------------------------------------------------------------------*
        // To show up UI and scan things..
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.tag);
            Debug.Log(hit.transform.name);
            if (hit.collider.tag == "Objeto")
            {
                pickTxt.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    if (mochila == true)
                    {
                        if (hit.collider.name == "Knife(Clone)" || hit.collider.name == "Knife")
                        {
                            Destroy(knife);
                            handknife.SetActive(true);
                            hasknife = true;
                            theAnimator.SetBool("hasknife", true);
                            items++;
                            
                        }
                        if (hit.collider.name == "Hammer(Clone)" || hit.collider.name == "Hammer")
                        {
                            Destroy(hit.collider.gameObject);
                            handhammer.SetActive(true);
                            hashammer = true;
                            theAnimator.SetBool("hashammer", true);
                            items++;
                            
                        }
                        if (hit.collider.name == "FlashLight(Clone)" || hit.collider.name == "FlashLight")
                        {
                            Destroy(hit.collider.gameObject);
                            handlintern.SetActive(true);
                            haslintern = true;
                            items++;
                            
                        }

                    }
                    if (OnHand == false & mochila == false)
                    {

                        if (hit.collider.name == "Knife(Clone)" || hit.collider.name == "Knife")
                        {
                            Debug.Log("Si entra");
                            Destroy(hit.collider.gameObject);
                            theAnimator.SetBool("hasknife", true);
                            hasknife = true;
                            items++;
                            OnHand = true;
                        }
                        if (hit.collider.name == "Hammer(Clone)" || hit.collider.name == "Hammer")
                        {
                            Destroy(hit.collider.gameObject);
                            hashammer = true;
                            theAnimator.SetBool("hashammer", true);
                            items++;
                            OnHand = true;
                        }
                        if (hit.collider.name == "FlashLight(Clone)" || hit.collider.name == "FlashLight")
                        {
                            Destroy(hit.collider.gameObject);
                            handlintern.SetActive(true);
                            items++;
                            OnHand = true;
                        }
                    }
                    else
                    {
                        storageFull.SetActive(true);
                        StartCoroutine(Example());
                    }
                    // finds key card:
                    if (hit.collider.name == "keycard")
                    {
                        Destroy(hit.collider.gameObject);
                        haveACard = true;
                        fileAtxt.SetActive(true);
                        StartCoroutine(ItsCard());
                        items++;

                    }
                    // finds mochila:
                    if (hit.collider.name == "Mochila")
                    {
                        Destroy(hit.collider.gameObject);
                        capacity = 6;
                    }
                }
            }
            else
            {
                pickTxt.SetActive(false);
            }
            //if door is locked:
            if (hit.collider.tag == "locked")
            {
                lockedtxt.SetActive(true);
            }
            else
            {
                lockedtxt.SetActive(false);
            }
            //Shoot:
            if (Input.GetMouseButtonDown(0))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
            //Way out:
            if (Input.GetMouseButtonDown(0))
            {
                if (haveACard == false)
                {
                    if (hit.collider.tag == "Exit" || hit.collider.name == "model" || hit.collider.name == "Panel_low")
                    {
                        getCardtxt.SetActive(true);
                        StartCoroutine(PideCard());
                    }
                }
                else
                {
                    if (hit.collider.tag == "Exit" || hit.collider.name == "model" || hit.collider.name == "Panel_low")
                    {
                        exitDoor.GetComponent<AudioSource>().Play();
                        exitDoor.transform.Translate(new Vector3(0, 0, 2.7f));
                        StartCoroutine(openExit());
                    }
                }
            }         
            //Throw things:
            if (Input.GetMouseButtonDown(1))
            {
                if (hasknife == true)
                {
                    theAnimator.SetBool("hasknife", false);
                    Instantiate(knife, drop.position, drop.rotation);
                }
                if (hashammer == true)
                {
                    theAnimator.SetBool("hashammer", false);
                    Instantiate(hammer, drop.position, drop.rotation);
                }
            }
        }
    }
    //Coroutines:
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        print(Time.time);
        storageFull.SetActive(false);
    }
    IEnumerator PideCard()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        print(Time.time);
        getCardtxt.SetActive(false);
    }
    IEnumerator ItsCard()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        print(Time.time);
        fileAtxt.SetActive(false);
    }
    IEnumerator openExit()
    {
        wintxt.SetActive(true);
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
        wintxt.SetActive(false);
        SceneManager.LoadScene("SecondPart");
    }
    IEnumerator Begining()
    {
        StartTxt1.SetActive(true);
        print(Time.time);
        yield return new WaitForSeconds(8);
        print(Time.time);
        StartTxt1.SetActive(false);
        StartTxt2.SetActive(true);
        print(Time.time);
        yield return new WaitForSeconds(8);
        print(Time.time);
        StartTxt2.SetActive(false);
    }
}