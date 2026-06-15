using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Пауза")]
    public GameObject pause;

    [Header("Меню паузы")]
    public GameObject menuPause;
    public static bool isMenu;

    [Header("Главное меню")]
    public GameObject menu;

    [Header("Картинка курсора")]
    public Texture2D cursorImage;

    [Header("Интерфейс")]
    public GameObject interf;

    [Header("Интерфейс")]
    public GameObject basicInterf;

    [Header("Диалог")]
    public GameObject dialog;

    public TMP_Text dialogText;
    public TMP_Text ktoGovorit;
    public static int dialogStage;


    public static int nPodsk;

    public GameObject playerKvartira;
    public GameObject cameraKvartira;

    public static GameObject player;

    public GameObject stul;
    public GameObject stul1;
    public GameObject stol;

    public GameObject ekran;

    public GameObject temnota;
    public GameObject loading;

    public AudioSource menuMusic;

    bool nachalo = true;
    bool tir = true;
    bool pesochnica = true;
    public static bool vederki = false;
    public static bool vederki1 = true;
    bool poslepesochnici = true;
    public static bool krokodil = false;
    public static bool krokodil1 = true;
    bool stopz = true;
    public static bool ruchka = false;
    public static bool ruchka1 = true;
    public static bool minusruchka = false;
    public static bool minusruchka1 = true;
    bool poslestopz = true;
    bool knb = true;
    bool posleknb = true;
    bool posletira = true;
    public static bool good = false;
    public static bool good1 = true;
    public static bool bad = false;
    public static bool bad1 = true;
    bool end = true;

    bool vse = false;


    public static GameObject inerfKNB;
    public static GameObject healthInterf;

    int nScene;

    public static bool badEnd = false;

    public static bool lastDoor = false;

    public static int levelLose = 0;
    public GameObject lose1;
    public GameObject lose2;
    public GameObject lose3;
    public GameObject lose4;
    public GameObject lose5;


    void Start()
    {
        isMenu = true;
        menuMusic.mute = false;
        move.canMove = false;
        Time.timeScale = 0;
        interf.SetActive(false);
        menu.SetActive(true);
        DontDestroyOnLoad(this);
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);

        dialogSystem.dialogText = dialogText;
        dialogSystem.index = 0;
        dialogStage = 3;

    }

    public void StartPlay()
    {
        isMenu = false;
        menuMusic.mute = true;
        move.canMove = true;
        interf.SetActive(true);
        pause.SetActive(true);
        if (inventar.stage == 7) healthInterf.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1;

        dialog.SetActive(true);
    }
    public void Pause()
    {
        move.canMove = false;
        menuPause.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 0;
        if (inventar.stage == 7) healthInterf.SetActive(false);
    }

    public void Continue()
    {
        move.canMove = true;
        menuPause.SetActive(false);
        pause.SetActive(true);
        if (inventar.stage == 7) healthInterf.SetActive(true);
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        isMenu = true;
        menuMusic.mute = false;
        menuPause.SetActive(false);
        move.canMove = false;
        interf.SetActive(false);
        if (inventar.stage == 7) healthInterf.SetActive(false);
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.T))
        {
            Pause();
        }

        if (podskazka.distAct == true && Input.GetKey(KeyCode.F) && nPodsk == 1 && dialogSystem.dialogText.text == "")
        {
            dialogSystem.index = 2;
            dialogStage = 4;
            dialog.SetActive(true);
            podskazka.act = false;
            nScene = 8;
            Invoke("StartZatemnenie", 5f);
            Invoke("Perehod", 8f);
            move.characterController.enabled = false;
            playerKvartira.GetComponent<Rigidbody>().isKinematic = true;
            stul.GetComponent<Collider>().enabled = false;
            stol.GetComponent<Collider>().enabled = false;
            stul1.GetComponent<Collider>().enabled = false;
            playerKvartira.transform.position = new Vector3(3.966f, 1.774f, 0.95f);
            cameraKvartira.transform.position = new Vector3(3.966f, 2f, 0.95f);
            ekran.SetActive(true);

        }

        if (podskazka.distAct == true && Input.GetKey(KeyCode.F) && nPodsk == 2)
        {
            podskazka.act = false;
            move.characterController.enabled = false;
            player.transform.position = new Vector3(499.198f, 10.171f, 455.4f);
        }



        if (inventar.listiki >= 100 && nPodsk == 2 && inventar.stage == 2)
        {
            player.transform.position = new Vector3(498.12f, 10.171f, 448.93f);
            move.characterController.enabled = true;
            inerfKNB.SetActive(false);
            inventar.stage = 3;
        }

        if (inventar.stage >= 7)
        {
            basicInterf.SetActive(false);
        }

        if (move.HP <= 0 && vse == false)
        {
            vse = true;
            nScene = 9;
            inventar.stage = 8;
            Invoke("Perehod", 8f);
        }

        if (badEnd == true && vse == false)
        {
            vse = true;
            badEnd = false;
            nScene = 10;
            inventar.stage = 8;
            Invoke("Perehod", 8f);
        }


        if (SceneManager.GetActiveScene().name == "glavnaya" && nachalo == true)
        {
            nachalo = false;
            ktoGovorit.text = "голос";
            dialogSystem.index = 3;
            dialogStage = 40;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "tir" && tir == true && inventar.stage == 0)
        {
            tir = false;
            if (dialogSystem.index != 39 && dialogSystem.index != 59) dialogSystem.index = 40;
            else dialogSystem.index = 39;
            dialogStage = 51;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "pesochnica" && pesochnica == true)
        {
            pesochnica = false;
            if (dialogSystem.index != 39 && dialogSystem.index != 50) dialogSystem.index = 51;
            else dialogSystem.index = 50;
            dialogStage = 60;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "pesochnica" && vederki == true)
        {
            vederki = false;
            if (dialogSystem.index != 59) dialogSystem.index = 60;
            dialogStage = 65;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "glavnaya" && poslepesochnici == true && inventar.stage == 1)
        {
            poslepesochnici = false;
            dialogSystem.index = 64;
            dialogStage = 70;
            dialog.SetActive(true);
        }

        if (krokodil == true)
        {
            krokodil = false;
            dialogSystem.index = 69;
            dialogStage = 78;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "stopZemlya" && stopz == true)
        {
            stopz = false;
            if (dialogSystem.index != 77 && dialogSystem.index != 69) dialogSystem.index = 78;
            else dialogSystem.index = 77;
            dialogStage = 95;
            dialog.SetActive(true);
        }

        if (ruchka == true)
        {
            ruchka = false;
            if (dialogSystem.index != 94) dialogSystem.index = 95;
            dialogStage = 97;
            dialog.SetActive(true);
        }

        if (minusruchka == true)
        {
            minusruchka = false;
            if (dialogSystem.index != 96) dialogSystem.index = 97;
            dialogStage = 98;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "glavnaya" && poslestopz == true && inventar.stage == 2)
        {
            poslestopz = false;
            if (dialogSystem.index != 97) dialogSystem.index = 98;
            dialogStage = 180;
            dialog.SetActive(true);
        }

        if (dialogSystem.index == 179)
        {
            dialogSystem.index = 104;
            dialogStage = 181;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "knb" && knb == true)
        {
            knb = false;
            dialogSystem.index = 180;
            dialogStage = 191;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "glavnaya" && posleknb == true && inventar.stage == 3)
        {
            posleknb = false;
            dialogSystem.index = 190;
            dialogStage = 213;
            dialog.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "glavnaya" && posletira == true && inventar.stage == 5)
        {
            posletira = false;
            dialogSystem.index = 212;
            dialogStage = 220;
            dialog.SetActive(true);
        }

        if (good == true)
        {
            good = false;
            dialogSystem.index = 220;
            dialogStage = 222;
            dialog.SetActive(true);
        }

        if (bad == true)
        {
            bad = false;
            dialogSystem.index = 219;
            dialogStage = 221;
            dialog.SetActive(true);
        }

        if ((SceneManager.GetActiveScene().name == "badEnd" || SceneManager.GetActiveScene().name == "happyEnd") && end == true)
        {
            end = false;
            ktoGovorit.text = "я";
            levelLose = 0;
            if (dialogSystem.index != 221) dialogSystem.index = 222;
            if (SceneManager.GetActiveScene().name == "badEnd")
            {
                dialogStage = 230;
            }
            else
            {
                dialogStage = 228;
                move.canMove = false;
            }

            dialog.SetActive(true);
        }

        switch (levelLose)
        {
            case 0:

                lose1.SetActive(false);
                lose2.SetActive(false);
                lose3.SetActive(false);
                lose4.SetActive(false);
                lose5.SetActive(false);
                break;
            case 1:
                lose1.SetActive(true);
                break;
            case 2:
                lose1.SetActive(false);
                lose2.SetActive(true);
                break;
            case 3:
                lose2.SetActive(false);
                lose3.SetActive(true);
                break;
            case 4:
                lose3.SetActive(false);
                lose4.SetActive(true);
                break;
            case 5:
                lose4.SetActive(false);
                lose5.SetActive(true);
                break;
        }
    }

    void StartZatemnenie()
    {
        dialog.SetActive(false);
        StartCoroutine("Zatemnenie");
    }

    void Perehod()
    {
        if (inventar.stage < 7)
        {
            loading.SetActive(true);
            basicInterf.SetActive(true);
        }
        SceneManager.LoadScene(nScene);

    }

    IEnumerator Zatemnenie()
    {
        Image fade_image = temnota.GetComponent<Image>();
        Color color = fade_image.color;
        while (color.a < 1f)
        {
            color.a += 1f * Time.deltaTime;
            fade_image.color = color;
            yield return null;
        }
    }
}
