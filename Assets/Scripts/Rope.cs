using UnityEngine;

public class Rope : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        // checking to see if the player got caught by the rope
        if (RopeManager.instance.GetIsRopeLowEnough())
        {
            PlayerManager.Instance.GetPlayerRef().SetGotCaught(true);
            print(PlayerManager.Instance.GetPlayerRef().GetGotCaught());
        }
    }

}
