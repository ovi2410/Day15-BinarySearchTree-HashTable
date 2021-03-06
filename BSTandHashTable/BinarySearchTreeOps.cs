using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTandHashTable
{
    internal class BinarySearchTreeOps<T> where T : IComparable<T>
    {
        public T NodeData { get; set; }
        public BinarySearchTreeOps<T> leftTree { get; set; }
        public BinarySearchTreeOps<T> rightTree { get; set; }

        int leftCount = 0, rightCount = 0;
        bool result = false;

        public BinarySearchTreeOps(T NodeData)
        {
            this.NodeData = NodeData;
            this.leftTree = leftTree;
            this.rightTree = rightTree;

        }

        public void Insert(T item)
        {
            T currentnodevalue = this.NodeData;

            if ((currentnodevalue.CompareTo(item)) > 0)
            {
                if (this.leftTree == null)
                {
                    this.leftTree = new BinarySearchTreeOps<T>(item);
                    Console.WriteLine("> {0} is inserted in BinarySearchTree...", item);
                }
                else
                {
                    this.leftTree.Insert(item);
                }

            }

            else
            {
                if (this.rightTree == null)
                {
                    this.rightTree = new BinarySearchTreeOps<T>(item);
                    Console.WriteLine("> {0} is inserted in BinarySearchTree...", item);
                }
                else
                {
                    this.rightTree.Insert(item);
                }
            }
        }


        public void InsertMultiItems(params T[] inputarray)
        {
            foreach (T item in inputarray)
            {
                Insert(item);
            }
        }

        public void Count(BinarySearchTreeOps<T> binarySearchTree)
        {


            if (this.leftTree != null)
            {
                binarySearchTree.leftCount++;
                this.leftTree.Count(binarySearchTree);
            }

            if (this.rightTree != null)
            {
                binarySearchTree.rightCount++;
                this.rightTree.Count(binarySearchTree);
            }

        }

        public void GetSizeOfBSt(BinarySearchTreeOps<T> binarySearchTree)
        {
            Count(binarySearchTree);
            Console.WriteLine("Size of BST is :- " + (1 + this.leftCount + this.rightCount));

        }


        public bool IfExists(T element, BinarySearchTreeOps<T> node)
        {

            if (node == null)
            {
                return false;
            }
            if (node.NodeData.Equals(element))
            {
                Console.WriteLine("\n> Serching for Element {0} in BST....", element);
                Console.WriteLine("\n>> Element {0} is present in our BST ", node.NodeData);
                result = true;
            }

            if (element.CompareTo(node.NodeData) < 0)
            {
                IfExists(element, node.leftTree);
            }
            if (element.CompareTo(node.NodeData) > 0)
            {
                IfExists(element, node.rightTree);
            }

            return result;
        }


        public void Display()
        {
            if (this.leftTree != null)
            {
                this.leftTree.Display();
            }

            Console.WriteLine(this.NodeData.ToString());

            if (this.rightTree != null)
            {
                this.rightTree.Display();
            }


        }

    }
}
