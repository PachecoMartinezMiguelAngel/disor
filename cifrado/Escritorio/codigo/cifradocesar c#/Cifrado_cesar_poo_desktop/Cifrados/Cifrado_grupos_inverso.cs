using System;
namespace Cifrado_cesar_poo_desktop.Cifrados
{
    public class Cifrado_grupos_inversos : Cifrado.Cifrado
    {
        private Cifrado_inverso cifrado_inverso;
        private int grupos;

        public Cifrado_grupos_inversos(int grupos)
        {
            cifrado_inverso = new Cifrado_inverso();
            this.grupos = grupos;
        }

        public Texto.Texto cifrar_texto(Texto.Texto texto)
        {
            Texto_plano.Texto_plano texto_cifrado = new Texto_plano.Texto_plano("");
            foreach (String grupo in texto.texto_en_grupos(this.grupos))
            {
                texto_cifrado.agregar_grupos_caracteres(cifrado_inverso.cifrar_texto(new Texto_plano.Texto_plano(grupo)).obtener_texto());
            }

            return texto_cifrado;
        }

        public void cambiar_grupos(int grupos)
        {
            this.grupos = grupos;
        }
    }
}
