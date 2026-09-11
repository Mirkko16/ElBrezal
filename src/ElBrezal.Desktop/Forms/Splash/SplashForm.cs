namespace ElBrezal.Desktop.Forms.Splash
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();

            Load += SplashForm_Load;
            splashTimer.Tick += SplashTimer_Tick;
        }

        private void SplashForm_Load(object? sender, EventArgs e)
        {
            splashTimer.Start();
        }

        private void SplashTimer_Tick(object? sender, EventArgs e)
        {
            splashTimer.Stop();
            Close();
        }
    }
}