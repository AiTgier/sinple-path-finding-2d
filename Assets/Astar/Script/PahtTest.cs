/** 
 *Copyright(C) by  http://github.com/igeeknerd 
 *All rights reserved. 
 *FileName:     F:/UnityProjs/A-StarDemo/Assets/Astar/Script/PahtTest.cs 
 *Author:       igeeknerd 
 *UnityVersion：2017.1.1f1 
 *Date:         2/27/2018  
*/  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PahtTest : MonoBehaviour {

    public int[,] map;
	// Use this for initialization
	void Start () {
        map = new int[5, 5]{
            {0,1,0,0,0 },
            {0,1,0,0,0 },
            {0,1,0,0,0 },
            {0,1,0,0,0 },
            {0,0,0,0,0 }
        };
        Graph graph = new Graph(map);
        SearchPath path = new SearchPath(graph);
        path.Start(graph.nodes[0],graph.nodes[2]);
        while (!path.isFinished)
        {
            path.Step();
        }

        Debug.Log("最后的路点长度是 " + path.path.Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
