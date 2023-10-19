using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    GameObject canvas;

    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("trying to create multiple instances of UI Manager");
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");
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
        scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("Game"))
            canvas = GameObject.Find("Canvas");
        else
            canvas = GameObject.Find("Canvas");

    }

    // getting game canvas UI elements
    public GameObject GetBasicModeOptions()      { return FindCanvasObject(canvas, "Options");     }
    public GameObject GetYourChoiceButton()      { return FindCanvasObject(canvas, "Choice");      }
    public GameObject GetRopeSpeedSlider()       { return FindCanvasObject(canvas, "Slider");      }

    public GameObject GetBasicModeButton()       { return FindCanvasObject(canvas, "Basic");       }
    public GameObject GetPersonalBestDisplay()   { return FindCanvasObject(canvas, "Best");        }
    public GameObject GetJumpsDisplay()          { return FindCanvasObject(canvas, "Jumps");       }

    public GameObject GetBackToMenuButton()      { return FindCanvasObject(canvas, "Back");        }

    public GameObject GetToggleAccoladesButton() { return FindCanvasObject(canvas, "Accolades");   }

    public GameObject GetCountDownTimer()        { return FindCanvasObject(1, canvas, "Countdown");}

    public GameObject GetReplayButton()          { return FindCanvasObject(canvas, "Replay");      }

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
