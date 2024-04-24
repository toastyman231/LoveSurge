using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public string locInfo;
    public string locName;
    public MapLocationsManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        manager.LocationSelect(locInfo, locName);
    }

}
