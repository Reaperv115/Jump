using UnityEngine;

public class DisplayDistractions : MonoBehaviour
{

    GameObject spiderDistraction, instantiatedspiderDistraction;
    GameObject manager;

    // the spot for the spider distraction to go
    Vector2 destination;

    float distractionTimer = 6.0f;
    float spawnY, destspawnY;
    float spawnX, destspawnX;


    private void Start()
    {
        spiderDistraction = Resources.Load<GameObject>("spider");
        manager = GameObject.Find("background");
    }

    // Update is called once per frame
    void Update()
    {

        if (manager.GetComponent<GameManager>().GetPlayer().GetComponent<Player>().GetIsPlaying())
        {
            if (distractionTimer <= 0.0f)
            {
                Activate();
                destination = new Vector2(destspawnX, destspawnY);
                distractionTimer = 6.0f;
            }
            else distractionTimer -= Time.deltaTime;

            if (instantiatedspiderDistraction)
            {
                instantiatedspiderDistraction.transform.position = Vector3.MoveTowards(instantiatedspiderDistraction.transform.position, destination, .1f);
                if (Vector3.Distance(instantiatedspiderDistraction.transform.position, destination) < .2f) { Deactivate(); }
            }
        }
    }

    void Activate()
    {
        spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        spawnX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        destspawnX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        destspawnY = Random.Range(Camera.main.ScreenToViewportPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

        instantiatedspiderDistraction = Instantiate(spiderDistraction, new Vector2(spawnX, spawnY), spiderDistraction.transform.rotation);
    }
    void Deactivate() { Destroy(instantiatedspiderDistraction); }
}
