using System;
using System.Collections.Generic;
using System.Text;

namespace practica1
{
    public class Operationresult
    {
       public bool Resultado { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }

        public Operationresult ( bool resultado)
        {
            this.Resultado = resultado;
        }
        public Operationresult(bool resultado, string mensaje) 
        {
            this.Resultado = resultado;
            this.Mensaje = mensaje;
        }
        public Operationresult(bool resultado, string mensaje, object data)
        {
            this.Resultado = resultado;
            this.Mensaje = mensaje;
            this.Data = data;
        }

        public Operationresult()
        {
        }
    }
}
