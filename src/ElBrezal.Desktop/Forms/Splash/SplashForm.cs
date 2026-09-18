namespace ElBrezal.Desktop.Forms.Splash
{
    public partial class SplashForm : Form
    {
        private int progreso = 0;

        public SplashForm()
        {
            InitializeComponent();

            Load += SplashForm_Load;
            splashTimer.Tick += SplashTimer_Tick;
        }

        private void SplashForm_Load(object? sender, EventArgs e)
        {
            progreso = 0;

            progressBarCarga.Minimum = 0;
            progressBarCarga.Maximum = 100;
            progressBarCarga.Value = 0;

            lblEstado.Text = "Inicializando componentes...";
            lblPorcentaje.Text = "0%";

            // 30 ms x 100 pasos ≈ 3 segundos
            splashTimer.Interval = 30;
            splashTimer.Start();
        }

        private void SplashTimer_Tick(object? sender, EventArgs e)
        {
            progreso++;

            progressBarCarga.Value = progreso;
            lblPorcentaje.Text = $"{progreso}%";

            lblEstado.Text = progreso switch
            {
                <= 20 => "Inicializando componentes...",
                <= 40 => "Chequeando registro...",
                <= 60 => "Conectando a base de datos...",
                <= 80 => "Refrescando tablas...",
                <= 95 => "Preparando entorno de trabajo...",
                _ => "Sistema listo."
            };

            if (progreso >= 100)
            {
                splashTimer.Stop();
                Close();
            }
        }
    }
}