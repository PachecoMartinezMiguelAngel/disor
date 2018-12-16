using System;
using System.Collections;

namespace Cifrado_cesar_poo_desktop.Texto
{
    public interface Texto
    {
        int numero_caracteres();
        String obtener_texto();
        void agregar_grupos_caracteres(String grupo_caracteres);
        char caracter_en_posicion(int posicion);
        int posicion_de_caracter(char caracter);
        bool hay_caracter_en_posicion(int posicion);
        void agregar_caracter(char caracter);
        void eliminar_ultimo_caracter();
        ArrayList texto_en_grupos(int grupos);

    }
}
