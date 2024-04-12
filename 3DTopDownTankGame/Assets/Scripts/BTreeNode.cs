using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTreeNode : MonoBehaviour
{
    [SerializeField] private int t; // Minimum degree (defines the range for the number of keys)
    public List<int> keys; // List of keys
    public List<BTreeNode> children; // List of pointers to children
    public int n; // Current number of keys
    [SerializeField] private bool leaf; // Is true when the node is a leaf

    public BTreeNode(int _t, bool _leaf)
    {
        t = _t;
        leaf = _leaf;
        n = 0;
        keys = new List<int>(2 * t - 1);
        children = new List<BTreeNode>(2 * t);
    }

    public void SetN(int value)
    {
        n = value;
    }

    /// <summary>
    /// Function to traverse all nodes in a subtree rooted with this node
    /// </summary>
    public void Traverse()
    {
        int i;
        for (i = 0; i < n; i++)
        {
            // If this node is not a leaf, then before printing key[i],
            // traverse the subtree rooted with child[i]
            if (!leaf)
            {
                children[i].Traverse();
            }

            Console.Write(" " + keys[i]);
        }

        // Print the subtree rooted with the last child
        if (!leaf)
        {
            children[i].Traverse();
        }
    }

    /// <summary>
    /// Function to insert a new key in the subtree rooted with this node
    /// </summary>
    /// <param name="k"></param>
    public void InsertNonFull(int k)
    {
        int i = n - 1;

        if (leaf)
        {
            while (i >= 0 && keys[i] > k)
            {
                keys[i + 1] = keys[i];
                i--;
            }

            keys[i + 1] = k;
            n = n + 1;
        }
        else
        {
            while (i >= 0 && keys[i] > k)
                i--;

            if (children[i + 1].n == 2 * t - 1)
            {
                SplitChild(i + 1, children[i + 1]);

                if (keys[i + 1] < k)
                    i++;
            }
            children[i + 1].InsertNonFull(k);
        }
    }

    /// <summary>
    /// Function to split the child of this node
    /// </summary>
    /// <param name="i"></param>
    /// <param name="bTreeNode"></param>
    public void SplitChild(int i, BTreeNode bTreeNode)
    {
        BTreeNode z = new BTreeNode(bTreeNode.t, bTreeNode.leaf);
        z.n = t - 1;

        for (int j = 0; j < t - 1; j++)
            z.keys.Add(bTreeNode.keys[j + t]);

        if (!bTreeNode.leaf)
        {
            for (int j = 0; j < t; j++)
                z.children.Add(bTreeNode.children[j + t]);
        }

        bTreeNode.n = t - 1;

        children.Insert(i + 1, z);

        keys.Insert(i, bTreeNode.keys[t - 1]);

        n = n + 1;
    }
}
