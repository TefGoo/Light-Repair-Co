using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab; // Reference to the NPC prefab
    public GameObject miniGamePanel; // Reference to the mini-game panel GameObject
    public Transform spawnPoint; // Reference to the spawn point transform
    public float spawnInterval = 10f; // Time interval between spawn attempts
    public float spawnChance = 0.5f; // Chance of spawning an NPC

    private GameObject currentNPC; // Reference to the currently spawned NPC
    private bool spawnerPaused = false; // Flag indicating whether the spawner is paused

    void Start()
    {
        // Start the spawning process
        InvokeRepeating("TrySpawnNPC", 0f, spawnInterval);
    }

    void TrySpawnNPC()
    {
        // Check if the spawner is paused or if there's already a currently spawned NPC
        if (!spawnerPaused && currentNPC == null && Random.value < spawnChance)
        {
            SpawnNPC();
        }
    }

    public void PauseSpawner(bool pause)
    {
        spawnerPaused = pause;
    }

    public void SpawnNPC()
    {
        // Spawn a new NPC at the spawn point's position
        currentNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("NPC spawned at position: " + spawnPoint.position);
    }

    // Method to be called when the mini-game is completed
    public void MiniGameCompleted()
    {
        // Close the mini-game panel
        miniGamePanel.SetActive(false);


        // Destroy the NPC
        Destroy(currentNPC);
        currentNPC = null; // Set currentNPC to null to indicate no NPC is currently spawned

        // Attempt to spawn a new NPC after a delay
        Invoke("TrySpawnNPC", spawnInterval);
    }


}
