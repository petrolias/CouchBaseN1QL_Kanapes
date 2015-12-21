using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CouchBaseN1QLKanapes
{
    class Logger
    {
        public TextBox mTxtResult;
        public TextBox mTxtOutput;
        public Logger(TextBox _txtResult, TextBox _txtOutput) {
            this.mTxtResult = _txtResult;
            this.mTxtOutput = _txtOutput;
        }

        public void logResults(string _value, bool _appentText = true)
        {
            if (!_appentText)
            {
                this.mTxtResult.Text = "";
            }
            this.mTxtResult.AppendText(_value + Environment.NewLine);
        }

        public void logOutput(string _value, bool _appentText = true)
        {
            if (!_appentText)
            {
                this.mTxtOutput.Text = "";
            }
            this.mTxtOutput.AppendText(DateTime.Now.ToString() + " -> " + _value + Environment.NewLine);
        }
    }
}
