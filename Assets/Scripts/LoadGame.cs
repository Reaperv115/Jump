using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadGameScene);
    }

    public void LoadGameScene()
    {
        // loading game scene and loading the jumping sprites
        // for the selected character
        PlayerManager.Instance.SetGameLoaded(true);
        SceneManager.LoadScene("Game");
    }
}
