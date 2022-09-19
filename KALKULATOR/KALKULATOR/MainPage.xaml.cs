using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KALKULATOR
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Checker(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string valueStr = button.Text;

                if (valueStr == "АЧИСТЕТЬ ВИЛКАЙ")
                {
                    if (value.Text == "") valueHistory.Text = "";
                    value.Text = "";
                }
                else if (valueStr == "=")
                {
                    string imba = new DataTable().Compute(value.Text, null).ToString();
                    valueHistory.Text = value.Text;
                    value.Text = imba.Replace(',', '.');
                }
                else
                {
                    if (Char.IsDigit(Convert.ToChar(valueStr)) || valueStr == ".")
                        value.Text += valueStr;
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(value.Text))
                        {
                            var meDie = value.Text.Split(' ');

                            if (valueStr == "%")
                            {
                                string stroka = "";
                                string meLife = (Convert.ToDouble(meDie.Last()) / 100).ToString();
                                meLife = meLife.Replace(',', '.');
                                for (int i = 0; i < meDie.Length - 1; i++)
                                {
                                    if (meDie[i] == "+" || meDie[i] == "-" || meDie[i] == "*" || meDie[i] == "/")
                                        stroka += $" {meDie[i]} ";
                                    else
                                        stroka += meDie[i];
                                }
                                stroka += meLife;
                                value.Text = stroka;
                            }
                            else if (meDie.FirstOrDefault(me => me == "+" || me == "-" || me == "*" || me == "/") == null)
                                value.Text += $" {valueStr} ";
                        }
                    }
                }
            }
            catch { DisplayAlert("Ты рукожоп", "определенно", "блинб((9("); }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Ты петуч", "А может и куропатка..?", "блинб");
        }
    }
}
