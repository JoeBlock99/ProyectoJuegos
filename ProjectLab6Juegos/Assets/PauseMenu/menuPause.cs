using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPause : MonoBehaviour
{
    bool isPaused = false;
    bool isInventoryActive = false;
    bool isBackpackTaken = false;
    public GameObject controlpanel;
    public GameObject pausepanel;
    public GameObject inventorypanel;
    public Canvas cnvs;


    void Start()
    {
      
    }


    void Update()
    {
        //toggles inventory
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                resume();

            }
            else
            {

                pause();
                isPaused = true;
            }
        }
        //toggles backpack
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isBackpackTaken == true)
            {
                isBackpackTaken = false;
                Debug.Log("is backpck taken = false");
            }
            else
            {
                isBackpackTaken = true;
                Debug.Log("is backpck taken = true");
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isInventoryActive == true)
            {
                isInventoryActive = false;
                Debug.Log("is inventoryactive = false");
            }
            else
            {
                isInventoryActive = true;
                Debug.Log("is isinventory = true");
            }

        }
    }

    public void pause()
    {
        cnvs.enabled = false;
        pausepanel.SetActive(true);
        Time.timeScale = 0;

        if (isBackpackTaken == true)
        {
            //transform.Find("inventoryButton").gameObject.SetActive(true);

        }

    }

    public void resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("resume");
        cnvs.enabled = true;
        isPaused = false;
    }

    public void showInventory()
    {
        Debug.Log("show inventory");
        pausepanel.SetActive(false);
        inventorypanel.SetActive(true);
    }

    public void showController()
    {
        Debug.Log("show controller");
        pausepanel.SetActive(false);
        controlpanel.SetActive(true);

    }

    public void Quit()
    {
        Debug.Log("Quit");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void backFromController()
    {
        cnvs.enabled = false;
        pausepanel.SetActive(true);
        controlpanel.SetActive(false);
        inventorypanel.SetActive(false);
        Debug.Log("Back from controller");
    }
}
