using UnityEngine;

public class ChildManager : MonoBehaviour
{
    public GameObject childObject;
    public Color color;

    private float width;
    private SpriteRenderer spriteRenderer;
    private Vector3 spawnPosition;

    private void Awake()
    {
        spriteRenderer = childObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        width = spriteRenderer.bounds.size.x;
        spriteRenderer.color = color;
        spawnPosition = transform.position;
        SpawnChild(spawnPosition);
    }

    public void SpawnChild(Vector3 spawnPosition)
    {
        Instantiate(childObject, spawnPosition, Quaternion.identity, transform);
    }

}
