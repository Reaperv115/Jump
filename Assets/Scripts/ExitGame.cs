using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(exitGame);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
