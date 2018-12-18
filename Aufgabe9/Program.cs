using System;
using System.Collections.Generic;

namespace Aufgabe9
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<string> tree = new Tree<string>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child2");
            var grandChild1 = tree.CreateNode("grandChild1");
            var grandChild2 = tree.CreateNode("grandChild2");
            var grandChild3 = tree.CreateNode("grandChild3");
            var grandChild4 = tree.CreateNode("grandChild4");
            var grandGrandChild1 = tree.CreateNode("grandGrandChild1");
            root.AppendChild(child1);
            root.AppendChild(child2);
            child1.AppendChild(grandChild1);
            child1.AppendChild(grandChild2);
            child1.AppendChild(grandChild3);
            child2.AppendChild(grandChild4);
            grandChild1.AppendChild(grandGrandChild1);
            root.PrintTree();
        }
    }
}
