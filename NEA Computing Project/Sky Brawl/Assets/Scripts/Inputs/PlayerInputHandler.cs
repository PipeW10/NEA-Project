using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerManager playerManager;
    private PlayerInput playerInput;
    private InputDevice inputDevice;
    private GameObject character;
    private CharacterInputs characterInputs;
    private PlayerController playerController;
    private UpAttack upAttack;
    private PlayerShield shield;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        inputDevice = playerInput.devices[0];
        SpawnCharacter();
        SetCharacterInput();
        playerController = character.GetComponent<PlayerController>();
        upAttack = character.GetComponent<UpAttack>();
        shield = character.GetComponent<PlayerShield>();
    }


    public void Fire1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            characterInputs.Fire1(context);
        }
    }
    public void Fire2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            characterInputs.Fire2();
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerController.PlayerJump();
        }
    }
    public void Shield(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shield.ShieldOn();
        }
        else if (context.canceled)
        {
            shield.ShieldOff();
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        playerController.Move(context.ReadValue<Vector2>());
    }
    public void Duck(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(playerController.PhaseThroughPlatform());
        }
    }
    public void UpAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            upAttack.JumpAttack();
        }
    }

    private void SetCharacterInput()
    {
         string characterName = character.GetComponent<Player>().characterName;
         if (characterName == "Archer")
         {
            characterInputs = character.GetComponent<ArcherInputs>();
         }
         else if (characterName == "Bandit")
         {
            characterInputs = character.GetComponent<BanditInputs>();
         }
        else if (characterName == "Alien")
        {
            characterInputs = character.GetComponent<AlienInputs>();
        }
    }

    private void SpawnCharacter()
    {
        if (inputDevice == PlayerManager.player1Input)
        {
            character = Instantiate(PlayerManager.playerCharacters[0], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (inputDevice == PlayerManager.player2Input)
        {
            character = Instantiate(PlayerManager.playerCharacters[1], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (inputDevice == PlayerManager.player3Input)
        {
            character = Instantiate(PlayerManager.playerCharacters[2], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (inputDevice == PlayerManager.player4Input)
        {
            character = Instantiate(PlayerManager.playerCharacters[3], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
