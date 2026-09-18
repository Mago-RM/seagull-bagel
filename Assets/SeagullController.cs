using UnityEngine;

public class SeagullController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0);

        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
{
     if (other.CompareTag("Crow"))
    {
       Debug.Log("Hit by crow!");
        FindFirstObjectByType<GameManager>().EndGame();
    }
}
}