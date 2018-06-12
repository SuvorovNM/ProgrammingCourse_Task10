using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Tree
    {
        public string data;//Значение элемента дерева
        public Tree left, right;//Правое и левое поддеревья
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
        public static void Count(Tree p, ref int rez)//Подсчет кол-ва элементов в дереве
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
            Tree p = new Tree(str);//Создание вершины дерева
            int left=0;
            //Подсчет кол-ва элементов в левом поддереве
            Count(tree.left,ref left);
            int right = 0;
            //Подсчет кол-ва элементов в правом поддереве
            Count(tree.right,ref right);
            //Если левое поддерево отсутствует, то добавляем на его место созданную вершину
            if (left == 0)
                tree.left = p;
            //Если правое поддерево отсутствует, то добавляем на его место созданную вершину
            else if (right == 0)
                tree.right = p;
            //Если слева и справа существуют поддеревья, то переход на ярус ниже и проверка там
            else
            {
                if (left > right)
                    Add(tree.right, str);
                else Add(tree.left, str);
            }
            return tree;
        }
        static void ShowTree(Tree p, int l)//Вывод дерева в консоли
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
            Add(newtree, "007");
            Add(newtree, "008");
            Add(newtree, "009");
            Console.WriteLine("Изначальное дерево: ");
            ShowTree(newtree, 0);
            int option = 1;
            bool OK;
            do
            {
                do
                {
                    Console.WriteLine("Чтобы добавить вершину введите 1, чтобы выйти из программы и вывести дерево - 0");
                    OK = Int32.TryParse(Console.ReadLine(), out option)&&(option==1||option==0);
                } while (!OK);
                if (option == 1)
                {
                    string str;
                    do
                    {
                        Console.WriteLine("Введите значение элемента: ");
                        str = Console.ReadLine();
                        str=str.Trim();
                    } while (str == "");
                    Add(newtree, str);
                }
            } while (option!=0);
            ShowTree(newtree, 0);
            Console.Read();
        }
    }
}
