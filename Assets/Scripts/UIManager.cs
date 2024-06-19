using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    GameObject go_canvas, go_prevCanvas;

    Scene s_scene, s_prevScene;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("trying to create multiple instances of UI Manager");
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");
        go_canvas = GameObject.Find("Canvas");
        s_scene = SceneManager.GetActiveScene();
        s_prevScene = s_scene;
    }

    // Update is called once per frame
    void Update()
    {
        //bring up End-Of-Game UI
        if (PlayerManager.Instance.GetPlayerRef().GetGotCaught())
        {
            GetReplayButton().SetActive(true);
            GetBackToMenuButton().SetActive(true);
            GetToggleAccoladesButton().SetActive(true);
        }

        // get the active canvas based on the scene
        s_scene = SceneManager.GetActiveScene();
        if (s_scene != s_prevScene)
        {
            go_canvas = GameObject.Find("Canvas");
            go_prevCanvas = go_canvas;
            s_prevScene = s_scene;
        }
        

    }

    // getting game canvas UI elements
    public GameObject GetBasicModeOptions()      { return FindCanvasObject(go_canvas, "Options");     }
    public GameObject GetYourChoiceButton()      { return FindCanvasObject(go_canvas, "Choice");      }
    public GameObject GetRopeSpeedSlider()       { return FindCanvasObject(go_canvas, "Slider");      }

    public GameObject GetBasicModeButton()       { return FindCanvasObject(go_canvas, "Basic");       }
    public GameObject GetPersonalBestDisplay()   { return FindCanvasObject(go_canvas, "Best");        }
    public GameObject GetJumpsDisplay()          { return FindCanvasObject(go_canvas, "Jumps");       }

    public GameObject GetBackToMenuButton()      { return FindCanvasObject(go_canvas, "Back");        }

    public GameObject GetToggleAccoladesButton() { return FindCanvasObject(go_canvas, "Accolades");   }

    public GameObject GetCountDownTimer()        { return FindCanvasObject(1, go_canvas, "Countdown");}

    public GameObject GetReplayButton()          { return FindCanvasObject(go_canvas, "Replay");      }

    // functions to find objects inside the canvas
    private GameObject FindCanvasObject(GameObject canv, string obj)
    {
        int i, val = 0;
        for (i = 0; i < canv.transform.GetChild(1).transform.childCount; ++i)
            if (canv.transform.GetChild(1).transform.GetChild(i).name.Contains(obj))
            {
                val = i;
                i = canv.transform.GetChild(1).transform.childCount;
            }
        return canv.transform.GetChild(1).transform.GetChild(val).gameObject;
    }
    private GameObject FindCanvasObject(int childIndex, GameObject canv, string obj)
    {
        int i, val = 0;
        for (i = 0; i < canv.transform.GetChild(childIndex).transform.childCount; ++i)
            if (canv.transform.GetChild(childIndex).transform.GetChild(i).name.Contains(obj))
            {
                val = i;
                i = canv.transform.GetChild(childIndex).transform.childCount;
            }
        return canv.transform.GetChild(childIndex).transform.GetChild(val).gameObject;
    }
}
