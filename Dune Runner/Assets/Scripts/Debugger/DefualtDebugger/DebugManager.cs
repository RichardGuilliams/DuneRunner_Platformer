using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{

    public ComparisonOperator compare = new ComparisonOperator();

    Vector3Interface vector3Debugger;
    Vector2Interface vector2Debugger;
    FloatInterface floatDebugger;
    public List<LoopDebugger> loopDebuggers;
    public string header;
    public bool isEnabled;
    public int framesToLog;
    public bool continuousLog;
    public ArrayList list = new ArrayList();

    public static DebugManager instance;
    public static DebugManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<DebugManager>();
                if(instance == null)
                {
                    instance = new GameObject().AddComponent<DebugManager>();
                }
            }
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null) Destroy(this);
        DontDestroyOnLoad(this);
    }
    public void Start()
    {
        instance = this;
    }
    public void AddToLog(object obj)
    {
        list.Add(obj);
    }

    public bool LoopExists(int id)
    {
        if (loopDebuggers.Count == loopDebuggers[id].loopId) return true;
        return false;
    }

    public void Loop(object paramA, object paramB, int logCounter, int _maxIteration, bool continuous,  ComparisonOperator.Condition conditionToCheck)
    {
        compare.condition = conditionToCheck;
        loopDebuggers.Add(new LoopDebugger(loopDebuggers.Count, paramA, paramB, logCounter, _maxIteration, continuous,  conditionToCheck));
    }


    public void LogList()
    {
        foreach (object element in list)
        {
            HandleObjectType(element);
            Debug.Log(element);
        }
        list.Clear();
    }
    

    public void HandleObjectType(object element)
    {
        if (element.GetType() == typeof(float)) Debug.Log("Element is a float");
        if (element.GetType() == typeof(bool)) Debug.Log("Element is a bool");
        if (element.GetType() == typeof(int)) Debug.Log("Element is a int");
        if (element.GetType() == typeof(string)) Debug.Log("Element is a string");
        if (element.GetType() == typeof(GameObject)) Debug.Log("Element is a Game Object");
        if (element.GetType() == typeof(Vector2)) Debug.Log("Element is a Vector2");
        if (element.GetType() == typeof(GameEvent)) Debug.Log("Element is a GameEvent");
        if (element.GetType() == typeof(List<>)) Debug.Log("Element is a List");
        if (element.GetType() == typeof(Dictionary<object, object>)) Debug.Log("Element is a Vector3");
        if (element.GetType() == typeof(Decimal)) Debug.Log("Element is a Decimal");
        if (element.GetType() == typeof(Rigidbody2D)) Debug.Log("Element is a RigidBody2D");
        if (element.GetType() == typeof(Transform)) Debug.Log("Element is a Transform");
        if (element.GetType() == typeof(Collider2D)) Debug.Log("Element is a Collider2D");
        if (element.GetType() == typeof(Display)) Debug.Log("Display");
        if (element.GetType() == typeof(RaycastHit2D)) Debug.Log("Element is a RaycastHit2D");
        if (element.GetType() == typeof(CircleCollider2D)) Debug.Log("Element is a CircleCollider2D");
        if (element.GetType() == typeof(Color)) Debug.Log("Element is a Color");
        if (element.GetType() == typeof(Material)) Debug.Log("Element is a Material");
        if (element.GetType() == typeof(PhysicsMaterial2D)) Debug.Log("Element is a PhysicsMaterial2D");
        if (element.GetType() == typeof(CapsuleCollider2D)) Debug.Log("Element is a CapsuleCollider2D");
        if (element.GetType() == typeof(BoxCollider2D)) Debug.Log("Element is a BoxCollider2D");
    }

    public bool KeepLogging()
    {
        if (FramesToLog() || continuousLog) return true;
        return false;
    }

    public bool FramesToLog()
    {
        if (framesToLog > 0) return true;
        return false;
    }

    public void CheckFrames()
    {
        if (FramesToLog()) framesToLog -= 1;
    }

    public void SetFramesToLog(int frames)
    {
        framesToLog = frames;
    }
    public void Disable()
    {
        isEnabled = false;
    }

    public void AddHeader()
    {
        Debug.Log("------------------" + header + "-------------------");
    }

    public void SpaceLog()
    {
        Debug.Log("---------------------------------------------------");
    }

    public void Update()
    {

    }

}
