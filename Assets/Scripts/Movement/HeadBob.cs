using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private bool canUseHeadbob = true;

    [Header("Headbob Parameters")]
    [SerializeField] private float walkBobSpeed = 14f;
    [SerializeField] private float walkBobAmount = 0.05f;
    private float defaultYPos = 0;
    private float timer;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        defaultYPos = playerMovement.GetPlayerCamera().transform.localPosition.y;
    }
    private void Update()
    {
        if (canUseHeadbob)
        {
            HandleHeadbob();
        }
    }

    private void HandleHeadbob()
    {
        if (!characterController.isGrounded) return;

        if(Mathf.Abs(playerMovement.GetPlayerMoveDirection().x) >0.1f || Mathf.Abs(playerMovement.GetPlayerMoveDirection().z) > 0.1f)
        {
            timer += Time.deltaTime * walkBobSpeed;
            playerMovement.GetPlayerCamera().transform.localPosition = new Vector3(
                 playerMovement.GetPlayerCamera().transform.localPosition.x,
                 defaultYPos + Mathf.Sin(timer) * walkBobAmount,
                 playerMovement.GetPlayerCamera().transform.localPosition.z
                );
        }

    }
}
