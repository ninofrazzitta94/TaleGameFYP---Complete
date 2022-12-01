using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpDeceleration = 2f;
    public float waterSpeed;
    private float initialSpeed;
    public float moveHor;
    private float moveVer;

    public bool isGrounded;
    public LayerMask GroundedMask;
    private Rigidbody rb;

    public GirlFollow girlFollowScript;

    public bool canMove = true;
    public bool BoyFinished = false;
    public bool OnLadder = false;
    public bool InWater = false;
    public bool PushingBox = false;

    public Vector3 ballOffset;
    public TrowBall trowBallScript;
 
    public Animator PlayerAnimator;
    public GameObject Poncho;
    public Transform SkeletonChild;

    public Audio_Manager AM;
    public AudioSource pushingAudio;

    public bool Holding;
    public CursorChanger CursorChangerScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        initialSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (canMove)
        {

            moveHor = Input.GetAxis("Horizontal");
            moveVer = Input.GetAxis("Vertical");

            if (OnLadder)
            {
                speed = initialSpeed;
                rb.velocity = new Vector3(moveHor * speed, moveVer * speed);
            }
            if (InWater)
            {
                speed = initialSpeed;
                rb.velocity = new Vector3(moveHor * speed, moveVer * speed);
            }
            else
            {
                rb.velocity = new Vector3(moveHor * speed, rb.velocity.y);
            }
            if (!isGrounded && !OnLadder)
            {
                float newspeed = 0;
                speed = Mathf.MoveTowards(speed, newspeed, jumpDeceleration * Time.deltaTime);
            }
            if (isGrounded)
            {
                speed = initialSpeed;
            }
        }


        //Ray ray = new Ray(transform.position, -transform.up);
       // RaycastHit hit;

        
        
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + .1f, GroundedMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            girlFollowScript.HoldingHands = false;
        }

        if (!Physics.Raycast(ray, out hit, 1 + .1f, GroundedMask))
        {
            girlFollowScript.HoldingHands = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        //Animations

        if (canMove)
        {
            if (moveHor > 0)
            {
                PlayerAnimator.SetBool("Run", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (moveHor < 0)
            {
                PlayerAnimator.SetBool("Run", true);
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
        if (moveHor == 0)
        {
             PlayerAnimator.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
             PlayerAnimator.SetTrigger("Jumping");
        }

        if (isGrounded == false)
        {
             PlayerAnimator.SetBool("OnAir", true);
            //PlayerAnimator.SetBool("Jumping", false);
            PlayerAnimator.SetBool("OnLadder", false);

        }
        if (isGrounded == true)
        {
            PlayerAnimator.SetBool("Landing", true);
            PlayerAnimator.SetBool("OnAir", false);
            PlayerAnimator.SetBool("OnLadder", false);
        }
        if (OnLadder)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);            
            PlayerAnimator.SetBool("OnLadder", true);
            PlayerAnimator.SetBool("OnAir", false);
            PlayerAnimator.SetBool("Landing", false);

            if (Input.GetAxis("Vertical") > 0.1)
            {
                PlayerAnimator.SetFloat("Mult Lad", 1);
            }
            if (Input.GetAxis("Vertical") < -0.1)
            {
                PlayerAnimator.SetFloat("Mult Lad", -1);
            }
            if (Input.GetAxis("Vertical") == 0 )
            {
                PlayerAnimator.SetFloat("Mult Lad", 0);
            }
        }
        if (!OnLadder)
        {
            PlayerAnimator.SetBool("OnLadder", false);
        }
        if (InWater)
        {
            PlayerAnimator.SetBool("Swim", true);

            if (Input.GetAxis("Horizontal") > 0.1)
            {
                PlayerAnimator.SetFloat("Mult Swim", 2);
            }
            if (Input.GetAxis("Horizontal") < -0.1)
            {
                PlayerAnimator.SetFloat("Mult Swim", 2);
            }
            if (Input.GetAxis("Horizontal") == 0)
            {
                PlayerAnimator.SetFloat("Mult Swim", -0.25f);
            }
        }
        if (!InWater)
        {
            PlayerAnimator.SetBool("Swim", false);           
        }
        if (PushingBox && moveHor >0.95f || PushingBox && moveHor < -0.95f)
        {
            if (isGrounded)
            {
                PlayerAnimator.SetBool("Push", true);
                //Playing audio
                if (rb.velocity.x > 0.95f || rb.velocity.x < -0.95f)
                {
                    pushingAudio.enabled = true;
                }
                else
                {
                    pushingAudio.enabled = false;
                }
            }
        }
        if (!PushingBox)
        {
            PlayerAnimator.SetBool("Push", false);
            pushingAudio.enabled = false;
        }
        if (trowBallScript.grabbed == true && trowBallScript.ballShot == false && Input.GetMouseButtonDown(0))
        {
            PlayerAnimator.SetTrigger("Head");
            //trowBallScript.ballShot = true;
        }

        if (isGrounded)
        {
            speed = initialSpeed;

        }
    }

    private void OnTriggerEnter(Collider other)
    {     
            if (other.gameObject.name == "FinishDoor")
            {
                BoyFinished = true;
            }
            if (other.gameObject.tag == "Water")
            {
                InWater = true;
                Poncho.GetComponent<Cloth>().useGravity = false;
                Poncho.GetComponent<Cloth>().damping = 0.9f;

            }       
            if (other.gameObject.tag == "Ball")
            {
            other.GetComponent<TrowBall>().grabbed = true;
            other.transform.parent = SkeletonChild.transform;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().detectCollisions = false;
            other.GetComponent<Transform>().position = SkeletonChild.transform.position + ballOffset;
            }
    }

    private void OnTriggerStay(Collider other)
    {
        if (moveVer != 0)
        {
            if (other.gameObject.tag == "Ladder")
            {
                OnLadder = true;
                GetComponent<Rigidbody>().useGravity = false;
            }
        }
        if (other.gameObject.tag == "Water")
        {
            GetComponent<Rigidbody>().useGravity = false;
            speed = waterSpeed;

            Poncho.GetComponent<Cloth>().useGravity = true;
            Poncho.GetComponent<Cloth>().damping = 0.8f;

            rb.AddForce(Vector3.down * jumpForce/4, ForceMode.Impulse);
        }
        if (other.gameObject.tag == "Lever")
        {
            if (other.GetComponent<DestroyPlatform>().Interacted == true)
            {
                    canMove = false;
                    rb.isKinematic = true;
                    transform.rotation = Quaternion.Euler(0, -90, 0);

                    PlayerAnimator.SetTrigger("Lever");

                    other.GetComponent<DestroyPlatform>().Interacted = false;
                    rb.isKinematic = false;
                    canMove = true;              
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FinishDoor")
        {
            BoyFinished = false;
        }
        if (other.gameObject.tag == "Ladder")
        {
            OnLadder = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (other.gameObject.tag == "Water")
        {
            OnLadder = false;
            GetComponent<Rigidbody>().useGravity = true;
            InWater = false;
            PlayerAnimator.SetBool("OnAir", true);
        }        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Box")
        {
            PushingBox = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Box")
        {
            PushingBox = false;
        }
    }

    public void HoldingBall()
    {
        Holding = true;
        CursorChangerScript.LoadCustomCursor();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NotHoldingBall()
    {
        Holding = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
