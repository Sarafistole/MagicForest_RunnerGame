using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    private bool jumpRequested = false;
    private bool isJumping = false;

    public float jumpHeight = 3f;
    public float jumpDuration = 0.6f;

    private float jumpTimer = 0f;
    private float startY;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameManager.Instance.isSTARTED)
            return;

        if (jumpRequested && !isJumping)
        {
            StartJump();
            jumpRequested = false;
        }

        if (isJumping)
        {
            UpdateJump();
        }
    }

    void StartJump()
    {
        isJumping = true;
        jumpTimer = 0f;
        startY = transform.position.y;

        anim.SetBool("isJump", true);
    }

    void UpdateJump()
    {
        jumpTimer += Time.deltaTime;

        float progress = jumpTimer / jumpDuration;

        if (progress >= 1f)
        {
            progress = 1f;
            isJumping = false;
            anim.SetBool("isJump", false);
        }

        float height = Mathf.Sin(progress * Mathf.PI) * jumpHeight;

        transform.position = new Vector3(
            transform.position.x,
            startY + height,
            transform.position.z
        );
    }

    void OnJump(InputValue jumpValue)
    {
        if (!GameManager.Instance.isSTARTED)
            return;

        if (jumpValue.isPressed && !isJumping)
        {
            jumpRequested = true;
        }
    }

    public void SetIdle()
    {
        isJumping = false;
        jumpRequested = false;

        anim.SetBool("isRun", false);
        anim.SetBool("isJump", false);
    }

    public void StartRun()
    {
        anim.SetBool("isRun", true);
    }


    // transform.position : coordonnées world
    // transform.localPosition : coordonnées locales / relatives
    // transform.Translate(le vecteur de déplacement) : déplacement relatif depuis la position actuelle
    // transform.rotation / transform.localRotation
    // transform.Rotate

    // Space.Self ou Space.World permet de choisir local ou world
}
