using System.Collections.Generic;
using UnityEngine;

public class NPCEquipment : MonoBehaviour
{
    Dictionary<ItemType, ItemScriptableObject> dictEquipment;
    [SerializeField] private NPCEquipUI npcUI;

    private void Awake()
    {
        dictEquipment = new Dictionary<ItemType, ItemScriptableObject>();
        npcUI = GetComponentInChildren<NPCEquipUI>();
    }

    public bool AddEquipment(Item equipment)
    {
        if(!checkEquipment(equipment.item))
        {
            return false;
        }
        
        dictEquipment[equipment.item.type] = equipment.item;
        npcUI.Equip(equipment.item);

        if(!CheckQuantityEquipment())
        {
            // NPCManager.main.RespawnEvent?.Invoke(transform.position);
            NPCManager.main.EquipNPC();
        }
        return true;
    }

    public bool checkEquipment(ItemScriptableObject e)
    {
        if(dictEquipment.ContainsKey(e.type)){
            return false;
        }

        return true;
    }

    private bool CheckQuantityEquipment()
    {
        if(dictEquipment.Count < 3)
        {
            return true;
        }

        return false;
    }
}
