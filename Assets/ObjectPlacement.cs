using System;
using System.Collections.Generic; using UnityEngine;
using UnityEngine.XR.ARFoundation; using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class ObjectPlacement : MonoBehaviour {

    public static event Action onPlacedObject; private static bool isObjectPlaced = false; ARRaycastManager arRaycastManager; ARPlaneManager arPlaneManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>(); public GameObject objectToPlace;

    void Awake() {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
    }

    void Update() {
        if (isObjectPlaced) {
            return; 
        }
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 2 && touch.phase == TouchPhase.Ended) {
                if (arRaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon)) {
                    ObjectManager.Instance.SetObject(new Pose(s_Hits[0].pose.position, s_Hits[0].pose.rotation)); isObjectPlaced = true;
                }
            }
        }
    }
}