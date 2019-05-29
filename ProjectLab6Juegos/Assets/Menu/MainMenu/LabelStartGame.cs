using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelStartGame : MonoBehaviour
{
    Text myText;

    // Start is called before the first frame update
    void Start()
    {

        myText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseExit()
    {
        myText.color = Color.white;
    }
    private void OnMouseEnter()
    {
        myText.color = Color.blue;
    }
}
