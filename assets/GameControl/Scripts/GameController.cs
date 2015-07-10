using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
    private static GameController instance;
    public static GameController Current
    {
        get
        {
            if( !instance)
            {
                instance = GameObject.FindObjectOfType<GameController>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }


    public GameState GameControlState = GameState.Initializing;

    //[SerializeField]
    GameData gData = new GameData();

    [SerializeField]
    public string WorldPrefix = "None";
    [SerializeField]
    public int LevelID = 0;

    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;        

        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != instance)
                Destroy(this.gameObject);
        }
        gData = GameData.Load();

    }
    void Start()
    {        
        GameControlState = GameState.Initializing;
    }
    public void MoveToMain()
    {
        gData = GameData.Load();

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        GameControlState = GameState.WorldSelect;

        Application.LoadLevel("Main");

        GameControlState = GameState.WorldSelect;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if( GameControlState == GameState.Initializing || GameControlState == GameState.WorldSelect)
            {
                Debug.Log("Quit");
                QuitApp();
            }
            else if( GameControlState == GameState.LevelSelect)
            {
                ExitToWorldSelect();
            }else if( GameControlState == GameState.InLevel)
            {
                ExitToLevelSelect();
            }
        }


        //if( GameControlState != GameState.Loading || GameControlState != GameState.Options)
        //{
        //    if (GameControlState == GameState.Initializing || GameControlState == GameState.WorldSelect)
        //    {
        //        if (Input.GetKeyDown(KeyCode.Escape))
        //        {
        //            QuitApp();
        //        }
        //    }
        //    else
        //    {
        //        ExitToWorldSelect();
        //        //ExitToMain();
        //    }
        //}
    }
    IEnumerator SetWorld(string Prefix)
    {
        GameControlState = GameState.Loading;

        WorldPrefix = Prefix;

        GameObject.FindObjectOfType<LevelSelectWindow>().LoadWorldData(GetWorldData);

        yield return null;
        yield return null;
        
        GameObject.FindObjectOfType<LevelSelectWindow>().GetComponent<Window>().Open();
        
        GameControlState = GameState.LevelSelect;
    }
    public void SetLevel(int Level)
    {
        LevelID = Level;
        LoadLevel();
    }

    public void ExitToLevelSelect()
    {
        GameControlState = GameState.Loading;
        StopAllCoroutines();
        StartCoroutine("ToLevelSelect");
    }
    public void ExitToWorldSelect()
    {
        GameControlState = GameState.Loading;
        StopAllCoroutines();
        StartCoroutine("ToWorldSelect");
    }

    public void SoftWorldSelect()
    {
        WorldPrefix = "None";
        LevelID = 0;
        GameObject.FindObjectOfType<LevelSelectWindow>().GetComponent<Window>().Toggle(false);
        GameObject.FindObjectOfType<LevelSelectWindow>().ForceClear();
        GameControlState = GameState.WorldSelect;
    }
    IEnumerator ToLevelSelect()
    {
        Application.LoadLevel("Main");

        yield return null;
        yield return null;

        gData = GameData.Load();

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        LevelID = 0;

        GameObject.FindObjectOfType<LevelSelectWindow>().GetComponent<Window>().Open();

        GameObject.FindObjectOfType<LevelSelectWindow>().LoadWorldData(GetWorldData);


        GameControlState = GameState.LevelSelect;
    }


    IEnumerator ToWorldSelect()
    {
        Application.LoadLevel("Main");

        yield return null;

        gData = GameData.Load();

        Screen.orientation = ScreenOrientation.LandscapeLeft;
        
        WorldPrefix = "None";

        LevelID = 0;

        GameObject.FindObjectOfType<LevelSelectWindow>().GetComponent<Window>().Toggle(false);

        yield return null;

        GameObject.FindObjectOfType<LevelSelectWindow>().ForceClear();

        GameControlState = GameState.WorldSelect;
    }
    public List<Level> GetWorldData
    {
        get
        {
            if( WorldPrefix == "Maths")
            {
                return gData.MathsWorld;
            }
            else if( WorldPrefix == "Physics")
            {
                return gData.PhysicsWorld;
            }
            else if( WorldPrefix == "Collect")
            {
                return gData.CollectWorld;
            }
            else
            {
                return gData.ReflexWorld;
            }   
        }
    }

    public void LoadLevel()
    {
        GameControlState = GameState.Loading;
        Debug.Log("Loading Level :" + WorldPrefix + "_" + LevelID);
        StopAllCoroutines();
        Application.LoadLevel(WorldPrefix + "_" + LevelID);
    }
    public void LoadNextLevel()
    {
        GameControlState = GameState.Loading;

        if( LevelID >= 10)
        {
            return;
        }
        else
        {
            LevelID++;
            Debug.Log("Loading next level" + WorldPrefix + "_" + LevelID);

            StopAllCoroutines();
            Application.LoadLevel(WorldPrefix + "_" + LevelID);
        }
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

	public int GetWorld
	{
		get{
            Debug.Log(WorldPrefix);
			if (WorldPrefix == "Math" || WorldPrefix == "Maths"){
				return 0;
			}else if( WorldPrefix == "Physics"){
				return 1;
			}else if( WorldPrefix == "Collect"){
				return 2;
			}else{
				return 3;
			}
		}
	}
}
public enum GameState
{
    Initializing,
    WorldSelect,
    LevelSelect,
    Loading,
    InLevel,
    Options,
}
public enum WorldPrefix
{
    Maths = 0,
    Physics,
    Collect,
    Reflex
}