using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelMainMenu : MonoBehaviour
{

    Text myText;
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time*0.5f, 1));
    }}
