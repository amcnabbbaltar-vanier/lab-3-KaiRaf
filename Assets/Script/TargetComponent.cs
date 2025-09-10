using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    private Renderer targetRenderer;
    private Color originalColor;
    public Color hitColor = Color.green;
    // Start is called before the first frame update
    private void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        // Random.InitState(42);
        // Debug.Log(Random.Range(-1.0f, 1.0f));
        // Debug.Log(Random.Range(-1.0f, 1.0f));
        // Debug.Log(Random.Range(-1.0f, 1.0f));
        if (targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.IncrementScore();

            if (targetRenderer != null)
            {
                targetRenderer.material.color = hitColor;
            }
            Invoke("ResetColor", 5f);
        }
    }

    private void ResetColor()
    {
        if (targetRenderer != null)
        {
            targetRenderer.material.color = originalColor;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    

}
