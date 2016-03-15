using KCNEBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KCNEUserInterface
{
    public partial class MainForm : Form
    {
        private const string VERSION_STRING_FORMAT = "{0:0.0#}";

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            KCNEManager.Instance.Init();

            for (int i = 0; i < KCNEManager.versionNumbers.Length; ++i)
            {
                _versionBox.Items.Add(String.Format(VERSION_STRING_FORMAT, KCNEManager.versionNumbers[i]));
            }

            // set default version number
            _versionBox.SelectedIndex = KCNEManager.DEFAULT_VERSION_NUMBER_INDEX;

            _stopButton.Enabled = false;
            _startButton.Enabled = true;

            // set listeners
            KCNEManager.StopEvent += InvokeStop;
        }

        private void InvokeStart()
        {
            if (KCNEManager.Instance.Start(_versionBox.SelectedIndex))
            {
                _startButton.Enabled = false;
                _stopButton.Enabled = true;
            }
        }

        private void InvokeStop()
        {
            if (KCNEManager.Instance.Stop())
            {
                _stopButton.Enabled = false;
                _startButton.Enabled = true;
            }
        }

        private void OnStartClick(object sender, EventArgs e)
        {
            InvokeStart();
        }

        private void OnStopClick(object sender, EventArgs e)
        {
            InvokeStop();
        }
    }
}
