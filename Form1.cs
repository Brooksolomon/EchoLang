
using Guna.UI2.WinForms;
using System.Security.Cryptography.X509Certificates;

namespace EchoLang
{
    public partial class Form1 : Form
    {
        public homePanel hp;
        public dictpanel dp;
        public userspanel up;
        public languagesPanel lp;
        public lessonsPanel lsp;
        public coursesPanel cp;
        public profilePanel pp;


        public Form1()
        {
            hp = new homePanel();
            dp = new dictpanel();
            up = new userspanel();
            lp = new languagesPanel();
            lsp = new lessonsPanel();
            cp = new coursesPanel();
            pp = new profilePanel();

            hp.Visible = true;
            dp.Visible = false;
            up.Visible = false;
            lp.Visible = false;
            lsp.Visible = false;
            cp.Visible = false;
            pp.Visible = false;




            Controls.Add(hp);
            Controls.Add(dp);
            Controls.Add(up);
            Controls.Add(lp);
            Controls.Add(lsp);
            Controls.Add(cp);
            Controls.Add(pp);

            database.fetchAllUsers();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitializeComponent();
            this.Scroll += (o, e) => guna2Panel1.Location = new Point(0, 0);
            this.MouseWheel += (o, e) => guna2Panel1.Location = new Point(0, 0);


            btnHome.Checked = true;
        }

        private void btnCloser_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

            Controls.Remove(hp);
            hp = new homePanel();
            Controls.Add(hp);
            dp.Visible = false;
            up.Visible = false;
            lp.Visible = false;
            lsp.Visible = false;
            cp.Visible = false;
            pp.Visible = false;
        }

        private void btnDict_Click(object sender, EventArgs e)
        {
            hp.Visible = false;
            dp.Visible = true;
            up.Visible = false;
            lp.Visible = false;
            lsp.Visible = false;
            cp.Visible = false;
            pp.Visible = false;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            hp.Visible = false;
            dp.Visible = false;
            up.Visible = true;
            lp.Visible = false;
            lsp.Visible = false;
            cp.Visible = false;
            pp.Visible = false;
        }

        private void btnLanguages_Click(object sender, EventArgs e)
        {
            hp.Visible = false;
            dp.Visible = false;
            up.Visible = false;
            lp.Visible = true;
            lsp.Visible = false;
            cp.Visible = false;
            pp.Visible = false;
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            hp.Visible = false;
            dp.Visible = false;
            up.Visible = false;
            lp.Visible = false;
            lsp.Visible = true;
            cp.Visible = false;
            pp.Visible = false;
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            hp.Visible = false;
            dp.Visible = false;
            up.Visible = false;
            lp.Visible = false;
            lsp.Visible = false;
            cp.Visible = true;
            pp.Visible = false;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            hp.Visible = false;
            dp.Visible = false;
            up.Visible = false;
            lp.Visible = false;
            lsp.Visible = false;
            cp.Visible = false;
            pp.Visible = true;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Auth a1 = new Auth();
            a1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void controlPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }





}