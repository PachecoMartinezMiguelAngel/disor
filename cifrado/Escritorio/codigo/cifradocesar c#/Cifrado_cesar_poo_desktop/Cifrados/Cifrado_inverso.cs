using System;
namespace Cifrado_cesar_poo_desktop.Cifrados
{
    public class Cifrado_inverso : Cifrado.Cifrado
    {


        public Texto.Texto cifrar_texto(Texto.Texto texto)
        {
            char[] charArray = texto.obtener_texto().ToCharArray();
            Array.Reverse(charArray);
            return new Texto_plano.Texto_plano(new string(charArray));
        }
    }
}
