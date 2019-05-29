using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public bool isBackpackTaken = false;
    public bool isWeaponTaken = false;
    public bool isLocketTaken = false;
    public bool isIDTaken = false;
    public bool isKeyTaken = false;
    public bool isWatchTaken = false;
    public bool isFlashlightTaken = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void displayItems()
    {
        if (isWeaponTaken == true)
        {
            transform.Find("Weapon").gameObject.SetActive(true);
        }
        if (isIDTaken == true)
        {
            transform.Find("ID").gameObject.SetActive(true);
        }
        if (isLocketTaken == true)
        {
            transform.Find("Locket").gameObject.SetActive(true);
        }
        if (isWatchTaken == true)
        {
            transform.Find("Watch").gameObject.SetActive(true);
        }
        if (isFlashlightTaken == true)
        {
            transform.Find("Flashlight").gameObject.SetActive(true);
        }
        if (isKeyTaken == true) {
            transform.Find("Key").gameObject.SetActive(true);
        }
    }
}
