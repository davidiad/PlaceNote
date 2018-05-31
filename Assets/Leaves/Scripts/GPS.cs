using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour {

    public static GPS Instance { set; get;  }

    public double longtitude;
    public double latitude;

	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
	}

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser) {
            Debug.Log("GPS not enabled by User");
            yield break;
        }

        Input.location.Start(0.5f, 0.5f);
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait <= 0)
        {
            Debug.Log("Timed Out");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Could not determine location");
            yield break;
        }

        longtitude = Input.location.lastData.longitude;
        latitude = Input.location.lastData.latitude;

        yield break;
    }

    void Update () {
        StartCoroutine(StartLocationService());
	}
}
