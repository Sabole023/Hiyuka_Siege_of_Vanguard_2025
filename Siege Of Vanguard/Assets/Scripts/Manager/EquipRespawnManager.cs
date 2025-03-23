using System;
using UnityEngine;

public class EquipRespawnManager : MonoBehaviour
{
    public static EquipRespawnManager main;

    [Header("References")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] equipmentPrefabs;

    [Header("Attributes")]
    public int currentEquipment;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        // Initialize equipment
        SpawnEquipment();
        currentEquipment = spawnPoints.Length;
    }

    private void Update()
    {
        if(currentEquipment <= 0)
        {
            SpawnEquipment();
        }
    }

    public void RerollEquipment()
    {
        DeleteAllEquipment();

        SpawnEquipment();
    }

    private void DeleteAllEquipment()
    {
        GameObject[] equipments = GameObject.FindGameObjectsWithTag("Equipment");

        foreach(GameObject o in  equipments)
        {
            Destroy(o);
        }
    }

    public void SpawnEquipment()
    {
        currentEquipment = spawnPoints.Length;
        
        foreach(Transform t in spawnPoints)
        {
            CreateEquipment(t);
        }
    }

    public void UpdateCurrentEquipment(int amount)
    {
        currentEquipment += amount;
    }

    private void CreateEquipment(Transform position)
    {
        int randomIndex = UnityEngine.Random.Range(0, equipmentPrefabs.Length);

        GameObject equipment = equipmentPrefabs[randomIndex];

        EquipmentController eC = equipment.GetComponent<EquipmentController>();
        if(eC != null)
        {
            eC.SetDefaultPosition(position);
        }

        Instantiate(equipment, position.position, Quaternion.identity);
    }
}
