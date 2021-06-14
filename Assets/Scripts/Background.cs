using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Sprite[] background;

    Button about;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = new Color(0.0f, 0.0f, 255f);

        about = GameObject.Find("About").GetComponent<Button>();
        about.onClick.AddListener(learnAbout);
    }
    public void resetBackground() => spriteRenderer.sprite = background[0];

    public void learnAbout()
    {
        SceneManager.LoadScene("AboutGame");
    }
}
