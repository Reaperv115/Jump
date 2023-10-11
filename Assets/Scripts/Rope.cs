using UnityEngine;

public class Rope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (RopeManager.instance.GetIsRopeLowEnough())
        {
            RopeManager.instance.SetRopeSpeed(0f);
            if (PlayerManager.Instance.GetNumofJumps() > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = PlayerManager.Instance.GetNumofJumps();
            //UIManager.Instance.GetReplayBtn().SetActive(true);
            //UIManager.Instance.GetBackToMainMenuBtn().SetActive(true);
            //UIManager.Instance.GetToggleAccoladesBtn().SetActive(true);
            GameManager.instance.SetGameCountDown(3f);
            GameManager.instance.SetGameHasStarted(false);
        }
    }

}
