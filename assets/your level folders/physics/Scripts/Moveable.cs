using System;
using TouchScript.Gestures;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public bool CanMove = false;
    public bool HasPower = false;
    public float BasePower = 1;
    public Vector2 DragOffset = Vector2.zero;
    public MoveableType MoveType = MoveableType.Block;

    private void Awake()
    {
        Unlock();
    }

    public void Lock()
    {
        CanMove = false;
    }

    public void Unlock()
    {
        CanMove = true;
    }

    public void OnMouseDown()
    {
        if (CanMove == true)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DragOffset = touchPosition - GetComponent<Rigidbody2D>().position;
        }
    }

    public void OnMouseDrag()
    {
        if (CanMove == true)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = touchPosition - DragOffset;
            GetComponent<Rigidbody2D>().MovePosition(touchPosition - DragOffset);
        }
    }
   
    public void OnMouseUp()
    {
        DragOffset = Vector2.zero;
    }

    public void OnDisable()
    {
        try
        {
            GetComponent<TapGesture>().Tapped -= tappedHandler;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void OnEnable()
    {
        try
        {
            GetComponent<TapGesture>().Tapped += tappedHandler;
        }
        catch (System.Exception e) { Debug.Log(e.Message); }
    }

    public void tappedHandler(object sender, EventArgs e)
    {
        if (CanMove == true)
        {
            Debug.Log("Tapped");
            GameObject.FindGameObjectWithTag("Editor").GetComponent<PhysicsEditor>().SetTarget(this.transform);
        }
    }

    public void TogglePower()
    {
        if (HasPower)
            BasePower = (BasePower < 5) ? ++BasePower : 1;
    }

    public void ToggleFlipVertical()
    {
        Debug.Log("Got");
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public void ToggleFlipHorizontal()
    {
        Debug.Log("Got");
        Vector3 newScale = transform.localScale;
        newScale.y *= -1;
        transform.localScale = newScale;
    }
}

public enum MoveableType
{
    Block,
    Speeder,
    Spring,
    Portal,
}