using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Tree
    {
        public string data;
        public Tree left, right;
        public Tree()
        {
            data = "ROOT";
            left = null;
            right = null;
        }
        public Tree(string d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }
    class Program
    {
        const string AllLetters = "abcdefghijklmnopqrstuvwxyz";
        #region Check
        const string mistake = "Ошибка ввода!";
        static int CheckNumber(out int chislo)
        {
            bool OK;
            do
            {
                OK = Int32.TryParse(Console.ReadLine(), out chislo);
                if (!OK) Console.WriteLine(mistake);
            } while (!OK);
            return chislo;
        }
        static char CheckChar(out char letter)
        {
            bool OK;
            do
            {
                OK = Char.TryParse(Console.ReadLine(), out letter);
                if (!OK) Console.WriteLine(mistake);
            } while (!OK);
            return letter;
        }
        static int CheckNumber(out int chislo, int min)
        {
            bool OK;
            do
            {
                OK = Int32.TryParse(Console.ReadLine(), out chislo) && chislo >= min;
                if (!OK) Console.WriteLine(mistake);
            } while (!OK);
            return chislo;
        }
        static int CheckNumber(out int chislo, int min, int max)
        {
            bool OK;
            do
            {
                OK = Int32.TryParse(Console.ReadLine(), out chislo) && chislo >= min && chislo <= max;
                if (!OK) Console.WriteLine(mistake);
            } while (!OK);
            return chislo;
        }

        #endregion
        public static void Count(Tree p, ref int rez)
        {

            if (p != null)
            {
                //обход всего дерева и сравнение каждого элемента с ключом
                Count(p.left, ref rez);
                rez++;
                Count(p.right, ref rez);
            }
        }
        static Tree Add(Tree tree,string str)
        {
            //Tree p = tree;
            Tree p = new Tree(str);
            int left=0;
            Count(tree.left,ref left);
            int right = 0;
            Count(tree.right,ref right);
            if (left == 0)
                tree.left = p;
            else if (right == 0)
                tree.right = p;
            else
            {
                if (left > right)
                    Add(tree.right, str);
                else Add(tree.left, str);
            }
            return tree;
        }
        static void ShowTree(Tree p, int l)
        {
            if (p != null)
            {
                ShowTree(p.right, l + 3);
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.data);
                ShowTree(p.left, l + 3);
            }
        }
        static void Main(string[] args)
        {
            Tree newtree = new Tree();
            Add(newtree, "001");
            Add(newtree, "002");
            Add(newtree, "003");
            Add(newtree, "004");
            Add(newtree, "005");
            Add(newtree, "006");
            ShowTree(newtree, 0);
            Console.Read();
        }
    }
}
