using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType.String;

// To use other type that int, see Deitel page. 777 using ICompariable Objects and CompareTo

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
            t.Insert(70);
            int y = t.X(t.root);   // hvad udfører X - giv et bud før du indtaster prog og checker.
            Console.WriteLine("y er " + y);
            t.Print();

            Console.WriteLine("\nSUM\n" + t.Sum());

            Console.WriteLine("\nPrint leafs");
            t.PrintLeaves();

            Console.WriteLine("\nMAX\n" + t.MaxNodeValue());

            Console.ReadKey();
        }
    }


    class Tree
    {
        public Node root;

        public Tree() { root = null; }

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

        public int Sum() { return root.CalcSum(root); }

        public void PrintLeaves()
        {
            if (root != null)
                root.Leaf();
        }

        public int MaxNodeValue() { return root.MaxValue(); }

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

            public int CalcSum(Node node)
            {
                int sum = 0;
                if (node != null)
                {
                    
                    sum += node.data;           // Console.WriteLine(node.data + " ")   <-- PreOrder    print --*
                    sum += CalcSum(node.left);  // Console.WriteLine(node.data + " ")   v-- InOrder     print --*
                    sum += CalcSum(node.right); // Console.WriteLine(node.data + " ")   v-- PostOrder   print --*
                    return sum;
                }
                return 0;
            }

            public void Leaf()
            {
                if (left == null && right == null)
                    Console.WriteLine(data);

                if (left != null)
                    left.Leaf();

                if (right != null)
                    right.Leaf();
            }

            public int MaxValue()
            {
                if (right == null)
                    return data;
                return right.MaxValue();
            }
        }
    }
}



