using UnityEngine;
using UnityEngine.UI;

public class ReplayGame : MonoBehaviour
{
    [SerializeField]
    GameObject backGround;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReloadGame);
    }

    public void ReloadGame()
    {
        // reset the game
        this.gameObject.SetActive(false);
        SerializationManager.Save("Data", SaveData.current);
        RopeManager.instance.ResetRope();
        UIManager.Instance.GetBasicModeButton().SetActive(true);
        UIManager.Instance.GetYourChoiceButton().SetActive(true);
        PlayerManager.Instance.GetPlayerRef().SetNumJumpsThisTurn(0);
        backGround.GetComponent<GameBackground>().ResetBackground();
        PlayerManager.Instance.GetPlayerRef().SetGotCaught(false);
    }
}
