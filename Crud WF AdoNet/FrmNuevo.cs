﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_WF_AdoNet
{
    public partial class FrmNuevo : Form
    {
        private int? Id;
        public FrmNuevo(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            PeopleDB oPeopleDB = new PeopleDB();
            People oPeople = oPeopleDB.Get((int)Id);
            txtName.Text = oPeople.Name;
            txtEdad.Text = oPeople.Age.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeopleDB oPeopleDB = new PeopleDB();
            try
            {
                if (Id == null)
                {
                    oPeopleDB.Add(txtName.Text, int.Parse(txtEdad.Text));
                }
                else
                {
                    oPeopleDB.Update(txtName.Text, int.Parse(txtEdad.Text), (int)Id);
               
                }
                this.Close();

            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al interntar guardar: "+ex.Message);
            }
        }

        private void FrmNuevo_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
