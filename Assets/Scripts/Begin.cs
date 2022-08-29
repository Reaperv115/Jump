using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    public void beginGame() => SceneManager.LoadScene("Game");
}
