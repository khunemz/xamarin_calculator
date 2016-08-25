using System;

using UIKit;

namespace xamarin_intro
{

	public enum Operator { 
		Addition,
		Subtraction,
		Multiplication,
		Division
	}

	public class Calculator {
		public string Cal(string operand1, string operand2, Operator _operator)
		{
			double _value1;
			double _value2;

			double.TryParse(operand1, out _value1);
			double.TryParse(operand2, out _value2);

			double _result = 0;
			switch (_operator)
			{
				case Operator.Addition:
					_result = _value1 + _value2;
					break;
				case Operator.Subtraction:
					_result = _value1 - _value2;
					break;
				case Operator.Multiplication:
					_result = _value1 * _value2;
					break;
				case Operator.Division:
					_result = _value1 / _value2;
					break;
			}
			return _result.ToString();
			
		}
			
	}

	public partial class ViewController : UIViewController
	{

		private string _operand1 = string.Empty;
		private string _operand2 = string.Empty;
		private Operator _operator;
		private Calculator _calculator;


		protected ViewController(IntPtr handle) : base(handle)
		{
			_calculator = new Calculator();
		}

		public override void ViewDidLoad()
		{
			
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			txtDisplay.Text = string.Empty;

			btnZero.TouchUpInside += NumericButtonClick;
			btnOne.TouchUpInside += NumericButtonClick;
			btnTwo.TouchUpInside += NumericButtonClick;
			btnThree.TouchUpInside += NumericButtonClick;
			btnFour.TouchUpInside += NumericButtonClick;
			btnFive.TouchUpInside += NumericButtonClick;
			btnSix.TouchUpInside += NumericButtonClick;
			btnSeven.TouchUpInside += NumericButtonClick;
			btnEight.TouchUpInside += NumericButtonClick;
			btnNine.TouchUpInside += NumericButtonClick;

			btnAdd.TouchUpInside += OperatorButtonClick;
			btnSubtract.TouchUpInside += OperatorButtonClick;
			btnMultiply.TouchUpInside += OperatorButtonClick;
			btnDivide.TouchUpInside += OperatorButtonClick;
			btnEqual.TouchUpInside += EqualsButtonClick;
		}

		void EqualsButtonClick(object sender, EventArgs e)
		{
			_operand2 = txtDisplay.Text;


			txtDisplay.Text = _calculator.Cal(_operand1, _operand2, _operator);
		}

		void OperatorButtonClick(object sender, EventArgs e)
		{
			_operand1 = txtDisplay.Text;

			var button = (UIButton)sender;
			switch (button.CurrentTitle)
			{
				case "+" :
					_operator = Operator.Addition;
					break;
				case "-" :
					_operator = Operator.Subtraction;
					break;
				case "X" :
					_operator = Operator.Multiplication;
					break;
				case "/" :
					_operator = Operator.Division;
					break;
			}
			txtDisplay.Text = string.Empty;
		}


		void NumericButtonClick(object sender, EventArgs e)
		{
			var button = (UIButton)sender;
			txtDisplay.Text += button.CurrentTitle;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

