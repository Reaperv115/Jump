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
        // saving progress first, then
        // destroying player and playermanager instances
        // they will be remade when loading the main menu scene
        SerializationManager.Save("Data", SaveData.current);
        var obj = GameObject.Find("player(Clone)");
        Destroy(obj);
        if (PlayerManager.Instance != null)
            Destroy(PlayerManager.Instance);
        SceneManager.LoadScene("MainMenu");
    }
}
