using UnityEngine;

public class NPCEquipUI : MonoBehaviour
{
    [SerializeField] private GameObject helmet;
    [SerializeField] private GameObject armor;
    [SerializeField] private GameObject weapon;

    public ItemScriptableObject weaponItem;
    public ItemScriptableObject armorItem;
    public ItemScriptableObject helmetItem;

    public void Equip(ItemScriptableObject item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                weaponItem = item;
                weapon.GetComponent<SpriteRenderer>().sprite = item.sprite;
                break;
            case ItemType.Armor:
                armorItem = item;
                armor.GetComponent<SpriteRenderer>().sprite = item.sprite;
                break;
            case ItemType.Helmet:
                helmetItem = item;
                helmet.GetComponent<SpriteRenderer>().sprite = item.sprite;
                break;
        }
    }
}
