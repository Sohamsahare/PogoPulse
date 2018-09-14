using System.Collections;
using UnityEngine;

public class PogoBoy : MonoBehaviour
{
    public float doPogoAnimTime;
    public float jumpMinImpulseY;
    public Vector3 jumpMaxImpulseVector;
    public Joystick joystick;

    private bool isInAir;
    private Animator anim;
    private Rigidbody2D rb;
    private float verticalImpulse;
    private Vector3 JumpImpulseVector
    {
        get
        {
            verticalImpulse = joystick.Vertical * jumpMaxImpulseVector.y;
            return new Vector3(
                joystick.Horizontal * jumpMaxImpulseVector.x,
                (verticalImpulse > jumpMinImpulseY) ? verticalImpulse : jumpMinImpulseY,
                0);
        }
    }
    private void PlayerDirection()
    {
        if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else if (joystick.Horizontal > 0)
        {
            transform.localScale = Vector3.one;
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (joystick == null)
        {
            Debug.LogError("Where is my joystick!?");
        }
    }

    private void Start()
    {
        isInAir = true;
    }

    private void Update()
    {
        anim.SetFloat("Horizontal", Mathf.Abs(joystick.Horizontal));
        anim.SetFloat("VerticalVelocity", rb.velocity.y);
        PlayerDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInAir && collision.transform.CompareTag("Ground"))
        {
            StartCoroutine(DoPogo());
        }
    }

    private IEnumerator DoPogo()
    {
        isInAir = !isInAir;
        anim.SetTrigger("DoPogo");
        yield return new WaitForSeconds(doPogoAnimTime);
        rb.AddForce(JumpImpulseVector, ForceMode2D.Impulse);
        isInAir = !isInAir;
    }

    public void BarrelRoll()
    {

    }


}
