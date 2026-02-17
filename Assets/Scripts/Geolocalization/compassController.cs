using System;
using TMPro;
using UnityEngine;

public class compassController : MonoBehaviour
{
    public double monsterLat;
    public double monsterLon;
    public RectTransform arrow;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (GPSTracker.Instance == null || GPSTracker.Instance.currentMonsterIndex >= GPSTracker.Instance.monsters.Count)
            return;

        Monster currentMonster = GPSTracker.Instance.monsters[GPSTracker.Instance.currentMonsterIndex];


        float heading = Input.compass.trueHeading;
        float bearing = CalculateBearing(
            GPSTracker.Instance.currentLat,
            GPSTracker.Instance.currentLon,
            currentMonster.latitude,
            currentMonster.longitude
        );

        float angle = heading - bearing;
        arrow.localRotation = Quaternion.Euler(0, 0, angle);

    }

    float CalculateBearing(double lat1, double lon1, double lat2, double lon2)
    {
        double dLon = (lon2 - lon1) * Mathf.Deg2Rad;
        lat1 *= Mathf.Deg2Rad;
        lat2 *= Mathf.Deg2Rad;

        double y = Math.Sin((float)dLon) * Math.Cos((float)lat2);
        double x = Math.Cos((float)lat1) * Math.Sin((float)lat2) - 
                   Math.Sin((float)lat1) * Math.Cos((float)lat2) * 
                   Math.Cos((float)dLon);

        double brng = Math.Atan2(y, x);
        brng = brng * Mathf.Rad2Deg;
        return (float)((brng + 360) % 360);
    }
}
