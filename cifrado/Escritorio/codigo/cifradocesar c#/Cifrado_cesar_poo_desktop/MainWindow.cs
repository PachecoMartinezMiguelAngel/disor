using System;
using Gtk;
using Cifrado_cesar_poo_desktop.Texto_plano;
using Cifrado_cesar_poo_desktop.Alfabeto_ingles;
using Cifrado_cesar_poo_desktop.Cifrados;
public partial class MainWindow : Gtk.Window
{
    private Texto_plano texto_plano;
    private Alfabeto_ingles alfabeto_ingles;
    private Cifrado_cesar cifrado_cesar;
    private Cifrado_inverso cifrado_inverso;
    private Cifrado_grupos_inversos cifrado_grupos_inversos;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        this.texto_plano = new Texto_plano("");
        this.alfabeto_ingles = new Alfabeto_ingles();
        this.cifrado_cesar = new Cifrado_cesar(this.alfabeto_ingles,0);
        this.cifrado_inverso = new Cifrado_inverso();
        this.cifrado_grupos_inversos = new Cifrado_grupos_inversos(0);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnTextoKeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
        Console.WriteLine(args.Event.KeyValue);
        if(args.Event.KeyValue!=65288)
        {
            this.texto_plano.agregar_caracter((char)args.Event.Key);
            this.cifrado_cesar.cambiar_desplazamiento(Int16.Parse(desplazamiento.Buffer.Text));
            this.texto_cifrado.Buffer.Text = cifrado_cesar.cifrar_texto(this.texto_plano).obtener_texto();
            this.texto_inverso.Buffer.Text = cifrado_inverso.cifrar_texto(this.texto_plano).obtener_texto();
            this.cifrado_grupos_inversos.cambiar_grupos(Int16.Parse(grupo.Buffer.Text));
            this.texto_grupos.Buffer.Text = cifrado_grupos_inversos.cifrar_texto(this.texto_plano).obtener_texto();
        }

        else{
            this.texto_plano.eliminar_ultimo_caracter();
        }

        Console.WriteLine(texto_plano.obtener_texto());

    }
}
