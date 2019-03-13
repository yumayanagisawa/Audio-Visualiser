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
    public Camera mainCamera;

    public GameObject testObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timelineManager.playableGraphIsSet)
        {
            TimelineBarRender();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 point = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane)); //mainCamera.nearClipPlane
            SetTimlineTime(point);
        }
    }

    void TimelineBarRender()
    {
        Debug.Log("test");
        timelinePlaybackBar.SetPosition(0, timelineStartPos.position);
        double timelineDistance = 
            (timelineManager.playableGraph.GetRootPlayable(0).GetTime() / 
            timelineManager.playableGraph.GetRootPlayable(0).GetDuration()) * Vector3.Distance(timelineStartPos.position, timelineEndPos.position);
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

    void SetTimlineTime(Vector3 point)
    {
        //Instantiate(testObject, point, Quaternion.identity);
        Debug.Log(point);
        if (point.x > timelineEndPos.position.x)
        {
            point.x = timelineEndPos.position.x;
        }
        else if (point.x < timelineStartPos.position.x)
        {
            point.x = timelineStartPos.position.x;
        }
        Vector3 finalPoint;
        RaycastHit hit;
        //Vector3 testVector = new Vector3(point.x,point.z, mainCamera.gameObject.transform.position.z);
        if (Physics.Raycast(point, testObject.transform.forward, out hit, 50f))
        {
            finalPoint = hit.point;
            //Instantiate(testObject, finalPoint, Quaternion.identity);
        }
        else
        {
            return;
        }
        Debug.Log("Point" + point);
        //distance1 = distance of pointer from startPos
        //distance2 = distance1 / startPos <> endPos distance
        Vector3 point1 = new Vector3(finalPoint.x, 0, 0);
        Vector3 point2 = new Vector3(timelineStartPos.position.x, 0, 0);
        float distance1 = Vector3.Distance(point1, point2);
        float  distance2 = distance1 / Vector3.Distance(timelineStartPos.position, timelineEndPos.position);
        double distance3 = distance2 * timelineManager.playableGraph.GetRootPlayable(0).GetDuration();
        //Vector3 c = new Vector3(timelineStartPos.position.x, 0,0) + new Vector3(distance1, 0, 0);
        //double answer = (double)c.x * (double)Vector3.Distance(timelineStartPos.position, timelineEndPos.position) * timelineManager.playableGraph.GetRootPlayable(0).GetDuration();

        //float distance2 = distance1 / (timelineEndPos.position.x - timelineStartPos.position.x);
       // double timelineDistance = distance2 * timelineManager.playableGraph.GetRootPlayable(0).GetDuration();
        //double time = point.x / e
        //fraction of startPos and endPos
        //position of pointer / distance
        timelineManager.playableGraph.GetRootPlayable(0).SetTime(distance3);
    }

}
