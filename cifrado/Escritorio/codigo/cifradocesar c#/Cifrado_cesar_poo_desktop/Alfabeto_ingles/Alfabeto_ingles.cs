using System;
namespace Cifrado_cesar_poo_desktop.Alfabeto_ingles
{
    public class Alfabeto_ingles : Alfabeto.Alfabeto
    {
        private String alfabeto;

        public Alfabeto_ingles()
        {
            this.alfabeto = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        }

        public char caracter_en_posicion(int posicion)
        {
            return this.alfabeto[posicion];
        }

        public bool esta_caracter_en_alfabeto(char caracter)
        {
            if (this.alfabeto.IndexOf(caracter) >= 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public int numero_caracteres()
        {
            return this.alfabeto.Length;
        }

        public int posicion_de_caracter(char caracter)
        {
            return this.alfabeto.IndexOf(caracter);
        }
    }
}
