using System;
namespace Cifrado_cesar_poo_desktop.Alfabeto
{
    public interface Alfabeto
    {
        int numero_caracteres();
        char caracter_en_posicion(int posicion);
        int posicion_de_caracter(char caracter);
        bool esta_caracter_en_alfabeto(char caracter);
    }
}
