using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private double width;
        private double height;
        private double woodLength;
        private double glassArea;
        private string tintColor;
        private int quantityOfItems;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tintColorComboBox == null) return;

            var combo = (ComboBox)sender;
            var item = (ComboBoxItem)combo.SelectedItem;
            tintColorComboBox.PlaceholderText = item.Content.ToString();
        }



        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            width = double.Parse(widthTxt.Text.ToString());
            height = double.Parse(heightTxt.Text.ToString());
            tintColor = ((ComboBoxItem)tintColorComboBox.SelectedItem).Content.ToString();
            quantityOfItems = int.Parse(sliderResult.Text.ToString());

            woodLength = quantityOfItems * (2 * (width + height) * 3.25);
            glassArea = quantityOfItems * (2 * (width * height));

            DateTime localDate = DateTime.Now;
            DateOfQuote.Text = localDate.ToString("dd MMM yyyy");
            widthResult.Text = width.ToString();
            heightResult.Text = height.ToString();
            tintResult.Text = tintColor;
            quantityResult.Text = quantityOfItems.ToString();
            totalWoodLength.Text = woodLength.ToString() + " feet";
            totalGlassArea.Text = glassArea.ToString() + " square meters";
        }

        private void widthTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(widthTxt.Text.ToString(), out double i))
            {
                errorMessage.Text = "Please enter a number";
            }
            else
            {
                width = double.Parse(widthTxt.Text.ToString());
                if (width > 0.5 && width < 5)
                {
                    errorMessage.Text = String.Empty;

                }
                else
                {
                    errorMessage.Text = "Please enter a number between 0.5 and 5";  
                }
            }
        }

        private void heightTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(heightTxt.Text.ToString(), out double i))
            {
                errorMessage2.Text = "Please enter a number";
            }
            else
            {
                width = double.Parse(heightTxt.Text.ToString());
                if (width > 0.75 && width < 3)
                {
                    errorMessage2.Text = String.Empty;

                }
                else
                {
                    errorMessage2.Text = "Please enter a number between 0.75 and 3";
                }
            }
        }
    }
}
