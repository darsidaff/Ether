using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public GameObject player;
    int r = 0;
    public bool open;
    public int indTarget;

    public GameObject crystal;

    void Start()
    {
        if (indTarget != 20) move.indT = indTarget;
    }


    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (indTarget != 20)
        {
            if (dist <= 7 && r < 400 && open == true)
            {
                move.indT = indTarget;
                transform.rotation *= Quaternion.Euler(0, -0.3f, 0);
                r += 1;
            }
            else if (r != 0 && open == true)
            {
                transform.rotation *= Quaternion.Euler(0, 0.3f, 0);
                r -= 1;
            }
        }
        else if (dist <= 3 && r < 400)
        {
            move.indT = indTarget;
            transform.rotation *= Quaternion.Euler(0, -0.3f, 0);
            r += 1;
        }



        if (dist <= 7 && r < 400 && indTarget == 2 && inventar.stage == 1)
        {
            crystal.SetActive(true);
            inventar.id = 0;
            open = true;
        }

        if (indTarget == 2 && inventar.stage == 1 && inventar.id == 0)
        {
            crystal.SetActive(true);
        }

        if (indTarget == 2 && inventar.stage > 1)
        {
            crystal.SetActive(true);
        }
        if (indTarget == 3 && inventar.stage >= 1)
        {
            open = false;
        }

        if (dist <= 7 && r < 400 && indTarget == 4 && inventar.stage == 2)
        {
            gameObject.transform.Find("основа ручки.001").gameObject.SetActive(true);
            inventar.id = 0;
            open = true;
        }

        if (indTarget == 4 && inventar.stage == 2 && inventar.id == 0)
        {
            gameObject.transform.Find("основа ручки.001").gameObject.SetActive(true);
        }

        if (indTarget == 4 && inventar.stage > 2)
        {
            gameObject.transform.Find("основа ручки.001").gameObject.SetActive(true);
        }

        if (indTarget == 2 && inventar.stage >= 2)
        {
            open = false;
        }

        if (indTarget == 4 && inventar.stage >= 3)
        {
            open = false;
        }

        if (indTarget == 1 && inventar.stage >= 1 && inventar.stage < 4)
        {
            open = true;
        }

        if (indTarget == 1 && inventar.stage >= 4)
        {
            open = false;
        }

        if (indTarget == 5 && inventar.stage == 4 && inventar.id == 4)
        {
            move.indT = 7;
        }

        if (indTarget == 5 && inventar.stage == 4)
        {
            move.indT = 7;
        }
        if ((indTarget == 5 || indTarget == 5) && inventar.stage >= 5)
        {
            open = false;
        }

        if (dist <= 7 && r < 400 && indTarget == 6 && inventar.stage == 6)
        {
            inventar.id = 0;
            open = true;
        }

    }

 
}
