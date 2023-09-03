using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GraphRoute<T> where T : MonoBehaviour
{
        public float cost;
        public List<GraphEdge<T>> connections;

        public GraphRoute()
        {
            cost = float.MaxValue;
            connections = new List<GraphEdge<T>>();
        }

    }

