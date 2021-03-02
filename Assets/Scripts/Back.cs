using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    Button back;
    // Start is called before the first frame update
    void Start()
    {
        back = GetComponent<Button>();
        back.onClick.AddListener(goBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
