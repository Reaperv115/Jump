using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rope : BaseRope
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (RopeManager.instance.GetIsRopeLowEnough() && collision.transform.name.Equals("player(Clone)"))
        {
            print("rope tripped you");
        }
    }

}
