using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    private const string OBJECT_PATH = "baked_mesh";
    private static ObjectManager instance;
    public static ObjectManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectManager>();
            }
            return instance;
        }
    }

    public GameObject CurrentObject { get; set;}

    public void SetObject(Pose pose) {
        CurrentObject = Instantiate(Resources.Load(OBJECT_PATH) as GameObject, pose.position, pose.rotation);
    } 
}
