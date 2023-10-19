using UnityEngine;

public class BasicMode : MonoBehaviour
{
    public void NormalMode()
    {
        // begin the game with either slow, medium, or fast modes
        gameObject.SetActive(false);
        var options = GameObject.Find("Buttons").transform.GetChild(4).gameObject;
        options.SetActive(true);
        var choice = GameObject.Find("Buttons").transform.GetChild(2).gameObject;
        choice.SetActive(false);
    }
}
