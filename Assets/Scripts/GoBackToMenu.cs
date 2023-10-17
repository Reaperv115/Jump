using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoBackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoBacktoMenu);
    }

    public void GoBacktoMenu()
    {
        var obj = GameObject.Find("player(Clone)");
        if (obj)
            Destroy(obj);
        if (PlayerManager.Instance != null)
            Destroy(PlayerManager.Instance);
        SceneManager.LoadScene("MainMenu");
    }
}
