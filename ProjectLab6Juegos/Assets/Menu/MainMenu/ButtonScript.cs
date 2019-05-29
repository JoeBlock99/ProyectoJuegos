using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LoadScene(string sceneToLoad)
    {
        Debug.Log("load scene");
        SceneManager.LoadScene("FirstScene");
        Debug.Log("Loading scene");
    }
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    
}
