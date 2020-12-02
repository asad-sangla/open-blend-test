namespace Interview_test
{
    public class BinaryTree<T> where T : class
    {
        public T NodeValue { get; set; }
        public BinaryTree<T> LeftBranch { get; set; }
        public BinaryTree<T> RightBranch { get; set; }

        public int Count()
        {
            return CountNodes(this);

            static int CountNodes(BinaryTree<T> tree) => tree?.NodeValue == null
                ? 0
                : 1 + CountNodes(tree.LeftBranch) + CountNodes(tree.RightBranch);
        }
    }
}