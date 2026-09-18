using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] cloudPrefabs;
    public float spawnRate = 3f;

    public float minY = -3f;
    public float maxY = 4f;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnCloud();
            timer = 0f;
        }
        
    }

    void SpawnCloud(){
        int randomIndex = Random.Range(0,cloudPrefabs.Length);
        GameObject cloudToSpawn = cloudPrefabs[randomIndex];
        float randomY = Random.Range(minY,maxY);
        Vector3 spawnPosition = new Vector3(10f, randomY, 0f);
        Instantiate(cloudToSpawn,spawnPosition,Quaternion.identity);
    }

    void Start()
    {
        
    }
}
