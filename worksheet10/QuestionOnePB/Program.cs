using LanguageExt;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using LanguageExt.SomeHelp;

using System.Linq;
using static LanguageExt.Prelude;
namespace QuestionOnePB
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = new SinglyLinkedList<int>();//3, 4, 5, 6, 7, 8
            var ls1 = ls.InsertAt(0, 3).InsertAt(1, 4).InsertAt(2, 5).InsertAt(3, 6).InsertAt(4, 7).InsertAt(5, 8);
            Console.WriteLine($"List: {ls1}");
            var ls2 = ls1.InsertAt(5, 10);
            Console.WriteLine($"List: {ls2}");
            var ls3 = ls2.RemoveAt(5);
            Console.WriteLine($"List: {ls3}");
            var ls4 = ls3.TakeWhile(x => x <= 5);
            Console.WriteLine($"List: {ls4}");
            var ls5 = ls3.DropWhile(x => x <= 5);
            Console.WriteLine($"List: {ls5}");
            //Console.WriteLine("Hello World!");
        }
    }

     
    public class Node<T> //https://www.c-sharpcorner.com/article/linked-list-implementation-in-c-sharp/
    {
        public T Data { get; }
        public  Option<Node<T>>  Next { get; }
        public Node(T d,  Option<Node<T>>  next)
        {
           
            Data = d;
            Next = next ;
        }

       

        public override string ToString()
        {
            string nextValue = Next != null ? Next.ToString() : "";
            return $"{Data.ToString()},{nextValue}";
        }
    }
    internal class SinglyLinkedList<T>
    {

        public Option<Node<T>> head;

        public SinglyLinkedList(Option<Node<T>> node)
        {

            head = node;
        }

        public SinglyLinkedList() : this(None) { }

        public override string ToString()
        {
            return head != null ? $"[{head.ToString()}]" : "[]";
        }



        public SinglyLinkedList<T> InsertAt(int i, T value)
            => new SinglyLinkedList<T>(RecourseInsertAt(i, value, head));

        private Node<T> RecourseInsertAt(int i, T value, Option<Node<T>> node)
        =>  i == 0 || node.Head().Next.IsNone ? new Node<T>(value, node) :  new Node<T>( node.Head().Data , RecourseInsertAt(i - 1, value, node.Head().Next )) ;


        public SinglyLinkedList<T> RemoveAt(int i)
         => new SinglyLinkedList<T>(RecourseRemoveAt(i,  head));

        private Option<Node<T>> RecourseRemoveAt(int i, Option<Node<T>> node)
        => i == 0 || node.IsNone ? node.Bind(n => n.Next): 
           Some(new Node<T>(node.Head().Data, RecourseRemoveAt(i - 1 , node.Head().Next)));


       public SinglyLinkedList<T> TakeWhile( Func<T, bool> pred)
         => new SinglyLinkedList<T>(TakeWhileRecourse(head, pred));

        private Option<Node<T>> TakeWhileRecourse(Option<Node<T>> node, Func<T, bool> pred)
        => !pred(node.Head().Data) ? None : Some(new Node<T>(node.Head().Data, TakeWhileRecourse(node.Head().Next, pred)));


        public SinglyLinkedList<T> DropWhile(Func<T, bool> pred)
                => new SinglyLinkedList<T>(DropWhileRecourse(head, pred));

        private Option<Node<T>> DropWhileRecourse(Option<Node<T>> node, Func<T, bool> pred)
        =>  !pred(node.Head().Data) || node.IsNone ? node : DropWhileRecourse(node.Head().Next, pred);



    }
}
