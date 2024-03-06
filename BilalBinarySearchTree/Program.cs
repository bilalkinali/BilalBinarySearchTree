using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType.String;

// Simpelt binaert soegetre
// Datamatikeruddannelsen i Vejle, Per Larsen

namespace BSTintVers1
{
    public class TreeTest
    {
        public static void Main(String[] args)
        {
            Tree t = new Tree();
            t.Insert(100);
            t.Insert(50);
            t.Insert(200);
            t.Insert(10);
            t.Insert(60);
            t.Insert(150);
            t.Insert(500);
            int y = t.X(t.root);   // hvad udfører X - giv et bud før du indtaster prog og checker.
            Console.WriteLine("y er " + y);
            t.Print();
            
            int sum = t.PrintSum(t.root);
            Console.WriteLine(sum.ToString());

            Console.ReadKey();
        }
    }


    class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }

        public int X(Node r)
        {
            if (r != null)
                return 1 + X(r.left) + X(r.right);
            else
                return 0;
        }

        public void Insert(int n)
        {
            Node newNode = new Node();
            newNode.data = n;
            newNode.left = null;
            newNode.right = null;
            if (root == null)
                root = newNode;
            else
                root.InsertNode(newNode);
        }

        public void Print()
        {
            if (root != null)
                root.PrintNode();
        }

        public int PrintSum(Node r)
        {
            if (r != null)
            {
                return r.Sum();
            }
            return 0;
        }

        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public void InsertNode(Node newNode)
            {
                if (newNode.data < data)
                {
                    if (left == null) left = newNode;
                    else left.InsertNode(newNode);
                }
                else
                {
                    if (right == null) right = newNode;
                    else right.InsertNode(newNode);
                }
            }

            public void PrintNode()
            {
                Console.WriteLine(data);
                if (left != null)
                    left.PrintNode();
                //Console.WriteLine(data);
                if (right != null)
                    right.PrintNode();
            }

            public int Sum()
            {
                Console.WriteLine(data);
                if (left != null)
                {
                    return data + left.Sum() + right.Sum();
                }
                return data;
            }
        }
    }
}



