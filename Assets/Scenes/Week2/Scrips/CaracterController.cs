using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CaracterController : MonoBehaviour
{

    [SerializeField] private Animator animator;  
    [SerializeField] private float acceleration;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform playsprite;
    [SerializeField] private float maxSpeed;
    private bool grounded = false;
    private int doublejump = 0;


    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        rigidbody.AddForce(new Vector2(acceleration * horizontal, 0));
        //(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))

        rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x, -maxSpeed , maxSpeed) ,rigidbody.velocity.y);

        if (horizontal == 0)
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            animator.SetInteger("state", 0);
        }
        else
        {
            animator.SetInteger("state", 1);

            if (horizontal < 0)
            {
                playsprite.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                playsprite.localScale = new Vector3(1, 1, 1);
            }
        }




        if (doublejump <= 1 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            doublejump++; 
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
        doublejump = 0; 
    }

}
