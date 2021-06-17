using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U6_Comentarios_Proyecto
{
    class Comentario
    {
        public string Autor { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string elComentario { get; set; }
        public string Ip { get; set; }
        public string Advertencia { get; set; }
        public int Like { get; set; }

        public int DisLike { get; set; }



        public override string ToString()
        {
            return String.Format($"Autor:{Autor} Fecha:{Fecha} ID:{Id} \n^{Advertencia}^ {elComentario} \nLikes:{Like} DisLikes{DisLike}\n====================================================================");
        }
    }
    class ComentariosR
    {

        public static void GuardarEnFile(List<Comentario> comentarios, string path)
        {
            StreamWriter textoFuera = null;
           
            try
            {
                textoFuera = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
                foreach (var comentario in comentarios)
                {                    
                    textoFuera.Write(comentario.Id + "|");
                    textoFuera.Write(comentario.Autor + "|");
                    textoFuera.Write(comentario.Fecha + "|");
                    textoFuera.Write(comentario.Advertencia + "|");                    
                    textoFuera.Write(comentario.elComentario + "|");
                    textoFuera.Write(comentario.Ip + "|");                    
                    textoFuera.Write(comentario.Like + "|");
                    textoFuera.Write(comentario.DisLike + "|");
                    textoFuera.WriteLine();
                }
            }
            catch (IOException Ex)
            {
                Console.WriteLine(Ex);
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                if (textoFuera != null)
                    textoFuera.Close();
            }
        }
        public static List<Comentario> LeerDeFile(string path)
        {
            List<Comentario> comentarios = new List<Comentario>();
            StreamReader TextoDetro = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));
            try
            {
                while (TextoDetro.Peek() != -1)
                {
                    string ord = TextoDetro.ReadLine();
                    string[] columns = ord.Split('|');
                    Comentario p = new Comentario();
                    p.Id = int.Parse(columns[0]);
                    p.Autor = columns[1];                                   
                    p.Fecha = DateTime.Parse(columns[2]);
                    p.Advertencia = columns[3];
                    p.elComentario = columns[4];                    
                    p.Ip = columns[5];
                    p.Like = int.Parse(columns[6]);
                    p.DisLike = int.Parse(columns[7]);
                    
                    comentarios.Add(p);
                }

            }
            catch (IOException)
            {
                Console.WriteLine("El Archivo no existe");
            }
            catch(Exception)
            {
                Console.WriteLine("Error");
            }
            TextoDetro.Close();
            return comentarios;
        }
        public static void Imprimir(string path)
        {
            List<Comentario> comentarios;

            comentarios = LeerDeFile(path);

            foreach(var c in comentarios)
            {
                Console.WriteLine(c);
            }
        }
        public static void DeMayorAMenorLikes(string path)
        {
            List<Comentario> comentarios;
            comentarios = LeerDeFile(path);
            var ordenar = from p in comentarios orderby p.Like descending select p;
            foreach(var p in ordenar)
            {
                Console.WriteLine(p);
            }

        }
        public static void DeMenorAMayorLikes(string path)
        {
            List<Comentario> comentarios;
            comentarios = LeerDeFile(path);
            var ordenar = from p in comentarios orderby p.Like ascending select p;
            foreach (var p in ordenar)
            {
                Console.WriteLine(p);
            }

        }
        public static void DeMayorAMenorDisLikes(string path)
        {
            List<Comentario> comentarios;
            comentarios = LeerDeFile(path);
            var ordenar = from p in comentarios orderby p.DisLike descending select p;
            foreach (var p in ordenar)
            {
                Console.WriteLine(p);
            }

        }
        public static void DeMenorAMayorDisLikes(string path)
        {
            List<Comentario> comentarios;
            comentarios = LeerDeFile(path);
            var ordenar = from p in comentarios orderby p.DisLike ascending select p;
            foreach (var p in ordenar)
            {
                Console.WriteLine(p);
            }

        }
        public static void MasAntiguos(String path)
        {
            List<Comentario> comentarios;
            comentarios = LeerDeFile (path);
            var ordenar = from p in comentarios orderby p.Fecha ascending select p;
            foreach (var c in ordenar)
            {
                Console.WriteLine(c);
            }
        }
        public static void MasNuevos(String path)
        {
            List<Comentario> comentarios;
            comentarios = LeerDeFile(path);
            var ordenar = from p in comentarios orderby p.Fecha descending select p;
            foreach (var c in ordenar)
            {
                Console.WriteLine(c);
            }
        }
        
        public void Agregar()
        {

        }
    }
   
    class Program
    {    

        static void Main(string[] args)
        {
            List<Comentario> comentarios = new List<Comentario>();

            comentarios.Add(new Comentario() { Autor = "Fedelobo", Id = 0001, Fecha = new DateTime(2016,4,20), elComentario = "Patata", Advertencia = "Inapropidado", Ip= "11231", Like = 20, DisLike= 7 });
            comentarios.Add(new Comentario() { Id = 0024, Autor = "Anastacia", Fecha = new DateTime(2020, 10, 20), elComentario = "Jaja", Advertencia = "Apropiado", Ip = "11231", Like = 216, DisLike = 14 });
            comentarios.Add(new Comentario() { Id = 0015, Autor = "Filoverto", Fecha = new DateTime(2002, 6, 20), elComentario = "lol xd", Advertencia = "Apropiado", Ip = "11231", Like = 216, DisLike = 14 });
            ComentariosR.GuardarEnFile(comentarios, @"C:\Test.TxT\ComentariosTest.txt");
            ComentariosR.LeerDeFile(@"C:\Test.TxT\ComentariosTest.txt");
            ComentariosR.Imprimir(@"C:\Test.TxT\ComentariosTest.txt");
            ComentariosR.MasNuevos(@"C:\Test.TxT\ComentariosTest.txt");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Comentar?");
            Console.WriteLine("s o n");
            string x = Console.ReadLine();
            while (x == "s")
            {               
                Console.Write("Nombre: ");
                string nombres = Console.ReadLine();
                Console.WriteLine("Comentario:");
                string coments = Console.ReadLine();
                Console.WriteLine("Ip:");
                int ip= int.Parse(Console.ReadLine());
                
                comentarios.Add(new Comentario() { Id = 15, Autor = nombres, elComentario = coments, Fecha = DateTime.Now, Ip = ip.ToString(), Advertencia = "Apropiado", Like = 0, DisLike = 0 });
                
                ComentariosR.GuardarEnFile(comentarios, @"C:\Test.TxT\ComentariosTest.txt");
                Console.WriteLine("=================================================================================");
                foreach (var p in comentarios)
                    Console.WriteLine(p);

                Console.WriteLine("=================================================================================");
                Console.WriteLine("Comentar?");
                Console.WriteLine("s o n");
                string a =Console.ReadLine();
                if (a == "s")
                {
                    x = "s";
                }
                else
                {
                    x = "n";
                }
            }
            ComentariosR.MasAntiguos(@"C:\Test.TxT\ComentariosTest.txt");
            Console.ReadKey();
        }
    }
}
