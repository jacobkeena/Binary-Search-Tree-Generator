using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BST
    {
        public Node root;
        public BST()
        {
            root = null;
        }

        public void AddNumber(int i)
        {
            Node newNode = new Node();
            newNode.data = i;

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (i < current.data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;

                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }

                    }
                }
            }
        }


    }
}
