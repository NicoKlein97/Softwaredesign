using System;
using System.Collections.Generic;

namespace Aufgabe11._1
{
       class Tree<T>
    {
        public T name;
        public Tree<T> parent;
        public List<Tree<T>> list = new List<Tree<T>>();
        delegate void Delegation(Tree<T> node);
        public Tree()
        {
            
        }
        public Tree(T _name)
        {
            this.name = _name;
        }

        public Tree<T> CreateNode(T _name)
        {
            Tree<T> newNode = new Tree<T>(_name);
            this.list.Add(newNode);
            return newNode;
        }

        public void AppendChild(Tree<T> _childNode)
        {
            _childNode.parent = this;
            this.list.Add(_childNode);
        }

        public void RemoveChild(Tree<T> _childNode)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                if (list[i].name.Equals(_childNode.name))
                {
                    list.RemoveAt(i);
                    break;
                }
            }
        }

        public void PrintTree(int _generation)
        {
            _generation++;
            int count = list.Count;
            Console.WriteLine("G" + _generation + " " + this.name);
            for (int i = 0; i < count; i++)
            {
                list[i].PrintTree(_generation);
            }
        }

        public void PrintAncestors(){
            if(this.parent != null){
                Console.WriteLine(this.parent.name);
                parent.PrintAncestors();
            }
        }
        public void ForEach(){
            Delegation handler = Program.Func;
            handler(this);
        }
    }
}
