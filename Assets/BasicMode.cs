using UnityEngine;
using UnityEngine.UI;

public class BasicMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(NormalMode);
    }
    public void NormalMode()
    {
        gameObject.SetActive(false);
        UIManager.Instance.GetBasicModeOptions().SetActive(true);
        UIManager.Instance.GetYourChoiceBtn().SetActive(false);
    }
}
