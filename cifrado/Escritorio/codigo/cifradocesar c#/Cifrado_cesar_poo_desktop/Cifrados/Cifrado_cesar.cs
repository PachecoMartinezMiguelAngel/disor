using System;
namespace Cifrado_cesar_poo_desktop.Cifrados
{
    public class Cifrado_cesar : Cifrado.Cifrado
    {
        private Alfabeto.Alfabeto alfabeto;
        private int desplazamiento;

        public Cifrado_cesar(Alfabeto.Alfabeto alfabeto, int desplazamiento)
        {
            this.alfabeto = alfabeto;
            this.desplazamiento = desplazamiento;
        }

        public void cambiar_desplazamiento(int desplazamiento)
        {
            this.desplazamiento = desplazamiento;
        }

        private char cifrar_caracter(char caracter)
        {
            if (this.alfabeto.esta_caracter_en_alfabeto(caracter))
            {
                if ((this.alfabeto.posicion_de_caracter(caracter) + this.desplazamiento) < this.alfabeto.numero_caracteres())
                {
                    return this.alfabeto.caracter_en_posicion(this.alfabeto.posicion_de_caracter(caracter) + this.desplazamiento);
                }

                else
                {
                    return this.alfabeto.caracter_en_posicion((this.alfabeto.posicion_de_caracter(caracter) + this.desplazamiento) % this.alfabeto.numero_caracteres());
                }
            }

            else
            {
                return caracter;
            }
        }

        public Texto.Texto cifrar_texto(Texto.Texto texto)
        {
            Texto_plano.Texto_plano texto_cifrado = new Texto_plano.Texto_plano("");
            foreach (char caracter in texto.obtener_texto())
            {
                texto_cifrado.agregar_caracter(this.cifrar_caracter(caracter));
            }

            return texto_cifrado;

        }
    }
}
