using UnityEngine;

public class HasPlayed : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
