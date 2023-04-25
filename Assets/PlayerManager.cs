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

    [SerializeField]
    Transform playerPosition;
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
}
