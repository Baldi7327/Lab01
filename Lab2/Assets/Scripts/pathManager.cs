using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathManager : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    public List<wayPoint> path;

    public List<wayPoint> GetPath()
    {
        if (path == null) {
            path = new List<wayPoint>();

            return path;
        }

        public void CreateAddPath()
        {
            wayPoint go = new wayPoint();
            path.Add(go);
        }
    }
}
