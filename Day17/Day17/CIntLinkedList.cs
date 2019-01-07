namespace Day17
{
    public class CIntLinkedList
    {
        private Node current;
        private int _count = 1;
        
        public CIntLinkedList(int initial)
        {
            current = new Node(initial);   
        }

        public void Rotate(int steps)
        {            
            for (var i = 0; i < steps; i++)
            {
                current = current.Next;
            }
        }

        public int CurrentVal()
        {
            return current.Value;
        }

        public void InsertAfter(int val)
        {
            _count++;
            var newNode = new Node(val, current.Next, current);
            current.Next = newNode;
            current = newNode;
        }

    }

    public class Node
    {
        public Node Previous;
        public Node Next;
        public int Value;

        public Node(int value)
        {
            Value = value;
            Previous = this;
            Next = this;
        }

        public Node(int value, Node next, Node previous)
        {
            Next = next;
            Previous = previous;
            Value = value;
        }
    }
}