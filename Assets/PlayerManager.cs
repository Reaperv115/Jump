using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    GameObject playerGO, playerGOInst;
    Scene scene;

    Sprite[] playerSprites;
    Sprite[] jumpingSprites;

    [SerializeField]
    Transform playerPosition;

    int numJumps;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Trying to create multiple instances of player manager");

        playerGO = Resources.Load<GameObject>("Players/playerGos/player");
        playerGOInst = Instantiate(playerGO, playerPosition.position, playerGO.transform.rotation);

        playerSprites = Resources.LoadAll<Sprite>("Players");
        playerGOInst.GetComponent<SpriteRenderer>().sprite = playerSprites[0];

        jumpingSprites = Resources.LoadAll<Sprite>("jumping");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.HasSwitchedScenes())
        {
            scene = SceneManager.GetActiveScene();
            switch (scene.name)
            {
                case "MainMenu":
                    playerGOInst.GetComponent<SpriteRenderer>().sprite = playerSprites[UIManager.Instance.GetCharacterSelectionDrpDwn().value];
                    break;
                case "Game":
                    playerGOInst.GetComponent<SpriteRenderer>().sprite = playerSprites[UIManager.Instance.GetPlayerCharacterChoice()];
                    break;
                default:
                    break;
            }
        }
        
        
    }

    public GameObject GetPlayerGO() { return playerGOInst; }
    public Player GetPlayerRef() { return playerGOInst.GetComponent<Player>(); }
    public Sprite[] GetPlayerSprites() { return playerSprites; }
    public Sprite[] GetJumpingSprites() { return jumpingSprites; }
    public int GetNumofJumps() { return numJumps; }
    public void SetNumofJumps(int numjumps) { numJumps = numjumps; }
}
