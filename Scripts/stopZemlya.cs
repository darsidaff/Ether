using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class stopZemlya : MonoBehaviour
{
    public GameObject ground;

    public TMP_Text signal;
    public GameObject sig;

    public GameObject strelka1;
    public GameObject strelka2;

    void Start()
    {
        move.characterController.enabled = false;
        ground.SetActive(false);
        InvokeRepeating("Zemlya", 5f, 7f);
        InvokeRepeating("Tri", 3.8f, 14f);
        InvokeRepeating("Dva", 4.2f, 14f);
        InvokeRepeating("Odin", 4.6f, 14f);
    }



    void Zemlya()
    {
        ground.SetActive(!ground.activeSelf);

        if (signal.text == "стоп-земля")
        {
            signal.text = "";
        }
        else signal.text = "стоп-земля";
    }

    void Tri()
    {

        signal.text = "3";
    }

    void Dva()
    {
        signal.text = "2";
    }

    void Odin()
    {
        signal.text = "1";
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            sig.SetActive(false);
        }
        else
        {
            sig.SetActive(true);
        }

        if (dialogSystem.index == 90) strelka1.SetActive(true);
        if (dialogSystem.index == 93) strelka2.SetActive(true);
        if (dialogSystem.index == 94) move.characterController.enabled = true;
    }

}
