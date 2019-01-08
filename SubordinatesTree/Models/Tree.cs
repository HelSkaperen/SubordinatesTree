using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubordinatesTree.Models
{
    public class treeNode
    {
        public List<treeNode> childrens;
        public PersonModel personNode;
        public treeNode (PersonModel person) { childrens = new List<treeNode>(); personNode = person; }
        public void add_children (treeNode children)
        {
            childrens.Add(children);
        }
    }
    public class Tree
    {
        public List<treeNode> root;
        public Tree() { root = new List<treeNode>(); }
    }
}
