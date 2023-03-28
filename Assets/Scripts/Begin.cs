using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    public void BeginGame() => SceneManager.LoadScene("Game");
}
