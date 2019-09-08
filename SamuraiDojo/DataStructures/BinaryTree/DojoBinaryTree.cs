using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.DataStructures.BinaryTree
{
    public abstract class DojoBinaryTree<T>
    {
        public T Data { get; set; }

        public DojoBinaryTree<T> LeftSubTree { get; set; }

        public DojoBinaryTree<T> RightSubTree { get; set; }


        public DojoBinaryTree()
        {
            Data = default;
            LeftSubTree = default;
            RightSubTree = default;
        }

        public abstract void Insert(T data);

        public abstract void Delete(T data);

        public abstract bool Contains(T data);

        public string PrettyPrint()
        {
            string leftString = LeftSubTree == null ? string.Empty : LeftSubTree.PrettyPrint();
            string rightString = RightSubTree == null ? string.Empty : RightSubTree.PrettyPrint();

            return $"{Data.ToString()}({leftString})({rightString})";
        }
        
    }
}
