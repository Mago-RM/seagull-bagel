using UnityEngine;

public class BagelSpawner : MonoBehaviour
{
    public GameObject bagelPrefab;

    public float spawnRate = 2f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnBagel();
            timer = 0;
        }
    }

    void SpawnBagel()
    {
        float randomY = Random.Range(-4f, 4f);

        Vector3 spawnPosition = new Vector3(10f, randomY, 0);

        GameObject newBagel = Instantiate(bagelPrefab, spawnPosition, Quaternion.identity);

        newBagel.GetComponent<BagelMovement>().speed = FindObjectOfType<GameManager>().currentBagelSpeed;
    }
}
