using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float x;
    public float z;
    public float speed = 12f;

    Vector3 velocity;
    public float gravity = -19.6f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public bool isJumped;

    public float jumpHeight = 2f;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //controlo si esta en el piso
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && isJumped) {  
            isJumped = false; 
        }
        //chequeo para que la aceleracion no aumente indefinidamente
        if(isGrounded && velocity.y < 0) {
            velocity.y = -4;
        }

        //detecto inputs de AWSD
        x = Input.GetAxis("Horizontal"); //A=-1 D=1
        z = Input.GetAxis("Vertical");//S=-1 W=1
        /*
        if (Input.GetKeyDown(KeyCode.A)) { x = -1; }
        if (Input.GetKeyUp(KeyCode.A)) { x = 0; }
        if (Input.GetKeyDown(KeyCode.D)) { x = 1; }
        if (Input.GetKeyUp(KeyCode.D)) { x = 0; }
        if (Input.GetKeyDown(KeyCode.W)) { z = 1; }
        if (Input.GetKeyUp(KeyCode.W)) { z = 0; }
        if (Input.GetKeyDown(KeyCode.S)) { z = -1; }
        if (Input.GetKeyUp(KeyCode.S)) { z = 0; }
        */

        //aplico movimiento en las 4 direcciones y se lo paso al CC
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);

        //detecto si pulsa saltar y chequeo que este en el suelo
        if(Input.GetButtonDown("Jump") && isGrounded) {
            isJumped = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }

        //si no esta en el piso le aplico una velocidad en y para caer
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // por fisica la aceleracion en es tiempo al cudrado

        //control animaciones
        if(x > 0) anim.SetInteger("xvalue", 1);
        if(x < 0) anim.SetInteger("xvalue", -1);
        if (x == 0) anim.SetInteger("xvalue", 0);
        if (z > 0) anim.SetInteger("zvalue", 1);
        if (z < 0) anim.SetInteger("zvalue", -1);
        if (z == 0) anim.SetInteger("zvalue", 0);
        anim.SetBool("isJumping", isJumped);

        //anim.SetInteger("x", (int) x);
        //anim.SetInteger("z", (int) z);

    }
}
