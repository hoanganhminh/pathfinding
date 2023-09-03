using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoverController : MonoBehaviour
{
    public List<GraphNode<LocationInfo>> visualPath { get; set; } //list node se phai di qua, nhan tu graph tracker update
    public GraphNode<LocationInfo> destination { get; set; } //node cuoi nhan tu graph tracker update

    public TextMeshProUGUI LastNodeName; //hien thi text

    int numberOfVisitedNodes = 0;
    void Update()
    {
        LastNodeName.text = destination.data.name; //set text vi tri mover dang di den (node cuoi)
        if (visualPath.Count > 0 && numberOfVisitedNodes < visualPath.Count) //dieu kien khi mover chua di den node cuoi
        {
            GraphNode<LocationInfo> des = visualPath[numberOfVisitedNodes]; //lay theo tung vi tri (node next)
            float step = 4 * Time.deltaTime; //toc do di chuyen cua mover
            //di chuyen mover den node tiep
            Vector2 point = new Vector2(des.data.x, des.data.y);
            transform.position = Vector2.MoveTowards(transform.position, point, step);
            if (transform.position.x == des.data.x && transform.position.y == des.data.y) //neu den vi tri node tiep thi lap lai 
            {
                numberOfVisitedNodes++;
            }
        }
        if(numberOfVisitedNodes == visualPath.Count) { //neu den node cuoi thi destroy
            Destroy(gameObject); 
        }
    }
}
