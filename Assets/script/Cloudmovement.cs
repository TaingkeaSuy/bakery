using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 1f;          // Cloud movement speed
    public float resetX = -10f;       // X position to reset cloud
    public float startX = 10f;        // Starting X position
    public float minY = -3f, maxY = 3f; // Vertical range

    [Header("Fade Settings")]
    public bool useFade = true;       // Enable fade in/out
    public float fadeDuration = 2f;   // Duration of fade

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Random vertical position at spawn
        Vector3 pos = transform.position;
        pos.y = Random.Range(minY, maxY);
        pos.x = startX;
        transform.position = pos;

        // Start fade if enabled
        if (useFade)
            StartCoroutine(FadeIn());
    }

    void Update()
    {
        // Move left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // If cloud goes off screen, respawn
        if (transform.position.x < resetX)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        Vector3 pos = transform.position;
        pos.x = startX;
        pos.y = Random.Range(minY, maxY);
        transform.position = pos;

        if (useFade)
        {
            sr.color = new Color(1,1,1,0); // Reset alpha
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeDuration;
            sr.color = new Color(1, 1, 1, t);
            yield return null;
        }
    }

    IEnumerator FadeOutAndDestroy()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime / fadeDuration;
            sr.color = new Color(1, 1, 1, t);
            yield return null;
        }
        Destroy(gameObject);
    }
}
