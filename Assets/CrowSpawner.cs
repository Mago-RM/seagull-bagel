using UnityEngine;

public class CrowSpawner : MonoBehaviour
{
    public GameObject crowPrefab;
    public GameManager gameManager;

    public float spawnRate = 4f;
    public int levelToStart = 1;

    float timer;

    void Update()
    {
        if (gameManager.currentLevel < levelToStart)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnCrow();
            timer = 0;
        }
    }

   void SpawnCrow()
    {
        Debug.Log("Spawning Crow");

        float randomX = Random.Range(-2f, 9f);
        Vector3 spawnPosition = new Vector3(randomX, 4.5f, 0f);

        GameObject newCrow = Instantiate(crowPrefab, spawnPosition, Quaternion.identity);
        newCrow.transform.localScale = new Vector3(3f, 3f, 1f);
    }
}