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

        public abstract int Size();

        public override string ToString()
        {
            string leftString = LeftSubTree == null ? string.Empty : LeftSubTree.ToString();
            string rightString = RightSubTree == null ? string.Empty : RightSubTree.ToString();

            return $"{Data.ToString()}({leftString})({rightString})";
        }

    }
}
