using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerCondition playerCondition;
    public PlayerController playerController;

    private void Start()
    {
        CharacterManager.Instance.Player = this;
    }

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        playerCondition = GetComponent<PlayerCondition>();
        playerController = GetComponent<PlayerController>();
    }
}
