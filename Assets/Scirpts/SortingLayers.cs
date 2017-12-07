using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SortingLayers : MonoBehaviour
{
    public List<GameObject> Layers = new List<GameObject>();
    public float Distance;
    private Vector3 plusDirection;
	void Awake ()
    {
        //plusDirection = Vector3.zero;
        //for (int i = 0; i < Layers.Count; i++)
        //{
        //    Layers[i].transform.position = plusDirection;
        //}

    }
    public bool Sorting;
    // Update is called once per frame
    void Update()
    {
        //int layerCount = Layers.Count;
        //for (int i = 0; i < Layers.Count; i++)
        //{
        //    plusDirection = Layers[i].gameObject.transform.position;
        //    plusDirection.z += Distance;
        //    Layers[i].gameObject.transform.position = plusDirection;
        //}
        if (Sorting)
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                plusDirection.z = Layers[i].transform.position.z;
                Distance -= 0.1f;
                plusDirection.z = Distance;
                Layers[i].transform.position = plusDirection;
            }
        }
    }
}
