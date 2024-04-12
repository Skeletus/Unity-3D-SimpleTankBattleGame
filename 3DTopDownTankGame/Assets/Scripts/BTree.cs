using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTree : MonoBehaviour
{
    private BTreeNode root;
    private int t; // Minimum degree

    public BTree(int _t)
    {
        root = null;
        t = _t;
    }

    public void Traverse()
    {
        if (root != null)
        {
            root.Traverse();
        }
    }

    public void Insert(int k)
    {
        if (root == null)
        {
            root = new BTreeNode(t, true);
            root.keys.Add(k);
            root.SetN(1);
        }
        else
        {
            if (root.n == 2 * t - 1)
            {
                BTreeNode s = new BTreeNode(t, false);
                s.children.Add(root);
                s.SplitChild(0, root);
                int i = 0;
                if (s.keys[0] < k)
                {
                    i++;
                }
                s.children[i].InsertNonFull(k);
                root = s;
            }
            else
            {
                root.InsertNonFull(k);
            }
        }
    }
}
