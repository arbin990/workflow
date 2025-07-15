using TDD.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        var cafetera = new Cafetera(100); 
        var medidorAzucar = new  MedidorAzucar(50); 
        var vasoPequeno = new Vaso("pequenio"); 
        var vasoMediano = new Vaso("mediano"); 
        var vasoGrande = new Vaso("grande");  

        var maquina = new MaquinaCafe(cafetera, medidorAzucar, vasoPequeno, vasoMediano, vasoGrande);

        Console.WriteLine(maquina.GetVasoDeCafe("mediano", 2, 2));
        Console.WriteLine(maquina.GetVasoDeCafe("grande", 2, 3));
        Console.WriteLine(maquina.GetVasoDeCafe("pequenio", 5, 0));
        Console.WriteLine(maquina.GetVasoDeCafe("grande", 1, 5)); 
        Console.WriteLine(maquina.GetVasoDeCafe("pequenio", 10, 1)); 
    }
}