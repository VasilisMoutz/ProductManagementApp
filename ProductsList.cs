using Microsoft.VisualBasic;

namespace ProductManagementApp
{
    internal class ProductsList<T>
    {
        public GenericNode<T>? Head { get; set; }
        public GenericNode<T>? Tail { get; set; }
        public int TotalItems { get; set; }
        

        public ProductsList()
        {
            Head = null;
            Tail = null;
            TotalItems = 0;
        }

        public void Insert(T t)
        {
            // Initialise node for insert
            GenericNode<T>? node;

            // Check if node already exists
            node = GetNodePosition(t);
            if (node != null) 
            {
                node.Count ++;
                return;
            }

            //else initialize node and continue to other actions
            node = new() 
            {
                Value = t,
                Count = 1
            };

            TotalItems++;

            // If List is empty 
            if (IsEmpty())
            {
                node.Prev = null;
                node.Next = null;
                Head = node;
                Tail = node;
                return;
            }

            // Else Add item to the end of the list.
            node.Prev = Tail;
            Tail!.Next = node;
            Tail = node;
        }

        public GenericNode<T>? GetNodePosition(T t)
        {
            if (IsEmpty())
            {
                return null;
            }

            for (GenericNode<T>? node = Head; node != null; node = node.Next)
            {
                if (node.Value!.Equals(t))
                {
                    return node;
                }
            }

            return null;
        }

        public void SortByValueAsc()
        {
            if (IsEmpty())
            {
                System.Console.WriteLine("List is Empty");
                return;
            }


            for (GenericNode<T>? nodeX = Head; nodeX != null; nodeX = nodeX.Next)
            {
                //Initialise a minimum value to be compared
                T? min = nodeX.Value;
                GenericNode<T> minPosition = nodeX;
                bool foundSmaller = false;

                for (GenericNode<T>? nodeY = nodeX; nodeY != null; nodeY = nodeY.Next)
                {
                    //Convert values to string to compare them.
                    string? value1 = (string)(object)(min);
                    string? value2 = (string)(object)nodeY.Value;

                    if(value2!.CompareTo(value1) == -1)
                    {
                        foundSmaller = true;
                        min = nodeY.Value;
                        minPosition = nodeY;
                    }
                }

                if (foundSmaller) 
                {
                    Swap(nodeX, minPosition);
                }
                
            }
        }

        public void SortByFrequenctDesc() 
        {
            if (IsEmpty())
            {
                System.Console.WriteLine("List is Empty");
                return;
            }

            for (GenericNode<T>? nodeX = Head; nodeX!= null; nodeX = nodeX.Next)
            {
                int max = nodeX.Count;
                bool foundLarger = false;
                GenericNode<T> maxPosition = nodeX;

                for (GenericNode<T>? nodeY = nodeX; nodeY != null; nodeY = nodeY.Next)
                {
                    //Compare Values
                    if (nodeY.Count > max)
                    {
                        max = nodeY.Count;
                        foundLarger = true;
                        maxPosition = nodeY;
                    }
                }

                if (foundLarger) 
                {
                    Swap(nodeX, maxPosition);
                }
            }
        }

        public void Swap(GenericNode<T> x, GenericNode<T> y)
        {
            T? tempValue = x.Value;
            int tempCount = x.Count;
            x.Value = y.Value;
            x.Count = y.Count;
            y.Value = tempValue;
            y.Count = tempCount;
        }


        public void Traverse()
        {
            if (IsEmpty())
            {
                System.Console.WriteLine("List is Empty");
                return;
            }

            for (GenericNode<T>? node = Head; node != null; node = node.Next)
            {
                System.Console.WriteLine($"{node.Count} {node.Value}");
            }
        }

        public bool IsEmpty()
        {
            return Head == null;
        }
    }
}