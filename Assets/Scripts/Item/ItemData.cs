using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/item")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public Sprite icon;
}
