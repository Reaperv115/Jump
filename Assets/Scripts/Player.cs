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
        DontDestroyOnLoad(this.gameObject);
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
                spriteRenderer.sprite = PlayerManager.Instance.GetStandingSprites()[PlayerManager.Instance.selectedPlayer];
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
        if (canJump)
        {


            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                if (t.phase == TouchPhase.Began)
                {
                    playimpactsoundEffect = true;
                    rb2d.velocity = Vector2.up * jumpVelocity;
                    canJump = false;
                    int num = Random.Range(0, PlayerManager.Instance.GetJumpingSprites().Length);
                    spriteRenderer.sprite = PlayerManager.Instance.GetJumpingSprites()[num];
                }
            }
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
