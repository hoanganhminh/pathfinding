using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GraphNode<T> where T : MonoBehaviour
{
    public T data { get; set; }
}

