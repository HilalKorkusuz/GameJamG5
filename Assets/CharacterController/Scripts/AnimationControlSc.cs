using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlSc : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    float rotationFactorPerFrame = 15.0f;
    float groundedGravity = -.05f;
    float gravity = -9.8f;
    private void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInput.CharacterControls.Movement.performed += context => {
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
            currentRunMovement.x = currentMovementInput.x * 3.0f;
            currentRunMovement.z = currentMovementInput.y * 3.0f;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        };
        playerInput.CharacterControls.Run.performed += context => { isRunPressed = context.ReadValueAsButton(); };
        playerInput.CharacterControls.Run.canceled += context => { isRunPressed = context.ReadValueAsButton(); };
        //tuþ býrakýldýðýnda hareketi durdurmak için
        playerInput.CharacterControls.Movement.canceled += context => {
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        };
    }
    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else
        {
            currentMovement.y = gravity;
            currentRunMovement.y = gravity;
        }
    }
    //Animasyon fonksiyonu
    void handleAnimation ()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        if (isMovementPressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        else if (!isMovementPressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }
        if ((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool("isRunning", true);
        }
        else if ((!isMovementPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool("isRunning", false);
        }
    }
    void handleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        Quaternion currentRotation = transform.rotation ;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }
    void Update()
    {
        handleRotation();
        handleAnimation();
        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }
        handleGravity();

    }
    //player input içerisindeki map'i aktifleþtirme ve kapatma. YAZILMALI!
    private void OnEnable() // BU YÖNTEME ÇOK ÝYÝ ÇEVÝRDÝ!!
    {
        playerInput.CharacterControls.Enable();
    }
    private void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }
}
