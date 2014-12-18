using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLogic
{
    public class StoredProcedure : IEqualityComparer<StoredProcedure>

    {

       private string _nombre;

       public string Nombre { get { return _nombre; } set { _nombre = value; } }

       public StoredProcedure(string nombre)
       {
           this._nombre = nombre;

       }

       public StoredProcedure()
       {
          

       }

       public bool Equals(StoredProcedure x, StoredProcedure y)
       {

           //Check whether the compared objects reference the same data. 
           if (Object.ReferenceEquals(x, y)) return true;

           //Check whether any of the compared objects is null. 
           if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
               return false;

           //Check whether the products' properties are equal. 
           return x.Nombre == y.Nombre && x.Nombre == y.Nombre;
       }




       //public override bool Equals(object obj)
       //{

       //    //Verifico que sea del mismo tipo
       //    if (obj.GetType() != typeof(StoredProcedure)) return false;

       //    //Valido que el objeto no sea null
       //    if (ReferenceEquals(null, obj)) return false;

       //    //Verifico si el objeto actual es igual al que recibo por parámetro
       //    if (ReferenceEquals(this, obj)) return true;
           


       //    return base.Equals(obj);
       //}


       public int GetHashCode(StoredProcedure product)
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





       //public override int GetHashCode()
       //{

       //    return unchecked(Nombre.GetHashCode() + Nombre.GetHashCode());

       //     //return base.GetHashCode();
       //}



    }
}
