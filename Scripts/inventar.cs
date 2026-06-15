using UnityEngine;
using TMPro;

public class inventar : MonoBehaviour
{
    public static int id = 0;
    public static int stage = 0;
    public static int listiki = 20;

    public TMP_Text nList;
    public GameObject ruchka;
    public GameObject solnce;
    public GameObject kristal;
    public GameObject ribka;
    public GameObject kluch;
    public static GameObject orugie;
    public static GameObject target;
    void Start()
    {
        DontDestroyOnLoad(this);
    }


    void Update()
    {
        nList.text = listiki.ToString();

        switch (id)
        {
            case 0:
                ruchka.SetActive(false);
                solnce.SetActive(false);
                kristal.SetActive(false);
                ribka.SetActive(false);
                kluch.SetActive(false);
                break;
            case 1:
                kristal.SetActive(true);
                break;
            case 2:
                ruchka.SetActive(true);
                break;
            case 3:
                ribka.SetActive(true);
                break;
            case 4:
                solnce.SetActive(true);
                break;
            case 5:
                orugie.SetActive(true);
                target.SetActive(true);
                break;
            case 6:
                kluch.SetActive(true);
                orugie.SetActive(false);
                target.SetActive(false);
                break;
        }
    }
}
