using LanguageExt;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace QuestionOnePB
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = new SinglyLinkedList<int>();//3, 4, 5, 6, 7, 8
        var ls1 =    ls.InsertAt(0, 3).InsertAt(1, 4).InsertAt(2, 5).InsertAt(3, 6).InsertAt(4, 7).InsertAt(5, 8);
            Console.WriteLine($"List: {ls1}");
              var ls2 = ls1.InsertAt(5, 10);
             Console.WriteLine($"List: {ls2}");
 

     public class Node<T> //https://www.c-sharpcorner.com/article/linked-list-implementation-in-c-sharp/
    {
         public T Data { get; }
       public Node<T> Next { get; }
        public Node(T d, Node<T> next)
        {
            Data = d;
            Next = next;
        }

        public override string ToString()
        {
         string  nextValue =  Next != null ? Next.ToString() : "";
          return  $"{Data.ToString()},{nextValue}";
        }
    }
    internal class SinglyLinkedList<T>
    {

        public Node<T> head;

        public SinglyLinkedList(Node<T> node)
        {

            head = node;
        }

        public SinglyLinkedList() : this( default(Node<T>) ) { }

        public override string ToString()
        {
            return head != null ? $"[{head.ToString()}]" : "[]";        }

      

        public SinglyLinkedList<T> InsertAt(int i, T value)
            => new SinglyLinkedList<T>(RecourseInsertAt(i, value, head));

        private Node<T> RecourseInsertAt(int i, T value, Node<T> node)
        => i == 0 ? new Node<T>(value, node) : new Node<T>(node.Data, RecourseInsertAt(i - 1, value, node.Next));


        //public SinglyLinkedList<T> RemoveAt(int i)
        // => new SinglyLinkedList<T>(RecourseInsertAt(i, value, head));

        //private Node<T> RecourseRemoveAt(int i, T value, Node<T> node)
        //=> i == 0 ? new Node<T>(node.Next.Data,, node) : new Node<T>(node.Data, RecourseRemoveAt(i - 1, value, node.Next));

        // RemoveAt removes the item at the given index
        //   public static SinglyLinkedList<T> RemoveAt<T>(  int m)


        // TakeWhile takes a predicate, and traverses the list yielding all items until it find one that fails the predicate
        //   public SinglyLinkedList<T> TakeWhile<T>(  Func<T, bool> pred)


        // DropWhile works similarly, but excludes all items at the front of the list
        // public static SinglyLinkedList<T> DropWhile<T>(  Func<T, bool> pred)


    }
}
