using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise_Liked_List_A
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node START;

        public CircularList()
        {
            START = null;
        }
        public void addNote()/*Method untuk menambahkan sebuah Node kedalam list*/
        {
            int nim;
            string nm;
            Console.Write("\nMasukkan nomor Mahasiswa: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama Mahasiswa: ");
            nm= Console.ReadLine();
            Node nodeBaru = new Node();
            nodeBaru.noMhs = nim;
            nodeBaru.nama = nm;

            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nNomor sama tidak diijinkan\n");
                    return;
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }
            /*Menemukan lokasi node baru di dalam list*/

            Node previous, current;

            previous = START;
            current = START;

            while ((current != null) && (nim >= current.noMhs))
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nNomor mahasiswa sama tidak diijinkan\n");
                    return ;
                }
                previous = current;
                current = current.next;
            }
            /*Node baru akan ditempatkan diantara previous dan current*/

            nodeBaru.next = current;
            previous.next = nodeBaru;
        }

        /*Method untuk menghapus node tertentu didalam list*/
        public bool delNode(int nim)
        {
            Node previous,current;
            previous = current = null;
            /*Check apakah Node yang dimaksud ada dalam list atau tidak*/
            if (Search (nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        
        public bool Search(int rollNo, ref Node previous, ref Node current)/*Seraches for the specified node*/
        {
            for (previous= current = START.next; current != START; previous = current, current= current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*returns true if the node is foud*/
            }
            if (rollNo == START.rollNumber)/*If the node is present at the ende*/
                return true;
            else
                return false;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true ;
            else
                return false ;
        }

        public void travarse()/*Traverses all the nodes of the list*/
        {
            if (listEmpty())
            Console.WriteLine("\nList is Empty");
            else
        }
    }
}
