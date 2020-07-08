using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
 using static LanguageExt.Prelude;

namespace QuestionTwoPB
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public abstract class Tree 
    {
        public Tree(string label) { Label = label; }
       
        public string Label { get; }
      
        public abstract Option<Tree> Match(Func<Tree, Option<Tree>> leaf, Func<List<Tree>,string, Option<Tree>> branch);
   
    }
    public static class TreeUtil
    {
        public static Tree Leaf(string label) => new Leaf(label);

        public static Tree Branch(List<Tree> subtrees, string label) => new Branch(subtrees, label);

        public static Option<Tree> Map(Tree @this, Func<Tree,bool> func) =>
            @this.Match(t => func(t).Equals(true) ? Some(t) : None, (Subtrees, Label) => func(@this).Equals(true) ? Branch( Subtrees.Where(i => Map(i, func ).IsSome ).ToList(), Label ) : (Option<Tree>) None) ;

        


        public static bool GetLocalisation(this Tree @this, Dictionary<string, string> dict)
        =>      dict.TryGetValue(@this.Label, out _) == true;
        
       
      
    }

    internal class Branch  : Tree 
    {
     

      
        public List<Tree> Subtrees { get; }

        public Branch( List<Tree > subtrees, string label) : base(label)
        {
            
            Subtrees = subtrees;
        }

      

       public override Option<Tree> Match(Func<Tree, Option<Tree>> leaf, Func<List<Tree>, string, Option<Tree>> branch) => branch(Subtrees, Label);
    }
    internal class Leaf  : Tree  
    {
    

        public Leaf(string label) : base(label)
        {
        
        }
      

         public override Option<Tree> Match(Func<Tree, Option<Tree>> leaf, Func<List<Tree>, string, Option<Tree>> branch)  => leaf(this);
    }
}
