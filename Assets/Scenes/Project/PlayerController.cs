using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rgBod;
    public TextMeshProUGUI text;
    public float walk;
    public float jump;
    public float turnSpeed;
    public Animator anime;
    public bool isJumping;
    public bool isWalking;
    public Transform hips;
    public bool isMoveBlocked;
    public int deathCount;

    public void ResetDeathCount()
    {
        PlayerPrefs.DeleteKey("DeathCount");
        deathCount = 0;
        PlayerPrefs.SetInt("DeathCount", deathCount);
        text.text = "Death Counter " + PlayerPrefs.GetInt("DeathCount");
    }


    private void unFreeze()
    {
        isMoveBlocked = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        text.text = "Death Counter " + PlayerPrefs.GetInt("DeathCount");
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetDeathCount();
        }

        if (Input.GetButtonDown("Jump"))
        {
            isMoveBlocked = true;
            Invoke("unFreeze", 3);
            isJumping = !isJumping;
            anime.SetInteger("state", isJumping ? 1 : 0);
        }


        float turn = Input.GetAxis("Mouse X");

        

        if (isJumping)
        {

            if (isMoveBlocked || hips.position.y < -4.3f)
            {
                turn = 0;

            }
            else
            {
                turn *= turnSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (!isMoveBlocked)
            {
                turn *= turnSpeed * Time.deltaTime;
            }
            else
            {
                turn = 0;
            }
            

        }


        transform.eulerAngles += new Vector3(0, turn, 0);

    }

    private void FixedUpdate()
    {

        float vert = Input.GetAxis("Vertical");
        
        if (isJumping)
        {
            
            if (isMoveBlocked || hips.position.y < -4.3f)
            {
                vert = 0;

            }
            else
            {
                vert *= jump;
            }
        }
        else
        {
            if (!isMoveBlocked)
            {
                vert *= walk;
            }
            else
            {
                vert = 0;
            }
            
        }
        rgBod.velocity = transform.TransformDirection(new Vector3(0, 0, vert));


        if (!isJumping)
        {
            if (rgBod.velocity.magnitude > 0.01f)
            {
                anime.SetInteger("state", 2);
            }
            else
            {
                anime.SetInteger("state", 0);
            }
            
        }



    }
}
