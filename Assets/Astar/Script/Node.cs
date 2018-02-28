/** 
 *Copyright(C) by  http://github.com/igeeknerd 
 *All rights reserved. 
 *FileName:     F:/UnityProjs/A-StarDemo/Assets/Astar/Script/Node.cs 
 *Author:       igeeknerd 
 *UnityVersion：2017.1.1f1 
 *Date:         2/25/2018  
*/  
using System.Collections;
using System.Collections.Generic;

/**
 * 寻路节点
 */ 
public class Node{

    public List<Node> adjcent = new List<Node>();
    public Node previous = null;
    public string label = "";

    public void Clear()
    {
        this.previous = null;
    }
}
