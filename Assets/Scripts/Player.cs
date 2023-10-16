using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask layermask;
    BoxCollider2D bc2d;
    Rigidbody2D rb2d;


    public TMP_Dropdown characterSelection;

    Scene scene;

    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    int jumpingIndex = 0;

    bool canJump = false;
    bool hasPlayed = false;
    bool playimpactsoundEffect = false;

    float jumpVelocity;
    int numjumpsthisTurn;
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        scene = SceneManager.GetActiveScene();
        audioSource = GetComponent<AudioSource>();
        jumpVelocity = 15;
        spriteRenderer = GetComponent<SpriteRenderer>();
        numjumpsthisTurn = 0;
    }

    void Update()
    {
        if (GameManager.instance.gamehasStarted)
        {
            if (IsGrounded())
            {
                //spriteRenderer.sprite = PlayerManager.Instance.GetPlayerSprites()[0];
                if (playimpactsoundEffect)
                {
                    audioSource.Play();
                    playimpactsoundEffect = false;
                }
                else
                    audioSource.Stop();
                canJump = true;
            }
        }
        if (!canJump)
        {
            return;
        }
        if (Input.touchCount <= 0)
        {
            return;
        }
        Touch t = Input.GetTouch(0);

        if (t.phase == TouchPhase.Began)
        {
            playimpactsoundEffect = true;
            rb2d.velocity = Vector2.up * jumpVelocity;
            canJump = false;
            //if (PlayerManager.Instance.GetPlayerSprites()[0].name.Equals("ryan"))
            //{
            //    if (jumpingIndex == 3)
            //    {
            //        spriteRenderer.sprite = PlayerManager.Instance.GetJumpingSprites()[jumpingIndex];
            //        jumpingIndex = 0;
            //    }
            //    else
            //    {
            //        spriteRenderer.sprite = PlayerManager.Instance.GetJumpingSprites()[jumpingIndex];
            //        ++jumpingIndex;
            //    }
            //}
        }

    }


    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, layermask);
        return hit.collider != null;
    }

    public bool ReturnHasPlayed() { return hasPlayed; }

    public void SetPlayerJumpVelocity(int velocity) { jumpVelocity = velocity; }
    public int GetNumJumpsThisTurn() { return numjumpsthisTurn; }
    public void SetNumJumpsThisTurn(int numjumps) { numjumpsthisTurn = numjumps; }
}
