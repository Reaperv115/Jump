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
        GameObject player = GameObject.Find("player");
        Destroy(player);
        SceneManager.LoadScene("MainMenu");
    }
}
