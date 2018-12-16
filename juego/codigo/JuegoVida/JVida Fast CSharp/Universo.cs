using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace JuegoDeLaVida
{
    public partial class MainForm : Form
    {
        #region Fields
        private JuegoVida jv;
        private Grafiquito graf;
        private int GridSize = 400;
        private double OcupacionInicial = .5;
        private int EdadMaxima = 200;
        private string Algoritmo = "23/3";
        private Thread workerThread; 
        #endregion

        #region Constructor
        public MainForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            this.Shown += Form1_Shown;
            this.FormClosing += Form1_FormClosing;
            Inicializar();
        } 
        #endregion

        #region Private Methods
        private void Inicializar()
        {
            this.Controls.Remove(graf);
            jv = new JuegoVida(GridSize, GridSize, Algoritmo, EdadMaxima, this.OcupacionInicial);
            jv.FireUpdate += jv_FireUpdate;
            graf = new Grafiquito(GridSize, GridSize);
            graf.Dock = DockStyle.Fill;
            this.Controls.Add(graf);
        }

        private void Comenzar()
        {
            AbortWorker();
            workerThread = new Thread(jv.Jugar);
            workerThread.Priority = ThreadPriority.AboveNormal;
            workerThread.Start();
        }

        private void AbortWorker()
        {
            if (workerThread != null && workerThread.IsAlive)
            {
                workerThread.Abort();
                workerThread.Join();
            }
        }

     
        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            AbortWorker();
        }

        private void Form1_Shown(object sender, System.EventArgs e)
        {
            Comenzar();
        }

        private void jv_FireUpdate(object sender, FireUpdateEventArgs e)
        {
            foreach (Point nace in e.Nacidos)
            {
                graf.PlotBmp(nace.X, nace.Y, 1);
            }
            foreach (Point muere in e.Muertos)
            {
                graf.PlotBmp(muere.X, muere.Y, 0);
            }
            graf.Invalidate();
        }
        #endregion

       
    }
}