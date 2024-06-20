using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // layermask used in
    // IsGrounded check
    [SerializeField]
    LayerMask layermask;

    // different components
    //found on the player GO
    BoxCollider2D bc2d;
    Rigidbody2D rb2d;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    // bools for controlling game flow
    bool canJump = false;
    bool playimpactsoundEffect = false;
    bool gotCaught = false;

    // how high to jump
    float jumpVelocity;

    // how many jumps this turn
    int numJumps, personalbestnumJumps;
    

    // Start is called before the first frame update
    void Start()
    {
        // ensuring the object isn't destroyed
        // when switching scenes
        DontDestroyOnLoad(this.gameObject);

        // getting various components of the player
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        jumpVelocity = 15f;
        numJumps = 0;
    }

    void Update()
    {
        if (!GameManager.instance.gamehasStarted)
            return;
        // if the player is grounded
        if (IsGrounded())
        {
            // show standing sprite
            spriteRenderer.sprite = PlayerManager.Instance.GetStandingSprites()[PlayerManager.Instance.selectedPlayer];
            if (playimpactsoundEffect)
            {
                // play impact sound effect
                // since player just landed
                audioSource.Play();
                playimpactsoundEffect = false;
            }
            else
                audioSource.Stop();
            // player has fully hit the ground
            // so they can jump again
            canJump = true;
        }
        else
            spriteRenderer.sprite = PlayerManager.Instance.GetJumpingSprites()[PlayerManager.Instance.selectedjumpingSprite];
        // if the player can jump
        if (canJump)
        {
            // if the touch count is more than 0
            if (Input.touchCount <= 0)
                return;
            // jump and choose a random jump sprite to briefly display
            playimpactsoundEffect = true;
            rb2d.velocity = Vector2.up * jumpVelocity;
            canJump = false;
            PlayerManager.Instance.selectedjumpingSprite = Random.Range(0, PlayerManager.Instance.GetJumpingSprites().Length);
            
        }

    }

    // check to see if the player is "grounded"
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, layermask);
        return hit.collider != null;
    }
    public int GetNumJumpsthisTurn() { return numJumps; }
    public void SetNumJumpsThisTurn(int numjumps) { numJumps = numjumps; }
    public int GetPersonalBestNumJumps() {return personalbestnumJumps;}
    public void SetNumPersonalBestJumps(int personalbest) { personalbestnumJumps = personalbest; }
    public bool GetGotCaught() { return gotCaught; }
    public void SetGotCaught(bool caught) { gotCaught = caught; }
}
