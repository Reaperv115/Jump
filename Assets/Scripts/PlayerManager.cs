using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    GameObject playerGO, playerGOInst;
    Scene scene;

    Sprite[] jumpingSprites;
    Sprite[] standingSprites;

    [SerializeField]
    Transform playerPosition;
    string filePath = "Assets/Players";

    int numJumps;
    [HideInInspector]
    public int selectedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Trying to create multiple instances of player manager");
        standingSprites = Resources.LoadAll<Sprite>("Players/Standing");
        Debug.Log("num standing sprites: " + standingSprites.Length);

        playerGO = Resources.Load<GameObject>("playerGos/player");
        playerGOInst = Instantiate(playerGO, playerPosition.position, playerGO.transform.rotation);
        print(playerGOInst);
    }

    // Update is called once per frame
    void Update()
    {
        playerGOInst.GetComponent<SpriteRenderer>().sprite = standingSprites[selectedPlayer];


    }

    

    public GameObject GetPlayerGO() { return playerGOInst; }
    public Player GetPlayerRef() { return playerGOInst.GetComponent<Player>(); }
    public int GetNumofJumps() { return numJumps; }
    public void SetNumofJumps(int numjumps) { numJumps = numjumps; }
    public Sprite[] GetStandingSprites()
    {
        return standingSprites;
    }

    public void LoadJumpingSprites(int playerIndex)
    {

    }
}
