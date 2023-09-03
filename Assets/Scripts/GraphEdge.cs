using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GraphEdge<T> where T : MonoBehaviour
{
    public GraphNode<T> from { get; set; }
    public GraphNode<T> to { get; set; }

    public float weight { get; set; }
}

