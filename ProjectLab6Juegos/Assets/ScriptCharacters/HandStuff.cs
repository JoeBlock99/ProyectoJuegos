using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandStuff : MonoBehaviour
{
    public float range = 100f;
    private bool OnHand = false;
    private bool mochila = false;
    private int items = 0;
    private int capacity = 1;
    public Camera fpsCam;
    public GameObject storageFull;
    public GameObject pickTxt;
    public GameObject knife;
    public GameObject hammer;
    public GameObject lintern;
    public GameObject fileA;
    public GameObject fileB;
    public GameObject fileC;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
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
                }
            }
            else
            {
                pickTxt.SetActive(false);
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
}
