using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        playerController = GetComponent<PlayerController>();
    }
}
