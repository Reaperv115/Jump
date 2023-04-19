using UnityEngine;
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
        GameManager.instance.SwitchScenes(true);
    }
}
