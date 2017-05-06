using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Variables
    private float currentTime = 0;
    private bool isPlaying = false;
    public List<GameObject> activeObjects = new List<GameObject>();
    private GameObject selectedObject;
    #endregion

    #region Update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.transform.tag == "Movable" && selectedObject != hit.transform.gameObject)
                {
                    selectedObject = hit.transform.gameObject;
                    selectedObject.GetComponent<Movable>().isSelected = true;
                }
                else if (hit.transform.tag == "Movable" && selectedObject == hit.transform.gameObject)
                {
                    selectedObject.GetComponent<Movable>().isSelected = false;
                    selectedObject = null;
                }
            }          
        }
    }
    #endregion

    #region Begin Play
    public void BeginPlay()
    {

    }
    #endregion

    #region Load Positions
    //TODO:  This function is called when the slider is moved manually, so only if isPlaying == false
    public void LoadPositions(int time)
    {
        foreach (GameObject go in activeObjects)
        {
            go.GetComponent<Movable>().SetPosition(time);
        }
    }
    #endregion
}