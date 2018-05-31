using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour {

    public Text coordinates;
	
	void Update () {
        coordinates.text = "Lon: " + GPS.Instance.longtitude.ToString("F7") +
                           ", Lat: " + GPS.Instance.latitude.ToString("F7");
        Debug.Log(coordinates.text);
	}
}
