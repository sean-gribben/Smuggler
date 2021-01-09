using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 3.0f;
    public float gravityValue = -9.81f;
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer) {
            animator.SetBool("jumping", false);
        }

        if (!groundedPlayer)
        {
            controller.stepOffset = 0f;
        }
        

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        float speedModifier = 1.0f;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speedModifier = 0.6f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            speedModifier = 1.4f;
        }

        float rate = playerSpeed * speedModifier;
        Debug.Log(rate);
        animator.SetFloat("forward", rate * Input.GetAxis("Vertical"));
        animator.SetFloat("strafe", rate * Input.GetAxis("Horizontal"));
        controller.Move(move * Time.deltaTime * rate);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetBool("jumping", true);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (Vector3.Dot(hit.moveDirection, Vector3.up) > 0.95f) {
            playerVelocity.y = 0;
        }
    }
}