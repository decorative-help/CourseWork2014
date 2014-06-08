﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Linq;
using System.ServiceModel;
using CommunicationInterface;
using MappingDLL;

namespace Kursach
{
    public partial class clients : Form
    {
        public clients()
        {
            InitializeComponent();
        }

        private void clients_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "clientsDataSet.Clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.clientsDataSet.Clients);
            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();
            List<Client> litr =  service.getClients();
            /*dataGridView1.RowCount = litr.Count;
            for (int i = 0; i< litr.Count; i++)
            {
                dataGridView1[0,0].Value = litr[i].Id;
            }*/
            var bindinglist = new BindingList<Client>(litr);
            var source = new BindingSource(bindinglist, null);
            dataGridView1.DataSource = source;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addclient form = new addclient();
            form.ShowDialog();
        }
    }
}
