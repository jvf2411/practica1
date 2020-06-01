using System;
using System.Data.SqlClient;
using System.Configuration;

namespace practica1
{
    class Program
    {
        static Isuplidores supli = new Suplidoresrepositorio();
        public static void Main(string[] args)
        {
            var estado = true;
            while (estado)
            {
                Console.WriteLine("Bienvendio, Que te gustaria hacer ? \n 1-Crear un suplidor\n 2-Generar un reporte \n 3-Buscar un suplidor\n 4-Actualizar\n 5-Eliminiar suplidor\n 6-Salir ");
                int resultado = int.Parse(Console.ReadLine());
                if (resultado == 1)
                {

                    Console.WriteLine("Cual es el nombre del suplidor? ");
                    string Nombre = Console.ReadLine();
                    Console.WriteLine("Cual es el nombre del Representante? ");
                    string Representante = Console.ReadLine();
                    Console.WriteLine("Cual es el RNC? ");
                    string RNC = Console.ReadLine();
                    Console.WriteLine("Cual es la direccion? ");
                    string Direccion = Console.ReadLine();
                    var creacion = supli.Create(new Suplidores() { nombre = Nombre, representante = Representante, rnc = RNC, direccion = Direccion, estado = 1 });
                    Console.WriteLine(creacion.Mensaje);
                    Console.ReadLine();



                }
                else if (resultado == 2)
                {
                    var mostrar = supli.GetAll();
                    Console.ReadLine();

                }
                else if (resultado == 3)
                {
                    Console.WriteLine("Ingrese el RNC del suplidor a buscar");
                    string reg = Console.ReadLine();
                    var buscar=supli.findbyrnc(reg);
                    Console.WriteLine(buscar.Mensaje);

                }
                else if (resultado==4)
                {
                    Console.WriteLine("Digita el RNC del suplidor a modificar\n");
                    string rnc = Console.ReadLine();
                        supli.findbyrnc(rnc);

                    
                    Console.WriteLine("Cual es el nombre del Representante? ");
                    string Representante = Console.ReadLine();
                    
                    Console.WriteLine("Cual es la nueva  direccion? ");
                    string Direccion = Console.ReadLine();
                    var actua=supli.upd(Representante, Direccion, rnc);
                    Console.WriteLine(actua.Mensaje);

                    Console.ReadLine();


                }
                else if (resultado==5)
                {
                    Console.WriteLine("Ingrese el RNC del suplidor a borrar");
                    string rnc = Console.ReadLine();
                    var borrar = supli.eliminar(rnc);
                    Console.WriteLine(borrar.Mensaje);

                }
                else if (resultado==6)
                {
                    break;
                }



            }
        }
    }
}
