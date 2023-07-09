namespace Task5;

public class LinkedList<T>
{
    private sealed class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private LinkedListNode<T> head;
    private LinkedListNode<T> tail;

    public LinkedList()
    {
        head = null;
        tail = null;
    }

    public void PushFront(T value)
    {
        LinkedListNode<T> newNode = new LinkedListNode<T>(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
    }

    public void PushBack(T value)
    {
        LinkedListNode<T> newNode = new LinkedListNode<T>(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }
    
    public void PushAtIndex(T value, int index)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be a non-negative value.");
        }

        if (index == 0)
        {
            PushFront(value);
            return;
        }

        LinkedListNode<T> newNode = new LinkedListNode<T>(value);
        LinkedListNode<T> current = head;
        int currentIndex = 0;

        while (current != null && currentIndex < index - 1)
        {
            current = current.Next;
            currentIndex++;
        }
        Console.WriteLine(currentIndex);
        if (current == null)
        {
            throw new ArgumentOutOfRangeException(nameof(Index), "Index is out of range.");
        }

        newNode.Next = current.Next;
        current.Next = newNode;
    }
    
    public void PopFront()
    {
        if (head == null)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        head = head.Next;
    }
    
    public void PopFromEnd()
    {
        if (head == null)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        if (head.Next == null)
        {
            head = null;
            return;
        }

        LinkedListNode<T> current = head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }
        current.Next = null;
    }
    
    public void PopFromAtIndex(int index)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "index must be a non-negative value.");
        }

        if (head == null)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        if (index == 0)
        {
            PopFront();
            return;
        }

        LinkedListNode<T> current = head;
        int currentIndex = 0;

        while (current != null && currentIndex < index - 1)
        {
            current = current.Next;
            currentIndex++;
        }

        if (current == null || current.Next == null)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "index is out of range.");
        }

        current.Next = current.Next.Next;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be a non-negative value.");
            }

            LinkedListNode<T> current = head;
            int currentIndex = 0;

            while (current != null && currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            return current.Value;
        }
        set
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be a non-negative value.");
            }

            LinkedListNode<T> current = head;
            int currentIndex = 0;

            while (current != null && currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            current.Value = value;
        }
    }

}

