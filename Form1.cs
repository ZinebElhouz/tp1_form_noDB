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
        string btn_confirm;
        List<Etudiant> listEtudiant = new List<Etudiant>();
        int? selectedIndex = null;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            btn_ajout.Enabled = true;
            btn_annuler.Enabled = false;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
            btn_confirmer.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_delete.Enabled = true;
            btn_edit.Enabled = true;
            btn_ajout.Enabled = false;
            selectedIndex = comboBox1.SelectedIndex;
            Etudiant selected = listEtudiant[comboBox1.SelectedIndex];
            textBox2.Text = selected.id.ToString();
            textBox1.Text = selected.nom;
            textBox3.Text = selected.prenom;
        }

        //button d'ajout
        private void button1_Click(object sender, EventArgs e)
        {
            btn_confirm = "ajout";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            btn_confirmer.Enabled = true;
            btn_annuler.Enabled = true;
            btn_ajout.Enabled = false; 
        }

        //button de suppression
        private void button2_Click(object sender, EventArgs e)
        {
            btn_confirm = "supp";
            btn_confirmer.Enabled = true;
            btn_annuler.Enabled = true;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;

            
        }

        //button de modification
        private void button3_Click(object sender, EventArgs e)
        {

            btn_confirm = "modifier";
            textBox2.Enabled = false;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            btn_confirmer.Enabled = true;
            btn_annuler.Enabled = true;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
        }

        //button de confirmation
        private void btn_confirmer_Click(object sender, EventArgs e)
        {
            switch (btn_confirm)
            {
                case ("ajout"):
                    string message = " voulez vous ajouter cet etudiant ? ";
                    string title = "confirmer l'ajout !";
                    MessageBoxButtons btns = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, btns);
                    if (result == DialogResult.Yes)
                    {
                        Etudiant et = new Etudiant();
                        et.id = Int32.Parse(textBox2.Text);
                        et.nom = textBox1.Text;
                        et.prenom = textBox3.Text;
                        listEtudiant.Add(et);
                        comboBox1.Items.Add(et.id);
                    }
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    btn_confirmer.Enabled = false;
                    btn_annuler.Enabled = false;
                    btn_ajout.Enabled = true;
                    selectedIndex = null;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    break;
                case ("supp"):
                    if (selectedIndex == null) return;
                    string message1 = " etes-vous sur supprimer cet etudiant ?  ";
                    string title1 = "confirmer la suppression";
                    MessageBoxButtons btns1 = MessageBoxButtons.YesNo;
                    DialogResult result1 = MessageBox.Show(message1, title1, btns1);
                    if (result1 == DialogResult.Yes)
                    {
                        comboBox1.Items.RemoveAt(selectedIndex.Value);
                        listEtudiant.RemoveAt(selectedIndex.Value);
                        selectedIndex = null;
                    }
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    btn_ajout.Enabled = true;
                    btn_delete.Enabled = false;
                    btn_edit.Enabled = false;
                    btn_confirmer.Enabled = false;
                    btn_annuler.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    break;
                case ("modifier"):
                    string message3 = " voulez vous modifier cet etudiant ? ";
                    string title3 = " confirmer la modification !";
                    MessageBoxButtons btns3 = MessageBoxButtons.YesNo;
                    DialogResult result3 = MessageBox.Show(message3, title3, btns3);
                    if (result3 == DialogResult.Yes)
                    {
                        comboBox1.Items.Remove(comboBox1.SelectedItem);
                        if (selectedIndex == null) return;
                        Etudiant et = new Etudiant();
                        et.id = Int32.Parse(textBox2.Text);
                        et.nom = textBox1.Text;
                        et.prenom = textBox3.Text;
                        listEtudiant.RemoveAt(selectedIndex.Value);
                        listEtudiant.Insert(selectedIndex.Value, et);
                        comboBox1.Items.Insert(selectedIndex.Value, et.id);
                    }
                    selectedIndex = null;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    btn_ajout.Enabled = true;
                    btn_delete.Enabled = false;
                    btn_edit.Enabled = false;
                    btn_confirmer.Enabled = false;
                    btn_annuler.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    break;

            }
        }

        //button d'annulation
        private void btn_annuler_Click(object sender, EventArgs e)
        {
            switch (btn_confirm)
            {
                case ("ajout"):
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    btn_confirmer.Enabled = false;
                    btn_annuler.Enabled = false;
                    btn_ajout.Enabled = true;
                    break;

                case ("supp"):

                    btn_confirmer.Enabled = false;
                    btn_annuler.Enabled = false;
                    btn_edit.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_ajout.Enabled = false;
                    break;

                case ("modifier"):
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    btn_confirmer.Enabled = false;
                    btn_annuler.Enabled = false;
                    btn_edit.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_ajout.Enabled = false;
                    break;
            }
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
