using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRegRopeEx : MonoBehaviour
{
    Button showbaseEx;
    RawImage baseropeEx;
    Texture baseropeexPic;

    bool showbaseExample;

    // Start is called before the first frame update
    void Start()
    {
        showbaseExample = false;
        baseropeEx = GameObject.Find("Base Jump Rope").GetComponent<RawImage>();
        showbaseEx = GameObject.Find("Regular Button").GetComponent<Button>();
        Debug.Log(showbaseEx);
        showbaseEx.onClick.AddListener(ShowBaseExample);
        baseropeexPic = Resources.Load<Texture>("Jumpy base jump rope");
        baseropeEx.texture = baseropeexPic;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(showbaseExample);
        baseropeEx.gameObject.SetActive(showbaseExample);
    }

    public void ShowBaseExample()
    {
        showbaseExample = !showbaseExample;
    }
}
