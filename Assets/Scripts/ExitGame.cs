using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    private void Awake() { GetComponent<Button>().onClick.AddListener(QuitGame); }
    public void QuitGame() 
    {
        SerializationManager.Save("Data", SaveData.current);
        Application.Quit();
    }
}
