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
            PlayerManager.Instance.GetPlayerRef().SetGotCaught(true);
            print(PlayerManager.Instance.GetPlayerRef().GetGotCaught());

        }
    }

}
