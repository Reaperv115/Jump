using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    Button returntoMenu;

    // Start is called before the first frame update
    void Start()
    {
        returntoMenu = GetComponent<Button>();
        returntoMenu.onClick.AddListener(toMenu);
    }

    // Update is called once per frame
    public void toMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
