using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class About : MonoBehaviour
{
    // takes you to the 'About Game' screenw hen the AboutGame button is pressed
    public void abouttheGame() { SceneManager.LoadScene("AboutGame"); }
}
