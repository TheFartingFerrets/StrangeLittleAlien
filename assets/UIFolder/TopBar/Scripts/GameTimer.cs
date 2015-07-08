using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class GameTimer : MonoBehaviour 
{
    public float TimerTime = 0.0f;
    public string TimerText;  
    
    public Text tTimerTime;
    public Text tTimerText;
    
    private static string timeText = "";
    private static float time = 0f;

    private static float StartTime = 0.0f;
    public static float TimeScale = 1f;

    private static bool running = false;
    public static void SetTimer( float TimeAmount)
    {
        StartTime = TimeAmount;
        time = TimeAmount;
    }
    public static void SetText( string _Text)
    {
        timeText = _Text;
    }
    public static void UpdateTimer(float Amount)
    {
        time = Amount;
    }
    public static void StartTimer()
    {
        running = true;
    }
    public static void StopTimer()
    {
        running = false;
    }
    public static void ResetTimer()
    {
        time = StartTime;
        running = false;
    }
    public static void TimeUp()
    {
        StopTimer();
        //Send message to tell time is up
        GameObject.FindGameObjectWithTag("LevelController").SendMessage("OnGameTimerUp", SendMessageOptions.DontRequireReceiver);
    }
    public static float GetTime()
    {
        return time;
    }
    void Update()
    {
        Time.timeScale = TimeScale;
        if (running)
        {
            time -= 1f * Time.deltaTime;
        }
        if (running && time <= 0.0f)
        {
            TimeUp();
        }

        SetText(TimerText);
        tTimerTime.text = time.ToString("F0");
        tTimerText.text = timeText.ToString();
    }
}   
