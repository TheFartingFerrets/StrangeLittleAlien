using UnityEngine;

public enum PhysicsLevelState
{
    loading = 0,
    building,
    playing,
    complete
}

public class PhysicsLevelController : MonoBehaviour
{
    /*IMPORTANT*/
    private GameController gController;
    [SerializeField]
    private PhysicsLevelState LevelState = PhysicsLevelState.loading;
    public float LevelTimer = 10f;

    private Vector3 RollerStartPosition;

    [SerializeField]
    private PhysicsEditor Editor;

    [SerializeField]
    private Transform Roller;

    [SerializeField]
    private Transform Target;

    [SerializeField]
    private CanvasGroup ItemBankUI;
    bool Ended = false;

    private void Awake()
    {
#if UNITY_EDITOR
        try
        {
            gController = GameObject.FindObjectOfType<GameController>();
            gController.GameControlState = GameState.InLevel;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("<color=blue>" + e.Message + "Missing GameController - Loading levels will not work</color>");
        }
#endif

        Screen.orientation = ScreenOrientation.Portrait;
        RollerStartPosition = Roller.position;
        GameTimer.SetTimer(LevelTimer);
        ResetSim();
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Update()
    {
        float distance = Vector2.Distance(Roller.position, Target.position);

        if (distance <= 1f && !Ended)
        {
            Ended = true;
            CompleteLevel();
        }
    }

    public void StartStopLevel()
    {
        if (LevelState == PhysicsLevelState.building)
        {
            StartSim();
        }
        else if (LevelState == PhysicsLevelState.playing)
        {
            ResetSim();
        }
    }

    private void StartSim()
    {
        GameTimer.StartTimer();
        LevelState = PhysicsLevelState.playing;
        Lock();
        EnableRoller();
        ItemBankUI.ToggleCanvasGroup(false);
    }

    private void ResetSim()
    {
        //GameTimer.StopTimer();
        GameTimer.ResetTimer();
        LevelState = PhysicsLevelState.building;
        Unlock();
        DisableRoller();
    }

    public void CompleteLevel()
    {
        GameTimer.StopTimer();
        LevelState = PhysicsLevelState.complete;
        StopRoller();
		GameObject.FindObjectOfType<CompleteWindow> ().GetComponent<CompleteWindow> ().OnLevelComplete (GetComponent<PhysicsMoveableBank>().totalMoveables, GameTimer.GetTime(), true);
        //		GameData.Current.UpdateObjectives (2, true, true, false);
        //		GameData.Current.Save ();
    }

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    private void EnableRoller()
    {
        Roller.GetComponent<TrailRenderer>().enabled = true;
        Roller.GetComponent<Rigidbody2D>().isKinematic = false;
        Roller.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Roller.GetComponent<Rigidbody2D>().position = RollerStartPosition;
        Roller.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void DisableRoller()
    {
        Roller.GetComponent<TrailRenderer>().enabled = false;
        Roller.GetComponent<Rigidbody2D>().isKinematic = true;
        Roller.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Roller.GetComponent<Rigidbody2D>().position = RollerStartPosition;
        Roller.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void StopRoller()
    {
        Roller.GetComponent<Rigidbody2D>().isKinematic = true;
        Roller.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void Lock()
    {
        Editor.HideEditor();

        GameObject[] Moveable = GameObject.FindGameObjectsWithTag("Moveable");
        foreach (GameObject m in Moveable)
        {
            m.SendMessage("Lock", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void Unlock()
    {
        Editor.HideEditor();
        GameObject[] Moveable = GameObject.FindGameObjectsWithTag("Moveable");
        foreach (GameObject m in Moveable)
        {
            m.SendMessage("Unlock", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void OnGameTimerUp()
    {
        Debug.Log("Timer Up");
        CompleteLevel();
    }

    /* Level Controller Events for UI Elements */

    [ExecuteInEditMode]
    public void ItemBankToggle()
    {
        if (LevelState == PhysicsLevelState.building)
        {
            Debug.Log("true");
            ItemBankUI.ToggleCanvasGroup();

        }
    }
}