using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public PlayerCondition playerCondition;
    public PlayerController playerController;

    public ItemData itemData;
    public Action addItem;

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
