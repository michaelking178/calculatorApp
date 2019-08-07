using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormPracticeApp1
{
    /// <summary>
    /// A basic calculator
    /// </summary>
    public partial class SimpleCalculatorForm : Form
    {
        private Calculator.Equation equation;
        private string lastButtonPressed;

        #region Constructor
        public SimpleCalculatorForm()
        {
            InitializeComponent();
            equation = new Calculator.Equation();
            ClearInput();
        }
        #endregion

        private void StoreLastButton(object sender, EventArgs e)
        {
            string _sender = sender.ToString();
            string lastButton = _sender.Remove(0, _sender.Length - 1);
            lastButtonPressed = lastButton;
        }

        #region Operator Methods
        private void DivideButton_Click(object sender, EventArgs e)
        {
            SaveNumberAndOperator(Calculator.Operator.DIVIDE);
            ClearInput();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            SaveNumberAndOperator(Calculator.Operator.MULTIPLY);
            ClearInput();
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            SaveNumberAndOperator(Calculator.Operator.SUBTRACT);
            ClearInput();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SaveNumberAndOperator(Calculator.Operator.ADD);
            ClearInput();
        }

        private void SignButton_Click(object sender, EventArgs e)
        {
            float val = Convert.ToSingle(UserInputText.Text);
            val *= -1;
            UserInputText.Text = val.ToString();
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            if (lastButtonPressed != "=")
            {
                equation.Num2 = Convert.ToSingle(UserInputText.Text);
            } else
            {
                equation.Num1 = equation.Solution;
            }
            
            equation.Solution = equation.Calculate();
            ClearInput();
            UserInputText.Text = equation.Solution.ToString();
        }
        #endregion

        #region Number Methods
        private void DecimalButton_Click(object sender, EventArgs e)
        {
            // Return if decimal is already present
            if (UserInputText.Text.Contains("."))
                return;

            // Prefix a zero if the string is empty
            if (UserInputText.Text == string.Empty)
            {
                UpdateUserInputText("0.");
            }
            else
            {
                UpdateUserInputText(".");
            }
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("0");
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("1");
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("2");
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("3");
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("4");
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("5");
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("6");
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("7");
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("8");
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputText("9");
        }
        #endregion

        #region Erasure Methods
        /// <summary>
        /// Clears the user input text
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event arguments</param>
        private void CEButton_Click(object sender, EventArgs e)
        {
            ClearInput();
            equation.Clear();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (UserInputText.Text.Length > 1)
            {
                UserInputText.Text = UserInputText.Text.Remove(UserInputText.Text.Length - 1);
            }
            else
            {
                UserInputText.Text = "0";
            }
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Saves the first number of an equation and the provided operator
        /// </summary>
        /// <param name="op">The equation's operator</param>
        private void SaveNumberAndOperator(Calculator.Operator op)
        {
            equation.Num1 = Convert.ToSingle(UserInputText.Text);
            equation.Operator_ = op;
        }

        /// <summary>
        /// Focuses on the end of the user input text box
        /// </summary>
        private void FocusInputText()
        {
            UserInputText.Focus();
            UserInputText.SelectionStart = UserInputText.Text.Length;
        }

        /// <summary>
        /// Updates the user input text with a new value
        /// </summary>
        /// <param name="newValue">The new value to be inserted into the user input text</param>
        private void UpdateUserInputText(string newValue)
        {
            // Clear the starting zero before adding digits
            if (UserInputText.Text == "0")
            {
                UserInputText.Text = string.Empty;
            }

            UserInputText.Text = UserInputText.Text.Insert(UserInputText.SelectionStart, newValue);
            FocusInputText();
        }

        /// <summary>
        /// Clears the input field by resetting Text to 0 and setting Focus position
        /// </summary>
        private void ClearInput()
        {
            UserInputText.Text = "0";
            FocusInputText();
        }
        #endregion
    }
}
