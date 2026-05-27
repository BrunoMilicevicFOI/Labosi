using System;
using System.Windows.Forms;
using VarazdinTourManager.Repositories;
using VarazdinTourManager.Models;

namespace _3.zadaca___VarazdinTourManager
{
    public partial class FrmLogin : Form
    {
        private Repozitorij _repozitorij = new Repozitorij();
        public static Zaposlenik PrijavljeniKorisnik { get; set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorIme.Text))
            {
                MessageBox.Show("Unesite korisničko ime!", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                MessageBox.Show("Unesite lozinku!", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Zaposlenik z = _repozitorij.AutenticirajZaposlenika(txtKorIme.Text.Trim(), txtLozinka.Text);

                if (z == null)
                {
                    MessageBox.Show("Pogrešno korisničko ime ili lozinka!", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLozinka.Clear();
                    return;
                }

                PrijavljeniKorisnik = z;
                FrmPregledTura frmPregledTura = new FrmPregledTura();
                Hide();
                frmPregledTura.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri prijavi: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}