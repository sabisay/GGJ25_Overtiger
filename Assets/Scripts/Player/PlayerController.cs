using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //public AudioSource mousesound;

    public Rigidbody2D rb;
    public float MoveSpeed;
    public Transform PlayerHeadPivot;
    public GameObject GroundCheck;

    public float FlyingSpeed;
    public float FlyingBaloon;

    private Vector2 move_pos;
    

    private float flybool;
    public float distance = 5;

    public InputActionReference move;
    public InputActionReference fly;

    public Animator animator;



    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        SaveLoadManager.Instance.LoadGame();
        PlayerHealthSystem.Instance.RefreshUIforBullet();
    }

    void Update()
    {
        move_pos = move.action.ReadValue<Vector2>();
        flybool = fly.action.ReadValue<float>();

        if (GroundCheck != null)
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)GroundCheck.transform.position, Vector2.down, distance);
            Debug.DrawRay((Vector2)transform.position, Vector2.down * distance, Color.red);

            if(hit.collider != null)
            {
                if (move_pos != Vector2.zero && flybool != 0 && hit.collider.CompareTag("Ground"))
                {
                    animator.SetBool("Walking", true);
                }
            }
            else
            {
                animator.SetBool("Walking", false);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX += move_pos.x * MoveSpeed;

        if (flybool == 0)
        {
            

            // Debug.Log("uçuyorsun melih");
            rb.linearVelocityY += FlyingSpeed / 10;
            PlayerHeadPivot.localScale = Vector3.Lerp(PlayerHeadPivot.localScale, new Vector3(1,1,1), FlyingBaloon * Time.timeScale);
        }
        else
        {
            //mousesound.Play();

            PlayerHeadPivot.localScale =
                    Vector3.Lerp(
                        PlayerHeadPivot.localScale,
                        new Vector3(.3f, .3f, .3f),
                        FlyingBaloon * Time.timeScale);
        }
    }
}