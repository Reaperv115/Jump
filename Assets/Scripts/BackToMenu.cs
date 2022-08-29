using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void toMenu() { SceneManager.LoadScene("MainMenu"); }
}
