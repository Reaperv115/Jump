using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    Button startGame;

    GameObject characterSelection;
    // Start is called before the first frame update
    void Start()
    {
        startGame = GetComponent<Button>();
        startGame.onClick.AddListener(beginGame);


    }

    public void beginGame()
    {
        SceneManager.LoadScene("Game");
        
    }
}
