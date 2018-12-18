using System;
using System.Collections.Generic;

namespace Aufgabe9
{
    class Tree<T>
    {
        public T name;
        public List<TreeNode<T>> list = new List<TreeNode<T>>();

        public Tree(){

        }
        
       public TreeNode<T> CreateNode( T _name){
           TreeNode<T> newNode = new TreeNode<T>(_name);
           this.list.Add(newNode);
           return newNode;
       }
       public void AppendChild(TreeNode<T> _childNode){
           this.list.Add(_childNode);
       }

       public void RemoveChild(TreeNode<T> _childNode){
           int count = list.Count;
           for(int i = 0; i < count; i++){
               if(list[i].name.Equals(_childNode.name)){
                   list.RemoveAt(i);
                   break;
               }
           }
       }
       public void PrintTree(){
           int count = list.Count;
           int generation = 1;
           Console.WriteLine("G" + generation + " " + this.name);
           for(int i = 0; i < count; i++){
               list[i].showChildren(generation);
           }
       }
    }
}
