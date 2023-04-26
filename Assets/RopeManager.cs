using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public static RopeManager instance;

    GameObject rope, ropeInst;
    [SerializeField]
    Transform ropestartingPosition;
    float ropeSpeed;

    Vector3 direction;

    Transform minHeight, maxHeight;

    bool ropeislowEnough;
    // Start is called before the first frame update
    void Start()
    {
        ropeSpeed = 0f;
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
            ropeislowEnough = false;

        if (ropeInst.transform.position.y > maxHeight.position.y)
            direction = Vector3.down;
        else if (ropeInst.transform.position.y < minHeight.position.y)
        {
            direction = Vector3.up;
            ropeislowEnough = true;
        }
        ropeInst.transform.Translate(direction * ropeSpeed * Time.deltaTime);

        //++numOfJumps;
        //if (numOfJumps == 5)
        //    ++SaveData.current.profile.numBronze;
        //if (numOfJumps == 15)
        //    ++SaveData.current.profile.numSilver;
        //if (numOfJumps == 50)
        //    ++SaveData.current.profile.numGold;
        //if (numOfJumps == 75)
        //    ++SaveData.current.profile.numPlat;
        //if (numOfJumps == 1000)
        //    ++SaveData.current.profile.numWhy;
    }

    public void SetRopeSpeed(float speed)
    {
        ropeSpeed = speed;
    }

    public bool GetIsRopeLowEnough() { return ropeislowEnough; }
}
