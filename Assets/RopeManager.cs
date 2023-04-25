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
    // Start is called before the first frame update
    void Start()
    {
        ropeSpeed = 0f;
        if (instance == null)
            instance = this;
        else
        {
            Debug.LogError("trying to create multiple instances of rope manager");
        }
        rope = Resources.Load<GameObject>("rope");
        ropeInst = Instantiate(rope, ropestartingPosition.position, rope.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        ropeInst.transform.Translate(Vector3.up * ropeSpeed);
    }

    public void SetRopeSpeed(float speed)
    {
        ropeSpeed = speed;
    }
}
