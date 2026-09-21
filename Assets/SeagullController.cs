using UnityEngine;

public class SeagullController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0);

        // Calculate where the bird wants to move
        Vector3 newPosition =
            transform.position + movement * moveSpeed * Time.deltaTime;

        // Get the visible edges of the camera
        Camera cam = Camera.main;

        float minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float minY = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxY = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // Don't allow the bird outside those edges
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
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