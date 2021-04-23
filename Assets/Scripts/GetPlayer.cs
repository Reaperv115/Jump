using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetPlayer : MonoBehaviour
{
    static GameObject player;

    [SerializeField]
    Transform playerstartPos;

    private void Awake()
    {
        player = Resources.Load<GameObject>("Players/playerGOs/player");
        Instantiate(player, playerstartPos.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = playerstartPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject returnPlayer()
    {
        return player;
    }
}
