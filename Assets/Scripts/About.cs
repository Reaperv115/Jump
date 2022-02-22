using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class About : MonoBehaviour
{
    Button about;

    // Start is called before the first frame update
    void Start()
    {
        about = GetComponent<Button>();
        about.onClick.AddListener(abouttheGame);
    }

    public void abouttheGame()
    {
        SceneManager.LoadScene("AboutGame");
    }
}
