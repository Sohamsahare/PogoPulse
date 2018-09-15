using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public Transform target;
    public float moveAfterThisOffset = 9f;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (target.position.x + moveAfterThisOffset > transform.position.x)
        {
            transform.position += new Vector3((target.position.x + moveAfterThisOffset), transform.position.y, transform.position.z);
        }
        else if (target.position.x - moveAfterThisOffset < transform.position.x)
        {
            transform.position -= new Vector3((target.position.x - moveAfterThisOffset), transform.position.y, transform.position.z);
        }
    }
}
