using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineBar : MonoBehaviour
{
    public TimelineManager timelineManager;
    public LineRenderer timelinePlaybackBar;
    public Transform timelineStartPos;
    public Transform timelineEndPos;
    private Vector3 timelineBarDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimelineBarRender(); 
    }

    void TimelineBarRender()
    {
        Debug.Log("test");
        timelinePlaybackBar.SetPosition(0, timelineStartPos.position);
        double timelineDistance = (timelineManager.playableGraph.GetRootPlayable(0).GetTime() / timelineManager.playableGraph.GetRootPlayable(0).GetDuration()) * Vector3.Distance(timelineStartPos.position, timelineEndPos.position);
        float result = (float)timelineDistance;
        if (float.IsPositiveInfinity(result))
        {
            result = float.MaxValue;
        }
        else if (float.IsNegativeInfinity(result))
        {
            result = float.MinValue;
        }
        timelineBarDirection = (timelineEndPos.position - timelineStartPos.position).normalized * result + timelineStartPos.position;
        timelinePlaybackBar.SetPosition(1, timelineBarDirection);
    }

}
