using UnityEngine;

public enum ItemType
{
    Weapon,
    Helmet,
    Armor
}

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string Name;
    public string Description;
    public ItemType type;
    public Sprite sprite;
}
