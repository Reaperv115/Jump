using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    Button back;
    // Start is called before the first frame update
    void Start()
    {
        back = GetComponent<Button>();
        back.onClick.AddListener(goBack);
    }

    public void goBack() => SceneManager.LoadScene("MainMenu");
}
