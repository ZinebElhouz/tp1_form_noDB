using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp1_form
{
    public partial class Form1 : Form
    {

        List<Etudiant> listEtudiant = new List<Etudiant>();
        int? selectedIndex = null;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_ajout.Enabled = true;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_delete.Enabled = true;
            btn_edit.Enabled = true;
            btn_ajout.Enabled = false;
            selectedIndex = comboBox1.SelectedIndex;
            Etudiant selected = listEtudiant[comboBox1.SelectedIndex];
            textBox2.Text = selected.cin;
            textBox1.Text = selected.nom;
            textBox3.Text = selected.prenom;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string message = " voulez vous ajouter cet etudiant ? ";
            string title = "confirmer l'ajout !";
            MessageBoxButtons btns = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, btns);
            if (result == DialogResult.Yes)
            {
                Etudiant et = new Etudiant();
                et.cin = textBox2.Text;
                et.nom = textBox1.Text;
                et.prenom = textBox3.Text;
                listEtudiant.Add(et);
                comboBox1.Items.Add(et.cin +"  "+ et.nom + "  " + et.prenom);            
            }  
            selectedIndex = null;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedIndex == null) return;
            string message = " etes-vous sur supprimer cet etudiant ?  ";
            string title = "confirmer la suppression";
            MessageBoxButtons btns = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, btns);
            if (result == DialogResult.Yes)
            {
                comboBox1.Items.RemoveAt(selectedIndex.Value);
                listEtudiant.RemoveAt(selectedIndex.Value);
                selectedIndex = null;
            }
            btn_ajout.Enabled = true;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string message = " voulez vous modifier cet etudiant ? ";
            string title = " confirmer la modification !";
            MessageBoxButtons btns = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, btns);
            if (result == DialogResult.Yes)
            {
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                if (selectedIndex == null) return;
                Etudiant et = new Etudiant();
                et.cin = textBox2.Text;
                et.nom = textBox1.Text;
                et.prenom = textBox3.Text;
                listEtudiant.RemoveAt(selectedIndex.Value);
                listEtudiant.Insert(selectedIndex.Value, et);
                comboBox1.Items.Insert(selectedIndex.Value, et.cin + "  " + et.nom + "  " + et.prenom);
            }
            selectedIndex = null;
            btn_ajout.Enabled = true;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

    

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
