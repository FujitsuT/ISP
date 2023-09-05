using System.Collections;
using G253504_VashkevichLab5.Exeptions;
using G253504_VashkevichLab5.Interfaces;

namespace G253504_VashkevichLab5.Collections;

public class MyCustomCollection<T> : IEnumerable<T>, ICustomCollection<T>
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
            if (index < 0 || index >= size || currNode == null)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i <= index; i++)
            {
                if (currNode != null)
                {
                    if (i == index) return currNode.Value;

                    if (currNode.Next == null)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    currNode = currNode.Next;
                }
            }

            return default;
        }
        set
        {
            Node<T>? currNode = head;
            if (index < 0 || index >= size || currNode == null)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i <= index; i++)
            {
                if (currNode != null)
                {
                    if (currNode.Next == null)
                    {
                        throw new IndexOutOfRangeException();
                    }

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
        Node<T> node = new(item);
        if (head == null)
        {
            current = node;
            head = node;
            tail = node;
        }
        else
        {
            tail.Next = node;
            node.Prev = tail;
            tail = node;
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
        Node<T>? node = head;
        if (!this.Contains(item))
        {
            throw new RemoveExeption("Item not found");
        }

        while (node != null)
        {
            if (node.Value.Equals(item))
            {
                size--;
                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;

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
        }
        this.Reset();
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

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}