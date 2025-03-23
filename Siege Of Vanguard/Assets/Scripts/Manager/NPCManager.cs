using UnityEngine;
using UnityEngine.Events;

public class NPCManager : MonoBehaviour
{
    public static NPCManager main;

    [Header("References")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] npcPrefabs;

    // [Header("Events")]
    // public UnityEvent<Vector3> RespawnEvent;


    private int equipedNPC;
    private int maxEquipedNPC = 4;

    private void Awake()
    {
        main = this;

        // RespawnEvent = new UnityEvent<Vector3>();
        SpawnAll();
        equipedNPC = 0;
    }

    private void Start()
    {
        // RespawnEvent.AddListener(RespawnNPC);
    }

    // private void RespawnNPC(Vector3 position)
    // {
    //     foreach(Transform t in spawnPoints)
    //     {
    //         if(t.position == position)
    //         {
    //             CreateNPC(t.position);
    //         }
    //     }
    // }

    public void EquipNPC()
    {
        equipedNPC++;

        if(equipedNPC >= maxEquipedNPC)
        {
            Debug.Log("All NPCs are equipped");
            DeleteAll();
            SpawnAll();
            equipedNPC = 0;
        }
    }

    private void SpawnAll()
    {
        foreach(Transform t in spawnPoints)
        {
            CreateNPC(t.position);
        }
    }

    private void DeleteAll()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

        foreach(GameObject npc in npcs)
        {
            Destroy(npc);
        }
    }

    private void CreateNPC(Vector3 position)
    {
        int randomIndex = Random.Range(0, npcPrefabs.Length);

        GameObject npc = npcPrefabs[randomIndex];

        Instantiate(npc, position, Quaternion.identity);
    }
}
