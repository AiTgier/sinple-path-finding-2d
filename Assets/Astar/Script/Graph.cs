/** 
 *Copyright(C) by  http://github.com/igeeknerd 
 *All rights reserved. 
 *FileName:     F:/UnityProjs/A-StarDemo/Assets/Astar/Script/Graph.cs 
 *Author:       igeeknerd 
 *UnityVersion：2017.1.1f1 
 *Date:         2/25/2018  
*/  
using System.Collections;
using System.Collections.Generic;
/**
 * 图
 */ 
public class Graph {
    public int rows = 0;
    public int cols = 0;
    public Node[] nodes;

    public Graph(int[,] p_grid)
    {
        rows = p_grid.GetLength(0);
        cols = p_grid.GetLength(1);
        int total = rows * cols;
        nodes = new Node[total];
        for (int i=0;i < total;i++)
        {
            Node tmpnode = new Node();
            tmpnode.label = i.ToString();
            nodes[i] = tmpnode;
        }

        //检查网格
        for (int i=0;i < cols;i++)
        {
            for (int j=0;j < rows;j++)
            {
                //第j行，第i列的元素
                Node tmpnode = nodes[j*cols + i];
                
                //网格被占的节点不需要计算临近节点
                if(p_grid[j, i] == 1)
                {
                    continue;
                }
                //计算每一个格子的临近节点
                //上一行,第二行开始
                if (j > 0)
                {
                    tmpnode.adjcent.Add(nodes[cols * (j - 1) + i]);
                    
                    
                }
                //右一行，最多右倒数第二行
                if (i < cols - 1)
                {
                    tmpnode.adjcent.Add(nodes[cols*j + i + 1]);
                }
                //下面一行，最多下倒数第二行
                if(j < rows - 1){
                    tmpnode.adjcent.Add(nodes[(j +1)*cols + i]);
                }
                //左面一行
                if (i > 0)
                {
                    tmpnode.adjcent.Add(nodes[cols*j + i -1]);
                }
            }
        }
    }
}
