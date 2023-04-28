using UnityEngine;
using UnityEngine.UI;

public class BasicMode : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }
    public void NormalMode()
    {
        gameObject.SetActive(false);
        UIManager.Instance.GetBasicModeOptions().SetActive(true);
        UIManager.Instance.GetYourChoiceBtn().SetActive(false);
    }
}
