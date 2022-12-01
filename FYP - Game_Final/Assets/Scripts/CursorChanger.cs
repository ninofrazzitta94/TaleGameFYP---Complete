using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [SerializeField] private Texture2D[] cursorArrow;
    [SerializeField] private int FrameCount;
    [SerializeField] private float FrameRate;

    private int CurrentFrame;
    private float frameTimer;

    private Vector2 hotSpot;

    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        /*
        Vector2 hotSpot = new Vector2(cursorArrow[0].width / 2f, cursorArrow[0].height / 2f);

        Cursor.SetCursor(cursorArrow[0], hotSpot, CursorMode.ForceSoftware);
        */
    }
  

    public void LoadCustomCursor()
    {        
            if (frameTimer <= 0f)
            {
            hotSpot = new Vector2(cursorArrow[CurrentFrame].width / 2f, cursorArrow[CurrentFrame].height / 2f);
            }
    }

    public void LoadNormalCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if(frameTimer <= 0f)
        { 
            frameTimer += FrameRate;
            CurrentFrame = (CurrentFrame + 1) % FrameCount;
            Cursor.SetCursor(cursorArrow[CurrentFrame], hotSpot, CursorMode.ForceSoftware);
        }
    }

}




