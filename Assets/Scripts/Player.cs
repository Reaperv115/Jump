using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask layermask;
    BoxCollider2D bc2d;
    Rigidbody2D rb2d;

    SpriteRenderer spriteRenderer;
    Sprite[] jumpingSprites;
    Sprite[] playerSprites;
    Sprite standingSprite;

    TMP_Dropdown characterSelection;

    int jumpingIndex = 0;

    bool canJump = false;
    bool isPlaying = false;
    bool hasPlayed = false;

    Scene scene;

    // Start is called before the first frame update
    void Start()
    { 
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpingSprites = Resources.LoadAll<Sprite>("jumping");
        playerSprites = Resources.LoadAll<Sprite>("Players");
        scene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(this.gameObject);

        if (scene.name.Equals("MainMenu"))
            characterSelection = GameObject.Find("character selection").GetComponent<TMP_Dropdown>();
    }

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("MainMenu"))
        {
            if (!characterSelection)
            {
                characterSelection = GameObject.Find("character selection").GetComponent<TMP_Dropdown>();
                switch (characterSelection.value)
                {

                    case 0:
                        {
                            standingSprite = playerSprites[0];
                            break;
                        }
                    case 1:
                        {
                            standingSprite = playerSprites[1];
                            break;
                        }
                    case 2:
                        {
                            standingSprite = playerSprites[2];
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                switch (characterSelection.value)
                {

                    case 0:
                        {
                            standingSprite = playerSprites[0];
                            break;
                        }
                    case 1:
                        {
                            standingSprite = playerSprites[1];
                            break;
                        }
                    case 2:
                        {
                            standingSprite = playerSprites[2];
                            break;
                        }
                    default:
                        break;
                }
            }
            
        }
        if (scene.name.Equals("AboutGame"))
            Destroy(this.gameObject);
        

        if (isGrounded())
        {
            canJump = true;
            spriteRenderer.sprite = standingSprite;
        }
        if (isPlaying)
        {
            if (canJump)
            {
                if (Input.touchCount > 0)
                {
                    Touch t = Input.GetTouch(0);

                    if (t.phase == TouchPhase.Began)
                    {
                        float jumpVelocity = 15f;
                        rb2d.velocity = Vector2.up * jumpVelocity;
                        canJump = false;
                        if (standingSprite.name.Equals("ryan"))
                        {
                            if (jumpingIndex == 3)
                            {
                                spriteRenderer.sprite = jumpingSprites[jumpingIndex];
                                jumpingIndex = 0;
                            }
                            else
                            {
                                spriteRenderer.sprite = jumpingSprites[jumpingIndex];
                                ++jumpingIndex;
                            }
                        }
                    }
                }
            }
        }

        
    }

    public void setisPlaying(bool playing)
    {
        isPlaying = playing;
    }

    public bool returnhasPlayed()
    {
        return hasPlayed;
    }

    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, layermask);
        return hit.collider != null;
    }

    public bool getisPlaying()
    {
        return isPlaying;
    }
}
