using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class krokodil : MonoBehaviour
{
    public static bool grey = false;
    public static bool yellow = false;
    public static bool red = false;
    public static bool white = false;
    public static bool orange = false;
    public static bool blue = false;
    public static bool black = false;
    public static bool brown = false;
    public static bool wood = false;
    public static bool purple = false;
    public static bool pink = false;
    Animator animator;

    public GameObject sun;

    int a = -1;
    int b = -1;
    int c = -1;
    int d = -1;
    int e = -1;
    int f = -1;
    int g = -1;
    int h = -1;
    int i = -1;
    int j = -1;
    int k = -1;

    int check = 0;
    int stage = 1;



    public TMP_Text raund;
    public TMP_Text cvet;
    public TMP_Text finCvet;

    public GameObject interfKrokodil;

    public GameObject skrimer;

    bool win = false;

    [SerializeField] private GameObject[] _objects;
    private int _indexObject;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (win == false) sun.SetActive(false);
        else sun.SetActive(true);
    }


    void NeScrimer()
    {
        skrimer.SetActive(false);
    }

    void Animstop()
    {
        animator.SetBool("stop", true);
    }

    void Anim()
    {
        animator.SetBool("stop", false);
    }

    void ColorReset()
    {
        grey = false;
        yellow = false;
        red = false;
        white = false;
        blue = false;
        orange = false;
        black = false;
        wood = false;
        purple = false;
        brown = false;
        pink = false;
    }

    void Loss()
    {
        skrimer.SetActive(true);
        Invoke("NeScrimer", 0.15f);
        ShowNewObject();
        check = 0;
        stage = 1;
        if (GameManager.levelLose != 5) GameManager.levelLose++;
    }
    void Grey()
    {
        if (grey == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void Yellow()
    {
        if (yellow == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }

    void Red()
    {
        if (red == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void White()
    {
        if (white == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void Blue()
    {
        if (blue == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void Orange()
    {
        if (orange == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void Black()
    {
        if (black == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void Wood()
    {
        if (wood == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void Purple()
    {
        if (purple == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void Brown()
    {
        if (brown == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }
    void Pink()
    {
        if (pink == false)
        {
            Loss();
        }
        else stage += 1;
        ColorReset();
    }

    void FinColor()
    {
        finCvet.text = "";
        if (inventar.id == 3)
        {
            raund.text = "";
            stage += 1;
            inventar.id = 0;
        }
        else
        {
            Loss();
            if (GameManager.krokodil1 == true)
            {
                GameManager.krokodil1 = false;
                GameManager.krokodil = true;
            }
        }
        ColorReset();
    }
    void Color(int n)
    {
        switch (n)
        {
            case 0:
                cvet.text = "серый";
                cvet.color = new Color32(255, 20, 0, 255);
                Invoke("Grey", 10f);
                break;
            case 1:
                cvet.text = "жёлтый";
                cvet.color = new Color32(77, 77, 77, 255);
                Invoke("Yellow", 10f);
                break;
            case 2:
                cvet.text = "красный";
                cvet.color = new Color32(17, 0, 255, 255);
                Invoke("Red", 10f);
                break;
            case 3:
                cvet.text = "белый";
                cvet.color = new Color32(255, 0, 167, 255);
                Invoke("White", 10f);
                break;
            case 4:
                cvet.text = "синий";
                cvet.color = new Color32(255, 112, 0, 255);
                Invoke("Blue", 10f);
                break;
            case 5:
                cvet.text = "оранжевый";
                cvet.color = new Color32(0, 0, 0, 255);
                Invoke("Orange", 10f);
                break;
            case 6:
                cvet.text = "чёрный";
                cvet.color = new Color32(255, 255, 255, 255);
                Invoke("Black", 10f);
                break;
            case 7:
                cvet.text = "деревянный";
                cvet.color = new Color32(160, 0, 255, 255);
                Invoke("Wood", 10f);
                break;
            case 8:
                cvet.text = "фиолетовый";
                cvet.color = new Color32(255, 125, 0, 255);
                Invoke("Purple", 10f);
                break;
            case 9:
                cvet.text = "коричневый";
                cvet.color = new Color32(255, 0, 172, 255);
                Invoke("Brown", 10f);
                break;
            case 10:
                cvet.text = "розовый";
                cvet.color = new Color32(102, 255, 0, 255);
                Invoke("Pink", 10f);
                break;

        }
    }
    void Update()
    {

        if (Time.timeScale == 0)
        {
            interfKrokodil.SetActive(false);
        }
        else
        {
            interfKrokodil.SetActive(true);
        }

        if (stage < 13) raund.text = stage.ToString();

        switch (stage)
        {
            case 1:
                if (check < 1)
                {
                    a = -1;
                    b = -1;
                    c = -1;
                    d = -1;
                    e = -1;
                    f = -1;
                    g = -1;
                    h = -1;
                    i = -1;
                    j = -1;
                    k = -1;
                    a = Random.Range(0, 11);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(a);
                    check += 1;
                }
                break;
            case 2:
                if (check < 2)
                {
                    do
                    {
                        b = Random.Range(0, 11);
                    } while (b == a);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(b);
                    check += 1;
                }
                break;
            case 3:
                if (check < 3)
                {
                    do
                    {
                        c = Random.Range(0, 11);
                    } while (c == a || c == b);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(c);
                    check += 1;
                }
                break;
            case 4:
                if (check < 4)
                {
                    do
                    {
                        d = Random.Range(0, 11);
                    } while (d == a || d == b || d == c);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(d);
                    check += 1;
                }
                break;
            case 5:
                if (check < 5)
                {
                    do
                    {
                        e = Random.Range(0, 11);
                    } while (e == a || e == b || e == c || e == d);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(e);
                    check += 1;
                }
                break;
            case 6:
                if (check < 6)
                {
                    do
                    {
                        f = Random.Range(0, 11);
                    } while (f == a || f == b || f == c || f == d || f == e);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(f);
                    check += 1;
                }
                break;
            case 7:
                if (check < 7)
                {
                    do
                    {
                        g = Random.Range(0, 11);
                    } while (g == a || g == b || g == c || g == d || g == e || g == f);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(g);
                    check += 1;
                }
                break;
            case 8:
                if (check < 8)
                {
                    do
                    {
                        h = Random.Range(0, 11);
                    } while (h == a || h == b || h == c || h == d || h == e || h == f || h == g);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(h);
                    check += 1;
                }
                break;
            case 9:
                if (check < 9)
                {
                    do
                    {
                        i = Random.Range(0, 11);
                    } while (i == a || i == b || i == c || i == d || i == e || i == f || i == g || i == h);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(i);
                    check += 1;
                }
                break;
            case 10:
                if (check < 10)
                {
                    do
                    {
                        j = Random.Range(0, 11);
                    } while (j == a || j == b || j == c || j == d || j == e || j == f || j == g || j == h || j == i);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(j);
                    check += 1;
                }
                break;
            case 11:
                if (check < 11)
                {
                    do
                    {
                        k = Random.Range(0, 11);
                    } while (k == a || k == b || k == c || k == d || k == e || k == f || k == g || k == h || k == i || k == j);
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Color(k);
                    check += 1;
                }
                break;
            case 12:
                if (check < 12)
                {
                    cvet.text = "";
                    finCvet.text = "цвет золотой рыбки в мыльном пузыре";
                    Invoke("Animstop", 8f);
                    Invoke("Anim", 10f);
                    Invoke("FinColor", 10f);
                    check += 1;
                }
                break;
            case 13:
                if (check < 13)
                {
                    win = true;
                    sun.SetActive(true);
                    check += 1;
                }
                break;
        }
    }

    private void ShowNewObject()
    {
        if (_indexObject < _objects.Length - 1)
        {
            _objects[_indexObject].SetActive(false);
            _indexObject++;
            _objects[_indexObject].SetActive(true);
            _indexObject++;
        }
    }
}
