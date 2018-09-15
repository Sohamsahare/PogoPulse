using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float backgroundSize;
    public float parallaxSpeed;
    public bool isScrolling;
    public bool isParallaxing;

    [SerializeField]
    private float viewZone = 10;
    private Transform camTransform;
    private Transform[] layers;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

    private void Awake()
    {
        camTransform = Camera.main.transform;
        lastCameraX = camTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = new Vector3((layers[leftIndex].position.x - backgroundSize), layers[rightIndex].position.y, layers[rightIndex].position.z);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = new Vector3((layers[rightIndex].position.x + backgroundSize), layers[leftIndex].position.y, layers[leftIndex].position.z);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }

    private void Update()
    {
        if (isParallaxing)
        {
            float deltaX = camTransform.position.x - lastCameraX;
            transform.position += Vector3.right * deltaX * parallaxSpeed;
        }

        lastCameraX = camTransform.position.x;

        if (isScrolling)
        {
            if (camTransform.position.x < layers[leftIndex].position.x + viewZone)
            {
                ScrollLeft();
            }
            if (camTransform.position.x > layers[rightIndex].position.x - viewZone)
            {
                ScrollRight();
            }
        }
    }
}
