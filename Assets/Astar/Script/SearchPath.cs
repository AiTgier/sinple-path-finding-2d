/** 
 *Copyright(C) by  http://github.com/igeeknerd 
 *All rights reserved. 
 *FileName:     F:/UnityProjs/A-StarDemo/Assets/Astar/Script/SearchPath.cs 
 *Author:       igeeknerd 
 *UnityVersion：2017.1.1f1 
 *Date:         2/27/2018  
*/  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPath{
    /**
     * 搜索的图结构
     */ 
    public Graph graph;
    /**
     * 可以遍历的节点
     */ 
    public List<Node> reachable;
    /**
     * 已经遍历的节点
     */ 
    public List<Node> explored;
    /**
     * 推荐的路径
     */ 
    public List<Node> path;
    /**
     * 目标路点
     */ 
    public Node goalNode;
    public int iterations;
    public bool isFinished = false;

    public SearchPath(Graph p_graph)
    {
        this.graph = p_graph;
    }

    public void Start(Node p_start,Node p_goal)
    {
        //初始化下一轮可以进入的节点，添加初始节点
        reachable = new List<Node>();
        reachable.Add(p_start);
        //目标节点
        goalNode = p_goal;

        explored = new List<Node>();
        path = new List<Node>();
        iterations = 0;

        //图里所有的节点重置
        for (int i = 0; i < graph.nodes.Length; i++)
        {
            graph.nodes[i].Clear();
        }
    }

    public void Step()
    {
        //
        if (path.Count > 0)
        {
            Debug.Log("已经有路点存在");
            return;
        }
        //如果没有可以行走的点
        if (reachable.Count == 0)
        {
            isFinished = true;
            Debug.Log("没有可以行走的路点");
            return;
        }

        iterations++;
        Debug.Log("循环了 " + iterations + "次");

        Node nextNode = chooseNode();
        Debug.Log("寻到的路点是 " + nextNode.label);
        if(nextNode == goalNode)
        {
            while(nextNode != null)
            {
                path.Insert(0, nextNode);
                nextNode = nextNode.previous;
            }
            isFinished = true;
            return;
        }

        reachable.Remove(nextNode);
        explored.Add(nextNode);

        for (int i= 0;i < nextNode.adjcent.Count;i++)
        {
            AddAjcent(nextNode,nextNode.adjcent[i]);
        }
        Debug.Log("reachable 节点是 " + reachable.Count);
    }

    public void AddAjcent(Node p_node,Node p_adNode)
    {
        if(FindNode(p_adNode,reachable) || FindNode(p_adNode, explored))
        {
            Debug.Log("要搜索的节点已经存在");
            return;
        }

        p_adNode.previous = p_node;
        //添加可以到达的节点
        reachable.Add(p_adNode);
    }

    public bool FindNode(Node p_node,List<Node> p_nodeList)
    {
        return GetNodeIndex(p_node,p_nodeList) >= 0;
    }

    public int GetNodeIndex(Node p_node,List<Node> p_list)
    {
        for (int i=0;i < p_list.Count;i++)
        {
            if (p_node == p_list[i])
            {
                return i;
            }
        }

        return -1;
    }

    public Node chooseNode()
    {
        return reachable[Random.Range(0, reachable.Count)];
    }
}
