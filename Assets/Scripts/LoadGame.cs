using TMPro;
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
        UIManager.Instance.SetIsInstantiated(false);
        SceneManager.LoadScene("Game");
    }
}
