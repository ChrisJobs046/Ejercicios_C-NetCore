using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using ScrapySharp.Extensions;
using HtmlAgilityPack;


namespace Tarea_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                           Multiprograma");
            Console.WriteLine("                         Presentado por ");
            Console.WriteLine("                         Christopher Alexander R.Q");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _");

            Program p = new Program();
            p.ListarOpciones();
            
        }

        public void ListarOpciones(){
            
            string opcion = "0";

            do{
                Console.WriteLine("Elija la opcion deseada!!!!!\n" + 
                "\n1. Opcion 1" +
                "\n2. Opcion 2" +
                "\n3. Opcion 3" +
                "\n3. Opcion 4" +
                "\n3. Opcion 5" +
                "\n3. Opcion 6" +
                "\n3. Opcion 7");

                opcion = Console.ReadLine();
                Console.Clear();

                switch(opcion){

                    case "1":
                    Frases();
                    break;

                    case "2":
                    Contactos();
                    break;

                    case "3":
                    Matriculas();
                    break;

                    case "4":
                    Triangulo();
                    break;

                    case "5":
                    ExportarHTML exportarHTML = new ExportarHTML();
                    exportarHTML.Inicio();
                    break;

                    case "6":
                    URL();
                    break;

                    case "7":
                    Calificacion();
                    break;

                    case "0":
                    Console.WriteLine("Nos Vemos......");
                    Console.ReadKey();
                    break;

                    default:
                    Console.WriteLine("Usted a instroducido una opcion no valida, intentelo de nuevo😒😒😒");
                    break;

                }

            }while (opcion !="0");
            
        }

        public void Frases(){

            Console.WriteLine("Bienvenido a calcular vocales!!!");
            MatchCollection matches;
            Regex regex;

            Console.Write("Ingrese la frase deseada: ");
            string Phrase = Console.ReadLine().ToLower();

            regex = new Regex(@"(\s)");
            matches = regex.Matches(Phrase);
            Console.WriteLine("Se encontraron {0} espacios en blanco. ", matches.Count);

            regex = new Regex(@"([aeiou])");
            matches = regex.Matches(Phrase);
            Console.WriteLine("Se encontraron {0} vocales.", matches.Count);

            regex = new Regex(@"([bcdfghjklmñpqrstvwxyz])");
            matches = regex.Matches(Phrase);
            Console.WriteLine("Se encontraron {0} consonantes.", matches.Count);

        }

        static void Pausa(){
            Console.WriteLine("Presione enter para continuar");
            Console.ReadKey();
        }

        public void Contactos(){
            Console.WriteLine("Bienvenido a Datos de Contactos");
            Console.WriteLine("Matricula: 2018-5858");
            Console.ReadKey();
            Pausa();
            Console.WriteLine("Nombre: Christopher Alexander");
            Console.ReadKey();
            Pausa();
            Console.WriteLine("Apellido: Ramon Quezada");
            Console.ReadKey();
            Pausa();
            Console.WriteLine("Telefono: 829-533-9331");
            Console.ReadKey();
            Pausa();
            Console.WriteLine("Correo: ChrisJobs046@gmail.com");
            Console.ReadKey();
            Pausa();
            Console.WriteLine("Fin: Eso es todo por hoy....😁😁😁😁😁");
            Console.ReadKey();
        }

        public void Matriculas(){

            string cont = "";
            Console.WriteLine("Introduza un numero: ");
            cont = Console.ReadLine();
            int i = 0;
            string Matricula = "20185858";

            if(cont == Matricula){

                Console.WriteLine("El numero ingresado concuerda con la matricula!!! ");
            }else {

                Console.Write("No contiene todos los numeros de la matricula y son los siguientes: \n");

                while(i < cont.Length){

                if (cont.Substring(i, 1) == "2" || cont.Substring(i, 1) == "0" || cont.Substring(i, 1) == "1" || cont.Substring(i, 1) == "8" || cont.Substring(i, 1) == "5" || cont.Substring(i, 1) == "8" || cont.Substring(i, 1) == "5" || cont.Substring(i, 1) == "8"){

                    Console.WriteLine(cont.Substring(i,1));
                }
                i =i + 1;
            }
            Console.ReadKey();

            }
            
        }

        public void Triangulo(){
            Console.WriteLine("Bienvenido a  Determinar triangulo segun sus lados");
            int a,b,c;
            Console.WriteLine("Por favor introduzca el primer lado");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Por favor introduzca el segundo lado");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Por favor introduzca el tercer lado");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine("Los lados son {0},{1} y {2}",a,b,c);

            if(a == b ^ a == b ^ b == c){

                Console.WriteLine("El triangulo es equilatero");
            }
            else if ((a != b) ^ (a != c) ^ (b != c)){

                Console.WriteLine("El triangulo es escalano");
            }
            else{

                Console.WriteLine("El triangulo es isosceles");
            }
            Console.ReadLine();
        }

        class ExportarHTML{

            public string Leer(string txt){
                Console.Write(txt);
                string val = Console.ReadLine();
                if(val.Length < 1){
                    Leer(txt);
                }
                return val;
            }

            public void Inicio(){

                Console.Clear();
                Console.WriteLine("Bienvenido a capturar datos y general html");

                string nombre = Leer("Digite el nombre: ");
                string apellido = Leer("Digite el apellido: ");
                string telefono = Leer("Digite el telefono: ");

                string ruta = "C:\\Users\\Dell\\Desktop\\Septimo_Cuatrimestre\\Programacion 3\\Tarea_1";

                if(Directory.Exists(ruta) == false){
                    Directory.CreateDirectory(ruta);
                }

                string contenido = "<html>"+
                "<head>"+
                "</head>"+
                "<body>"+
                "<table border='1'><tr><th>Nombre</th><td>"+nombre+
                "</td></tr></tr></th>Apellido</th></td>"+apellido+
                "</td></tr></tr></th>Telefono</th></td>"+telefono+
                "</td></tr></table></body>"+
                "/html";

                File.WriteAllText("C:\\Users\\Dell\\Desktop\\Septimo_Cuatrimestre\\Programacion 3\\Tarea_1"+nombre+".html",contenido);

                string continuar = Leer("Desea coontinuar S/N");
                if(continuar.ToLower() == "S"){
                    Inicio();
                }
                Console.WriteLine("Adiosss...");
                Console.ReadKey();
            }
        }

        public void URL(){
            int parrafos =0, imagenes = 0, enlaces = 0, conten =0;


            Console.WriteLine("Bienvenido a aalcular objetos de una URL");
            Console.WriteLine("Ingrese la URL: ");
            string URL = Console.ReadLine();
            HtmlWeb web = new HtmlWeb();

            HtmlDocument doc = web.Load(URL);
            Console.WriteLine();

            foreach (var Nodo in doc.DocumentNode.CssSelect("p")){

                parrafos++;
            }
            Console.WriteLine($"El total de parrafos encontrados es!!!: {parrafos}");

            foreach (var Nodo in doc.DocumentNode.CssSelect("img")){

                imagenes++;
            }
            Console.WriteLine($"El total de imagenes encontradas es!!!: {imagenes}");

            foreach (var Nodo in doc.DocumentNode.CssSelect("a")){

                enlaces++;
            }
            Console.WriteLine($"El total de enlaces encontrados es!!!: {enlaces}");

            foreach (var Nodo in doc.DocumentNode.CssSelect("div")){

                conten++;
            }
            Console.WriteLine($"El total de contenedores encontrados es!!!!: {conten}");

            Console.Write("Eso es todo amigos adios...");
            //var doc = new HtmlAgilityPack.HtmlDocument();
            
            //HtmlWeb web = new HtmlWeb();
            
            //Console.WriteLine("Ingrese la URL: ");
            //doc = web.Load(Console.ReadLine());
            
            //var ress = doc.DocumentNode.SelectSingleNode("//div[@id='page-wrapper']").InnerText;

            //var dato = doc.DocumentNode.CssSelect("div");
            
            //Console.WriteLine(dato);
            
        }

        public void Calificacion(){

            Console.WriteLine("Bienvenido a calcular nota!");

            int n1, n2, n3;
            Console.Write("Ingrese su calificacion!!!!: ");
            int Calificacion = int.Parse(Console.ReadLine());
            
            if(Calificacion > 100){

                Console.WriteLine("La calificacion ingresada no puede ser mayor a 100");
            }
            else if((Calificacion >= 90) & (Calificacion <= 100)){

                n1 = Calificacion % 40;
                n2 = Calificacion % 30;
                n3 = Calificacion % 20;

                Console.WriteLine($"A=>:{n1}, {n2}, {n3}");
            }
            else if((Calificacion >= 80) & (Calificacion <=89)){

                n1 = Calificacion % 30;
                n2 = Calificacion % 30;
                n3 = Calificacion % 20;

                Console.WriteLine($"B=>:{n1}, {n2}, {n3}");
            }
            else if((Calificacion >=70) & (Calificacion <= 79)){

                n1 = Calificacion % 30;
                n2 = Calificacion % 30;
                n3 = Calificacion % 10;

                Console.WriteLine($"c=>:{n1}, {n2}, {n3}");
            }
            else if(Calificacion < 70){  
                Console.WriteLine("Usted se ha quemado!!! vagoooooo");
            }
            

            //n1 = Calificacion % 40;
            //n2 = Calificacion % 30;
            //n3 = Calificacion % 20;

            //Console.WriteLine($"A=>:{n1}, {n2}, {n3}");

            Console.ReadKey();

        }

    }

    
}
