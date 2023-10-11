using UnityEngine;
using UnityEngine.UI;

public class BasicMode : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //GetComponent<Button>().onClick.AddListener(NormalMode);
    }
    public void NormalMode()
    {
        gameObject.SetActive(false);
        var options = UIManager.Instance.GetBasicModeOptions();
        options.transform.GetChild(0).gameObject.SetActive(true);
        options.transform.GetChild(1).gameObject.SetActive(true);
        options.transform.GetChild(2).gameObject.SetActive(true);
        var choice = UIManager.Instance.GetYourChoiceButton();
        choice.SetActive(false);
    }
}
