using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoining : MonoBehaviour
{
    private Gamepad gamepad;
    private Keyboard keyboard;
    private PlayerInput playerInput;
    [SerializeField] CharacterSelection selectManager;
    private int index;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void linkController()
    {
        if (playerInput.devices[index].GetType().ToString() == "UnityEngine.InputSystem.Gamepad")
        {
            gamepad = (Gamepad)playerInput.devices[index];
            Debug.Log("Gamepad found");
        }
        else
        {
            keyboard = (Keyboard)playerInput.devices[index];
            Debug.Log("Keyboard found");
        }

    }
}
