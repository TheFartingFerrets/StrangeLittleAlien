using UnityEngine;
using System.Collections;

public enum CollectLevelState
{
	loading = 0,
	building,
	playing,
	complete
}

public class CollectLevelController : MonoBehaviour
{
	/*IMPORTANT*/
	private GameController gController;
	
	[SerializeField]
	private CollectLevelState LevelState = CollectLevelState.loading;
	
	public float LevelTimer = 10f;
	
	public int MaxPickups = 26;

	public GameObject alienPlayer;



	void Start(){

		alienPlayer = GameObject.FindGameObjectWithTag ("Player");
		GameTimer.StartTimer();
	}
	
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
		GameTimer.SetTimer(LevelTimer);
		//DisablePlayer ();
		LevelState = CollectLevelState.building;
	}
	
	private void Update()
	{
		if( Counter.Amount >= MaxPickups)
		{
			CompleteLevel();
		}
	}

	public void StartStopLevel()
	{
		if (LevelState == CollectLevelState.building)
		{
			StartSim();
		}
		else if (LevelState == CollectLevelState.playing)
		{
			ResetSim();
		}
	}
	
	private void StartSim()
	{

		LevelState = CollectLevelState.playing;
		EnablePlayer();
		//DisablePlayer();
	}
	
	private void ResetSim()
	{
		//GameTimer.StopTimer();
		GameTimer.ResetTimer();
		LevelState = CollectLevelState.building;
		DisablePlayer();
		//EnablePlayer();
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void CompleteLevel()
	{
		GameTimer.StopTimer();
		LevelState = CollectLevelState.complete;
		StopPlayer();

		bool y = (Counter.Amount >= MaxPickups) ? true : false;
		
 		//GameObject.FindObjectOfType<CompleteWindow>().SendMessage("OnLevelComplete");
		GameObject.FindObjectOfType<CompleteWindow> ().GetComponent<CompleteWindow> ().OnLevelComplete (GameTimer.GetTime (), GameTimer.GetTime(), y);
	}
	
	public void ResetLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	private void EnablePlayer()
	{
		alienPlayer.GetComponent<PlayerController> ().enabled = true;
	}
	
	private void DisablePlayer()
	{
		alienPlayer.GetComponent<PlayerController> ().enabled = false;
	}
	
	private void StopPlayer()
	{

	}
	
	public void OnGameTimerUp()
	{
		Debug.Log("Timer Up");
		CompleteLevel();
	}
}