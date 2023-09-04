using G253504_VashkevichLab5.Interfaces;

namespace G253504_VashkevichLab5.Collections;

public class MyCustomCollection<T> : ICustomCollection<T>
{
    private class Node<T>
    {
        public T Value;

        public Node(T value)
        {
            this.Value = value;
        }

        public Node<T>? Next { get; set; }
        public Node<T>? Prev { get; set; }
    }

    public MyCustomCollection()
    {
        this.head = null;
        this.current = null;
        this.tail = null;
        this.size = 0;
    }

    private Node<T>? head;
    private Node<T>? tail;
    private Node<T>? current;
    private int size;

    public T this[int index]
    {
        get
        {
            Node<T>? currNode = head;
            for (int i = 0; i <= index; i++)
            {
                if (currNode != null)
                {
                    if (i == index) return currNode.Value;
                    currNode = currNode.Next;
                }
            }

            return default;
        }
        set
        {
            Node<T>? currNode = head;
            for (int i = 0; i <= index; i++)
            {
                if (currNode != null)
                {
                    if (i == index) currNode.Value = value;
                    currNode = currNode.Next;
                }
            }
        }
    }

    public int Count => size;

    public void Reset()
    {
        current = head;
    }

    public void Next()
    {
        if (current == null)
            throw new InvalidOperationException();
        current = current.Next;
    }

    public T Current()
    {
        if (current == null)
        {
            throw new InvalidOperationException();
        }
        return current.Value;
    }

    public bool IsNull()
    {
        if (current == null)
        {
            return true;
        }
        return false;
    }

    public void Add(T item)
    {
        if (head == null)
        {
            head = new Node<T>(item);
            tail = head;
            current = head;
        }
        else
        {
            tail.Next = new Node<T>(item);
            tail = tail.Next;
        }

        size++;
    }

    private bool Contains(T item)
    {
        Node<T>? node = head;
        while (node != null)
        {
            if (node.Value != null && node.Value.Equals(item))
            {
                return true;
            }

            node = node.Next;
        }

        return false;
    }

    public void Remove(T item)
    {
        if (Contains(item))
        {
            Node<T>? node = head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    size--;
                    if (node.Prev != null)
                    {
                        node.Prev.Next = node.Next;
                    }

                    if (node.Next == null)
                    {
                        tail = node.Prev;
                    }
                    else
                    {
                        node.Next.Prev = node.Prev;
                    }
                }
                else
                {
                    if (node.Next != null)
                    {
                        node.Next.Prev = null;
                        head = node.Next;
                    }
                    else
                    {
                        head = null;
                        return;
                    }
                }
            }

            node = node.Next;
            Reset();
        }
        else
        {
            throw new InvalidOperationException("Item not found");
        }
    }


    public T? RemoveCurrent()
    {
        if (current == null)
            throw new InvalidOperationException();

        T result = current.Value;

        if (current.Prev != null)
        {
            current.Prev.Next = current.Next;
            if (current.Next == null)
            {
                tail = current.Prev;
            }
            else
            {
                current.Next.Prev = current.Prev;
            }
        }
        else
        {
            if (current.Next != null)
            {
                current.Next.Prev = null;
                head = current.Next;
            }
            else
            {
                head = null;
                current = null;
            }
        }

        current = head;
        size--;
        return result;
    }
}