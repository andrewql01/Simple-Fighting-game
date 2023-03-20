using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemScripts : ScriptableObject
{
    public int id;
    new public string name = "New Item";
    public Sprite icon;
    public virtual void Use()
    {

    }
    
}
