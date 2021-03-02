using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Accolades : MonoBehaviour
{
    Button accolades;
    // Start is called before the first frame update
    void Start()
    {
        accolades = GetComponent<Button>();
        accolades.onClick.AddListener(gotoAccolades);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotoAccolades()
    {
        SceneManager.LoadScene("Accolades");
    }
}
