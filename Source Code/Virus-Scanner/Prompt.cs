using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virus_Scanner
{
    class Prompt
    {
        public static string[] ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 175,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
                
                

            };
            Label textLabel = new Label() { Left = 50, Top = 20, Width=250, Text = text };
            Label textLabel2 = new Label() { Left = 10, Top = 50, Width = 70, Text = "Username" };
            Label textLabel3 = new Label() { Left = 10, Top = 75, Width = 70, Text = "Password" };
            TextBox textBox = new TextBox() { Left = 90, Top = 50, Width = 250 };
            TextBox textBox2 = new TextBox() { Left = 90, Top = 75, Width = 250 };
            Button confirmation = new Button() { Text = "Ok", Left = 240, Width = 100, Top = 100, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(textBox2);
            prompt.Controls.Add(textLabel2);
            prompt.Controls.Add(textLabel3);        
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            string[] retStr = new string[2];
            

            return prompt.ShowDialog() == DialogResult.OK ? new string[] {textBox.Text,textBox2.Text } : null;
        }



    }
}
