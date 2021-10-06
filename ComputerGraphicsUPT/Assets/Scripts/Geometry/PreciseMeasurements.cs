using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum Measurements
{
    
    NONE = 0,//                 0000 0000 0000
    MAX_WIDTH = 1 << 1,//       0000 0000 0001
    MAX_HEIGHT = 1 << 2,//      0000 0000 0010
    MAX_DEPTH = 1 << 3,//       0000 0000 0100
    TOTAL_VOLUME = 1 << 4,//    0000 0000 1000
    SHORTEST_EXTENT = 1 << 5//  0000 0001 0000
}

public class PreciseMeasurements : MonoBehaviour
{
    Measurements typeMeasurement;
    //Measurements a = Measurements;

    // Start is called before the first frame update
    void Start()
    {
        typeMeasurement = Measurements.MAX_DEPTH | Measurements.MAX_HEIGHT | Measurements.MAX_WIDTH | Measurements.SHORTEST_EXTENT | Measurements.TOTAL_VOLUME | Measurements.NONE;
        
    }

    // Update is called once per frame
    void Update()
    {
        //quad
        if (typeMeasurement.HasFlag(Measurements.MAX_WIDTH) && typeMeasurement.HasFlag(Measurements.MAX_HEIGHT))
        {

        }
        //NGon
        if (typeMeasurement.HasFlag(Measurements.SHORTEST_EXTENT))
        {

        }
        //Cube
        if (typeMeasurement.HasFlag(Measurements.MAX_WIDTH) && typeMeasurement.HasFlag(Measurements.MAX_HEIGHT) && typeMeasurement.HasFlag(Measurements.MAX_DEPTH))
        {

        }
        //none
        if (typeMeasurement.HasFlag(Measurements.NONE))
        {

        }
        //if (typeMeasurement.HasFlag(Measurements.TOTAL_VOLUME))
        //{

        //}
        //if (typeMeasurement.HasFlag(Measurements.SHORTEST_EXTENT))
        //{

        //}



    }
}
