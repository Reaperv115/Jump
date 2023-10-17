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
            UIManager.Instance.GetReplayButton().SetActive(true);
            UIManager.Instance.GetBackToMainMenuButton().SetActive(true);
            UIManager.Instance.GetToggleAccoladesButton().SetActive(true);
            GameManager.instance.gamehasStarted = false;
            Destroy(PlayerManager.Instance.gameObject);
        }
    }

}
