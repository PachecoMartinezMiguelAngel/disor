using System;
using System.Collections;

namespace Cifrado_cesar_poo_desktop.Texto_plano
{
    public class Texto_plano : Texto.Texto
    {
        private String texto;

        public Texto_plano(String texto)
        {
            this.texto = texto;
        }

        public void agregar_caracter(char caracter)
        {
            this.texto += caracter;
        }

        public void agregar_grupos_caracteres(string grupo_caracteres)
        {
            this.texto += grupo_caracteres;
        }

        public char caracter_en_posicion(int posicion)
        {
            return this.texto[posicion];
        }

        public void eliminar_ultimo_caracter()
        {
            if (this.texto.Length > 0)
            {
                this.texto = this.texto.Substring(0, this.texto.Length - 1);
            }

        }

        public bool hay_caracter_en_posicion(int posicion)
        {
            return posicion < this.texto.Length;
        }

        public int numero_caracteres()
        {
            return this.texto.Length;
        }

        public string obtener_texto()
        {
            return this.texto;
        }

        public int posicion_de_caracter(char caracter)
        {
            return this.texto.IndexOf(caracter);
        }

        public ArrayList texto_en_grupos(int grupos)
        {
            String grupos_caracteres = "";
            ArrayList respuesta_en_grupos = new ArrayList();

            foreach (char caracter in this.texto)
            {
                grupos_caracteres += caracter;

                if (grupos_caracteres.Length == grupos)
                {
                    respuesta_en_grupos.Add(grupos_caracteres);
                    grupos_caracteres = "";
                }
            }

            return respuesta_en_grupos;
        }
    }
}
