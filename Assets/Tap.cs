using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tap : MonoBehaviour {

    static Vector3 prebPosition;

    public enum EventType { None,Pressed,Click,LongPress,Drag}

    public float CheckDistance = 3;
    public float CheckTime = 0.3f;

    EventType type;
    bool isRunning;

    Vector3 startPos;
    float startTime;

    public bool IsRunning { get { return isRunning; } }

    void SetType(EventType type)
    {
        this.type = type;
        Debug.Log(type);
    }

    public void OnPointerDown(PointerEventData e)
    {
        isRunning = true;
        SetType(EventType.Pressed);
        startPos = GetPosition();
        startTime = Time.deltaTime;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (type == EventType.Pressed)
        {
            // 押されてる
            var pos = GetPosition();
            var dx = Mathf.Abs(pos.x - startPos.x);
            var dy = Mathf.Abs(pos.y - startPos.y);
            var dt = Time.time - startTime;
            if (dx > CheckDistance || dy > CheckDistance)
            {
                // 一定距離動いていたらドラッグ実行
                SetType(EventType.Drag);
            }
            else if (dt > CheckTime)
            {
                // 一定時間経過していたら長押し実行
                SetType(EventType.LongPress);
            }
        }
        else if (type == EventType.Drag)
        {
            // ドラッグ中(動かす)
            transform.position = GetPosition();
        }

    }

    public static GodPhase GetPhase()
    {

        if (Input.GetMouseButtonDown(0))
        {
            prebPosition = Input.mousePosition;
            return GodPhase.Began;
        }
        else if (Input.GetMouseButton(0))
        {
            return GodPhase.Moved;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            return GodPhase.Ended;
        }
        return GodPhase.None;
    }

    public static Vector3 GetPosition()
    {
            if (GetPhase() != GodPhase.None) return Input.mousePosition;

        return Vector3.zero;
    }

    public static Vector3 GetDeltaPosition()
    {
            var phase = GetPhase();
            if (phase != GodPhase.None)
            {
                var now = Input.mousePosition;
                var delta = now - prebPosition;
                prebPosition = now;
                return delta;
            }
        return Vector3.zero;
    }

    public enum GodPhase
    {
        None = -1,
        Began = 0,
        Moved = 1,
        Stationary = 2,
        Ended = 3,
        Canceled = 4
    }

    public void OnPointerUp(PointerEventData e)
    {
        if (type == EventType.Pressed)
        {
            // 他のイベントが未入力ならクリック実行
            SetType(EventType.Click);
        }
        else
        {
            // イベント初期化
            SetType(EventType.None);
        }
        isRunning = false;
    }
}
