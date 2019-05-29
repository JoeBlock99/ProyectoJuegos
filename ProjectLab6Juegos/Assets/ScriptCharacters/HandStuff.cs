using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandStuff : MonoBehaviour
{
    public float range = 1f;
    private bool OnHand = false;
    private bool mochila = false;
    private bool haveACard = false;
    private int items = 0;
    private int capacity = 1;
    public Camera fpsCam;
    public GameObject storageFull;
    public GameObject pickTxt;
    public GameObject getCardtxt;
    public GameObject lockedtxt;
    public GameObject knife;
    public GameObject hammer;
    public GameObject lintern;
    public GameObject fileA;
    public GameObject fileAtxt;
    public GameObject fileB;
    public GameObject fileC;
    public GameObject exitDoor;
    public GameObject StartTxt1;
    public GameObject StartTxt2;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Begining());
    }

    // Update is called once per frame
    void Update()
    {
            
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.tag);
            if (hit.collider.tag == "Objeto")
            {
                pickTxt.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    if( mochila == true)
                    {
                        if (hit.collider.name == "Knife")
                        {
                            Destroy(hit.collider.gameObject);
                            knife.SetActive(true);
                            items++;
                            OnHand = true;
                        }
                        if (hit.collider.name == "Hammer")
                        {
                            Destroy(hit.collider.gameObject);
                            hammer.SetActive(true);
                            items++;
                            OnHand = true;
                        }
                        if (hit.collider.name == "FlashLight")
                        {
                            Destroy(hit.collider.gameObject);
                            lintern.SetActive(true);
                            items++;
                            OnHand = true;
                        }
                        if (hit.collider.name == "Mochila")
                        {
                            Destroy(hit.collider.gameObject);
                            capacity = 6;
                            OnHand = true;
                        }
                    }
                    if (OnHand == false & mochila == false)
                    {

                        if (hit.collider.name == "Knife")
                        {
                            Destroy(hit.collider.gameObject);
                            knife.SetActive(true);
                            items++;
                            OnHand = true;
                        }
                        if (hit.collider.name == "Hammer")
                        {
                            Destroy(hit.collider.gameObject);
                            hammer.SetActive(true);
                            items++;
                            OnHand = true;
                        }
                        if (hit.collider.name == "FlashLight")
                        {
                            Destroy(hit.collider.gameObject);
                            lintern.SetActive(true);
                            items++;
                            OnHand = true;
                        }
                    }
                    else
                    {
                        storageFull.SetActive(true);
                        StartCoroutine(Example());
                    }
                    if (hit.collider.name == "keycard")
                    {
                        Destroy(hit.collider.gameObject);
                        haveACard = true;
                        fileAtxt.SetActive(true);
                        StartCoroutine(ItsCard());
                        items++;

                    }

                }

            }
            else
            {
                pickTxt.SetActive(false);
            }
            
            if (hit.collider.tag == "locked")
            {
                lockedtxt.SetActive(true);
            }
            else
            {
                lockedtxt.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (haveACard == false)
                {
                    if (hit.collider.tag == "Exit")
                    {
                        getCardtxt.SetActive(true);
                        StartCoroutine(PideCard());
                    }
                }
                else
                {
                    exitDoor.GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.transform.Translate(new Vector3(0, 0, 2.7f));
                    StartCoroutine(openExit());
                }
                
            }
        }
    }
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
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
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
