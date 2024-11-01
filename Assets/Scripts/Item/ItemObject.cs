using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    ItemData data;
    public string GetInteractPrompt()
    {
        return $"{data.displayName}\n{data.description}";
    }
    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = data;
    }

}
