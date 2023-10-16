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
        var options = GameObject.Find("Buttons").transform.GetChild(4).gameObject;
        options.SetActive(true);
        var choice = GameObject.Find("Buttons").transform.GetChild(2).gameObject;
        choice.SetActive(false);
    }
}
