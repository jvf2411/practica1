using System;
using System.Collections.Generic;
using System.Text;

namespace practica1
{
    public interface Isuplidores
    {
        Operationresult Create(Suplidores suplidores);
        Operationresult GetAll();
        Operationresult findbyrnc(string rnc);
        Operationresult upd(string nombre,string direccion, string rnc);
        Operationresult eliminar(string rnc);
    }
}
