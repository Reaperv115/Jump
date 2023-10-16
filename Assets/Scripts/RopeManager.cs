using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RopeManager : BaseRope
{
    public static RopeManager instance;

    GameObject rope, ropeInst;
    [SerializeField]
    Transform ropestartingPosition;

    Vector3 direction;

    Transform minHeight, maxHeight;

    bool ropeislowEnough;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("trying to create multiple instances of rope manager");

        rope = Resources.Load<GameObject>("rope");
        ropeInst = Instantiate(rope, ropestartingPosition.position, rope.transform.rotation);
        minHeight = GameObject.Find("min height").GetComponent<Transform>();
        maxHeight = GameObject.Find("max height").GetComponent<Transform>();
        direction = Vector3.up;

        ropeislowEnough = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ropeislowEnough && ropeInst.transform.position.y > minHeight.position.y)
        {
            ropeislowEnough = false;
            PlayerManager.Instance.SetNumofJumps(PlayerManager.Instance.GetNumofJumps() + 1);
            switch (PlayerManager.Instance.GetNumofJumps()) 
            {
                case 5:  ++SaveData.current.profile.numBronze; break;
                case 15: ++SaveData.current.profile.numSilver; break;
                case 50: ++SaveData.current.profile.numGold; break;
                case 75: ++SaveData.current.profile.numPlat; break;
                case 1000: ++SaveData.current.profile.numWhy; break;
                case 42069: ++SaveData.current.profile.numGetLit; break;
                default: break;
            }
            if (PlayerManager.Instance.GetNumofJumps() == 5)
                ++SaveData.current.profile.numBronze;
            if (PlayerManager.Instance.GetNumofJumps() == 15)
                ++SaveData.current.profile.numSilver;
            if (PlayerManager.Instance.GetNumofJumps() == 50)
                ++SaveData.current.profile.numGold;
            if (PlayerManager.Instance.GetNumofJumps() == 75)
                ++SaveData.current.profile.numPlat;
            if (PlayerManager.Instance.GetNumofJumps() == 1000)
                ++SaveData.current.profile.numWhy;
            if (PlayerManager.Instance.GetNumofJumps() == 42069)
                ++SaveData.current.profile.numGetLit;
        }

        if (ropeInst.transform.position.y > maxHeight.position.y)
            direction = Vector3.down;
        else if (ropeInst.transform.position.y < minHeight.position.y)
        {
            direction = Vector3.up;
            ropeislowEnough = true;
        }

        if (GameManager.instance.pregamecountDown <= 0f)
        {
            ropeInst.transform.Translate(direction * ropeSpeed * Time.deltaTime);
        }


    }

    public void SetRopeSpeed(float speed)
    {
        ropeSpeed = speed;
    }

    public bool GetIsRopeLowEnough() { return ropeislowEnough; }
}
