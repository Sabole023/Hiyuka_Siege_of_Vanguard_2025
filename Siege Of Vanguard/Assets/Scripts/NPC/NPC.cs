using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Dictionary<EquipmentType, Equipment> dictEquipment;
    [SerializeField] List<Equipment> listEquipment;
    private List<int> listIdEquipment;

    private void Awake()
    {
        dictEquipment = new Dictionary<EquipmentType, Equipment>();
        listEquipment = new List<Equipment>();
    }

    public bool AddEquipment(Equipment equipment)
    {
        if(!checkEquipment(equipment))
        {
            return false;
        }
        
        dictEquipment[equipment.type] = equipment;
        listEquipment.Add(equipment);

        if(!CheckQuantityEquipment())
        {
            ShowEquipment();

            // NPCManager.main.RespawnEvent?.Invoke(transform.position);
            NPCManager.main.EquipNPC();
        }
        return true;
    }

    public bool checkEquipment(Equipment e)
    {
        if(dictEquipment.ContainsKey(e.type)){
            return false;
        }

        return true;
    }

    private void ShowEquipment()
    {
        foreach(Equipment e in dictEquipment.Values)
        {
            Debug.Log(e.name);
        }
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
