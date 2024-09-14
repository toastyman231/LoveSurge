using UnityEngine;

public class MapScript : MonoBehaviour
{
    // Information and name for the map location
    public string locInfo;
    public string locName;

    public MapLocationsManager manager; // Reference to the MapLocationsManager

    // OnSelect is triggered when the map location is selected
    public void OnSelect()
    {
        // Delegate the selection logic to the manager, passing location info and name
        if (manager != null)  // Check if the manager reference is assigned
        {
            manager.LocationSelect(locInfo, locName);
        }
        else
        {
            Debug.LogWarning("MapLocationsManager reference is missing on " + gameObject.name);
        }
    }
}