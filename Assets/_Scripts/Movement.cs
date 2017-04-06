using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Animator animation;
    public Transform playerTransform;
    public float speed = 1f, rotationSpeed, runSpeed, jumpTime = 0f;
    private bool isWalkingFront, isWalkingBack, isRunning, isJumping, shoot;

    private float currentY = 0.0f;

    private float currentX = 0.0f;

    public Transform target;

    //private const float X_ANGLE_MIN = 15.0f;
    //private const float X_ANGLE_MAX = 50.0f;

    //private const float Y_ANGLE_MIN = 15.0f;
    //private const float Y_ANGLE_MAX = 50.0f;


    void Start ()
    {
        animation = GetComponent<Animator>();

        playerTransform = transform;

        isWalkingFront = false;
        isWalkingBack = false;
        isRunning = false;
        isJumping = false;




    }
	
	void Move()
    {


        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * speed * Time.deltaTime);
            isWalkingFront = true;
        }
        else
        {
            isWalkingFront = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * speed * Time.deltaTime);
            isWalkingBack = true;
         
        }
        else
        {
            isWalkingBack = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            animation.SetBool("TurningLeft", true);
        }

        else
        {
            animation.SetBool("TurningLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            animation.SetBool("TurningRight", true);
        }

        else
        {
            animation.SetBool("TurningRight", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalkingFront = false;
            isWalkingBack = false;
            isRunning = true;
            Run();
        }
        else
        {
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            isJumping = true;
            StandingJump();
        }


        if (Input.GetMouseButton(1))
        {
            animation.SetBool("IsAiming", true);
           
        }
        else
        {
            animation.SetBool("IsAiming", false);
        }

        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            animation.SetBool("isShooting", true);
        }
        else
        {
            animation.SetBool("isShooting", false);
        }

        
        
    }
    
    void Rolling()
    {
        if (animation.GetBool("isWalkingFront") == true && Input.GetKey(KeyCode.LeftAlt))
        {
            speed = 2;
            animation.SetBool("isRolling", true);

        }
        else
        {
            speed = 1;
            animation.SetBool("isRolling", false);
        }

            if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            animation.SetBool("isRolling", true);
                
        }
        else
        {
         
            animation.SetBool("isRolling", false);

        }
    }
  
    void Run()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * runSpeed * Time.deltaTime);


                if (Input.GetKey(KeyCode.Space))
            {
                animation.SetBool("Jump_run", true);

                
            }
            else
            {
                animation.SetBool("Jump_run", false);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * runSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    void StandingJump()
    {
        if (isJumping == true)
        {
            animation.SetBool("isJumping", true);
            Invoke("StopJumping", 0.1f);
        }
    }
    

    void StopJumping()
    {
        animation.SetBool("isJumping", false);
    }


    void AnimationControl()
    {
        if(isWalkingFront == true)
        {
            animation.SetBool("isWalkingFront", true);

            if (Input.GetMouseButton(1))
            {
               
                animation.SetBool("AimWalk", true);

            }
            else
            {
                animation.SetBool("AimWalk", false);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                animation.SetBool("Jump_run", true);
            }

            else
            {
                animation.SetBool("Jump_run", false);

            }
        }

        else
        {
            animation.SetBool("isWalkingFront", false);
        }

        if (isWalkingBack == true)
        {
            animation.SetBool("isWalkingBack", true);
        }

        else
        {
            animation.SetBool("isWalkingBack", false);
        }

        if (isRunning == true)
        {
            animation.SetBool("isRunning", true);

        }

        else
        {
            animation.SetBool("isRunning", false);
        }
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        Rolling();
        Move();
        AnimationControl();


        if (animation.GetBool("IsAiming") == true)
        {
           // playerTransform.Rotate(Vector3.up * (currentX * 5) * Time.deltaTime);


            animation.SetFloat("AimingAngle", -currentY * 4);
        }
        else
        {
            animation.SetFloat("AimingAngle", 0);
        }

       
    }


}
