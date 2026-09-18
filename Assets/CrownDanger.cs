using UnityEngine;

public class CrowDanger : MonoBehaviour
{
    public float speed = 4f;
    public Vector2 direction = new Vector2(-1f, -1f);

    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (transform.position.x < -12f || transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}