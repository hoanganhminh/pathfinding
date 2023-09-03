using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Graph<T> where T : MonoBehaviour
{
    public List<GraphNode<T>> nodes = new List<GraphNode<T>>();
    public List<GraphEdge<T>> edges = new List<GraphEdge<T>>(); 

    public Dictionary<GraphNode<T>, GraphRoute<T>> calculateMinCost(GraphNode<T> source)
    {
        Dictionary<GraphNode<T>,GraphRoute<T>> paths = new Dictionary<GraphNode<T>, GraphRoute<T>>();
        List<GraphNode<T>> handledLocations = new List<GraphNode<T>>();

        //Initialise the new routes. the constructor will set the route weight to MAX
        foreach (GraphNode<T> location in nodes)
        {
            paths.Add(location, new GraphRoute<T>());
        }

        //The startPosition has a weight 0. 
        paths[source].cost = 0;


        //If all locations are handled, stop the searching process and return the result
        while (handledLocations.Count != paths.Count)
        {
            //Order the locations
            List<GraphNode<T>> shortestLocations = (List<GraphNode<T>>)(from s in paths
                                                                        orderby s.Value.cost
                                                                 select s.Key).ToList();

            //Search for the nearest location that isn't handled
            GraphNode<T> locationToProcess = null;
            foreach (GraphNode<T> location in shortestLocations)
            {
                if (!handledLocations.Contains(location))
                {
                    //If the cost equals int.max, there are no more possible connections to the remaining locations
                    if (paths[location].cost == float.MaxValue)
                        return paths;
                    locationToProcess = location;
                    break;
                }
            }

            //Select all connections where the start position is the location to Process
            List<GraphEdge<T>> selectedEdges = new List<GraphEdge<T>>();
            foreach(GraphEdge<T> c in edges)
            {
               if(c.from == locationToProcess)
                    selectedEdges.Add(c);
            }

            //Iterate through all connections and search for a connection which is shorter
            foreach (GraphEdge<T> conn in selectedEdges)
            {
                if (paths[conn.to].cost > conn.weight + paths[conn.from].cost)
                {
                    paths[conn.to].connections = paths[conn.from].connections.ToList();
                    paths[conn.to].connections.Add(conn);
                    paths[conn.to].cost = conn.weight + paths[conn.from].cost;
                }
            }

            //Add the location to the list of processed locations
            handledLocations.Add(locationToProcess);
        }

        return paths;
    }

    public List<GraphNode<T>> getPath(GraphNode<T> source, GraphNode<T> destination) //nhan vao node dau va node cuoi de tim duong ngan nhat
    {
        List<GraphNode<T>> nodes = new List<GraphNode<T>>();
        Dictionary<GraphNode<T>, GraphRoute<T>> paths = calculateMinCost(source);
        foreach( GraphEdge<T> edge  in  paths[destination].connections)
        {
            nodes.Add(edge.to);
        }
        return nodes; //tra ve list cac node
    }

    public List<GraphNode<T>> getNeighbors(GraphNode<T> a)
    {
        List <GraphNode < T >> neighbors = new List<GraphNode<T>>();
        foreach (GraphEdge<T> e in edges)
        {
            if (e.from == a)
                neighbors.Add(e.to);
        }
        return neighbors;
    }

    public List<T> getData(List<GraphNode<T>> list)
    {
        List<T> datas = new List<T>();
        foreach (GraphNode<T> node in list)
        {
            datas.Add(node.data);
        }
        return datas;
    }

    public GraphNode<T> getNode(T data)
    {
        foreach(GraphNode<T> node in nodes)
        {
            if(node.data == data)
            {
                return node;
            }
        }
        return null;
    }

}
