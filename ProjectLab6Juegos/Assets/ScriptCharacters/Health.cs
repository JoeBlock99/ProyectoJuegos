using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject image;
    public GameObject failtxt;
    Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("si detecta");
            if (size.x > 0)
            {
                size = image.transform.localScale;
                size.x -= 0.10f;
                StartCoroutine(wait());
            }
            else
            {
                StartCoroutine(death());
            }


        }
        
        
    }
    IEnumerator death()
    {
        failtxt.SetActive(true);
        yield return new WaitForSeconds(3);
        failtxt.SetActive(false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);   
    }
}
