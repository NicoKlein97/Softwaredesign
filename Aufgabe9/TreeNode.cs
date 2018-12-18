using System;
using System.Collections.Generic;

namespace Aufgabe9
{
    class TreeNode<T> : Tree<T>
    {
        public T name;
        public TreeNode(T _name){
            this.name = _name;
        }

        public void showChildren(int _g){
            _g++;
            Console.WriteLine("G" + _g + " " + this.name);
            int count = list.Count;
            if(count > 0){
                for(int i = 0; i < count; i++){
                    list[i].showChildren(_g);
                }
            }
        }
    }
}
