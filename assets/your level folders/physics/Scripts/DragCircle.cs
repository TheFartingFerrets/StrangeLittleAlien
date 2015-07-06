using UnityEngine;
using System.Collections;

public class DragCircle : MonoBehaviour 
{
    public Vector3 SetupPos;
    public Vector3 startPos;
    public Transform Target;

    void Awake()
    {
        SetupPos = transform.localPosition;
    }
    public void SetPos()
    {
        transform.localPosition = SetupPos;
    }
   
    public void SetStartPos()
    {

        startPos = transform.parent.position;
    }

    public void UpdateDragPosition()
    {
        Target = transform.parent.GetComponent<PhysicsEditor>().Target;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 AllowedDistanceMax = mousePos - startPos;
        AllowedDistanceMax = Vector3.ClampMagnitude(AllowedDistanceMax, 2f);
        
        Vector3 AllowedDistanceMin = mousePos - startPos;
        AllowedDistanceMin = Vector3.ClampMagnitude(AllowedDistanceMin, 1.9f);

        Vector3 AllowedDistance = Vector3.zero;
        AllowedDistance = new Vector3(Mathf.Clamp(AllowedDistance.x, AllowedDistanceMin.x, AllowedDistanceMax.x),
                                        Mathf.Clamp(AllowedDistance.y, AllowedDistanceMin.y, AllowedDistanceMax.y),
                                        0);


        //Vector3 AllowedDistance = mousePos - startPos;
        //AllowedDistance = Vector3.ClampMagnitude(AllowedDistance, 2f);

        float angle = Mathf.Atan2(AllowedDistance.x, AllowedDistance.y) * Mathf.Rad2Deg;
        Target.rotation = Quaternion.AngleAxis(-(angle + 90f), Vector3.forward);
        transform.position = startPos + AllowedDistance;


        //Vector3 RotationPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //RotationPosition.z = transform.position.z;

        //Vector3 dir = Target.position - RotationPosition;
        //float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        ////angle = Mathf.Round(angle / 10f) * 10f;

        //Target.rotation = Quaternion.AngleAxis(-(angle + 90f), Vector3.forward);

        //Vector3 allowedDistance = RotationPosition - RotatorPos;
        //allowedDistance = Vector3.ClampMagnitude(allowedDistance, 2f);
        //Rotator.position = RotatorPos + allowedDistance;

    }
}
