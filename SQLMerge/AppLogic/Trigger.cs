using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLogic
{
    public class Trigger : IEqualityComparer<Trigger>
    {

       private string _nombre;
       public string Nombre { get { return _nombre; } set { _nombre = value; } }

       public Trigger(string nombre)
       {
           this._nombre = nombre;

       }

       public Trigger()
       {
          

       }

       public bool Equals(Trigger x, Trigger y)
       {

           //Check whether the compared objects reference the same data. 
           if (Object.ReferenceEquals(x, y)) return true;

           //Check whether any of the compared objects is null. 
           if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
               return false;

           //Check whether the products' properties are equal. 
           return x.Nombre == y.Nombre && x.Nombre == y.Nombre;
       }





       public int GetHashCode(Trigger product)
       {
           //Check whether the object is null 
           if (Object.ReferenceEquals(product, null)) return 0;

           //Get hash code for the Name field if it is not null. 
           int hashProductName = product.Nombre == null ? 0 : product.Nombre.GetHashCode();

           //Get hash code for the Code field. 
          // int hashProductCode = product.Nombre.GetHashCode();

           //Calculate the hash code for the product. 
           return hashProductName;
       }
             










    }
}
