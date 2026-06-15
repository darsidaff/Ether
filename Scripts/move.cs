using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class move : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    public static CharacterController characterController;

    public static bool canMove = true;

    public static double maxHealth = 100f;
    public static double HP;


    public Transform pointNull;
    public GameObject ruchka;

    [SerializeField] private GameObject[] _objects;
    private int _indexObject;

    public GameObject key;
    public GameObject video;

    public static int indT;

    public static bool startZemlya = false;

    public GameObject loading;


    public GameObject door0;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;


    public GameObject orugie;
    public GameObject target;

    public GameObject finalBlack;
    public TMP_Text nDoor;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ground":
                if (startZemlya == true)
                {
                    ShowNewObject();
                    characterController.enabled = false;
                    if (inventar.id == 2)
                    {
                        if (GameManager.minusruchka1 == true)
                        {
                            GameManager.minusruchka1 = false;
                            GameManager.minusruchka = true;
                        }
                    }
                    inventar.id = 0;
                    ruchka.SetActive(true);
                    transform.position = pointNull.position;
                    characterController.enabled = true;
                    if (GameManager.levelLose != 5) GameManager.levelLose++;
                }
                break;
            case "door":
                if (inventar.stage <= 6)
                {
                    loading.SetActive(true);
                    characterController.enabled = false;
                    SceneManager.LoadScene(indT);
                    characterController.enabled = true;
                    if (inventar.id == 4 && indT == 7) inventar.id = 0;
                }
                else
                    switch (indT)
                    {
                        case 10:
                            door0.SetActive(false);
                            door1.SetActive(true);
                            nDoor.text = "4 двери";
                            break;
                        case 11:
                            door1.SetActive(false);
                            door2.SetActive(true);
                            nDoor.text = "3 двери";
                            break;
                        case 12:
                            door2.SetActive(false);
                            door3.SetActive(true);
                            nDoor.text = "2 двери";
                            break;
                        case 13:
                            door3.SetActive(false);
                            door4.SetActive(true);
                            nDoor.text = "1 дверь";
                            break;
                        case 14:
                            nDoor.text = " ";
                            characterController.enabled = false;
                            GameManager.badEnd = true;
                            if (GameManager.bad1 == true)
                            {
                                GameManager.bad1 = false;
                                GameManager.bad = true;
                            }
                            finalBlack.SetActive(true);
                            Invoke("Zagruzka", 6f);
                            break;
                    }
                break;
            case "ruchka":
                ruchka.SetActive(false);
                if (GameManager.ruchka1 == true)
                {
                    GameManager.ruchka1 = false;
                    GameManager.ruchka = true;
                }
                inventar.id = 2;
                inventar.stage = 2;
                break;
            case "key":
                key.SetActive(false);
                inventar.id = 6;
                inventar.stage = 6;
                break;
            case "sun":
                other.gameObject.SetActive(false);
                inventar.id = 4;
                inventar.stage = 4;
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "lazer" && HP > 0)
        {
            HP = HP - 0.02;
            if (GameManager.levelLose != 5) GameManager.levelLose++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.ToLower().Contains("grey")) krokodil.grey = true;
        if (other.gameObject.tag.ToLower().Contains("yellow")) krokodil.yellow = true;
        if (other.gameObject.tag.ToLower().Contains("red")) krokodil.red = true;
        if (other.gameObject.tag.ToLower().Contains("white")) krokodil.white = true;
        if (other.gameObject.tag.ToLower().Contains("blue")) krokodil.blue = true;
        if (other.gameObject.tag.ToLower().Contains("orange")) krokodil.orange = true;
        if (other.gameObject.tag.ToLower().Contains("black")) krokodil.black = true;
        if (other.gameObject.tag.ToLower().Contains("wood")) krokodil.wood = true;
        if (other.gameObject.tag.ToLower().Contains("purple")) krokodil.purple = true;
        if (other.gameObject.tag.ToLower().Contains("brown")) krokodil.brown = true;
        if (other.gameObject.tag.ToLower().Contains("pink")) krokodil.pink = true;


        if (other.gameObject.tag == "start")
        {
            startZemlya = true;
        }
    }

    void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        ShowCursor();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        HP = maxHealth;

        inventar.orugie = orugie;
        inventar.target = target;
    }

    void Update()
    {
        GameManager.player = this.gameObject;

        Settings.posPlayer = transform.position;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (characterController.enabled == true) characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            HideCursor();
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        else ShowCursor();


        if (HP <= 0)
        {
            HP = 100;
            finalBlack.SetActive(true);
            if (GameManager.good1 == true)
            {
                GameManager.good1 = false;
                GameManager.good = true;
            }
            Invoke("Zagruzka", 6f);
        }

        if(SceneManager.GetActiveScene().name == "pole")
        {
            move.characterController.enabled = false;
        }

    }

    void Zagruzka()
    {
        loading.SetActive(true);
    }

    void LastScene()
    {
        SceneManager.LoadScene(11);
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