namespace Aseguradora.Aplicacion;

public class Titular : Persona
{
    public string? Direccion {get; set;}
    public string? Email {get; set;}
    public Titular(int dni, string apellido, string nombre):base(dni, apellido, nombre){}
    public Titular(int dni, string apellido, string nombre,string direccion,string email) : base(dni, apellido, nombre) { 
        Direccion = direccion;
        Email = email;
    }

    public Titular(){
        
    }

    public override string ToString()
    {
        // EJ de toString: 
        // 1: DNI:44130300 Apellido:Macias Nombre:Luciano
        string str = base.ToString();
        if(Direccion != null){
            // 1: DNI:44130300 Apellido:Macias Nombre:Luciano Direccion:25 N545
            str += $" Direccion:{Direccion}";
        }
        if(Telefono != null){
            // 1: DNI:44130300 Apellido:Macias Nombre:Luciano Direccion:25 N545 Telefono:221-1231234
            str += $" Telefono:{Telefono}";
        }
        if(Email != null){
            // 1: DNI:44130300 Apellido:Macias Nombre:Luciano Direccion:25 N545 Telefono:221-1231234 Email:lumacias@hotmail.com
            str += $" Email:{Email}";
        }

        return str;
    }
}