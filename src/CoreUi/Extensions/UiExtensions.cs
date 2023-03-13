using CoreUi.Models;
using PubSubDomain.Domain;
using PubSubDomain.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreUi.Extensions
{
	public class UiExtensions
	{
		public static System.Drawing.Color GetRandomColorForSubscriberForm()
		{
			Random random = new Random();
			var colors = UiConstantValues.SubscriberFormColors;
			var index = random.Next(0, colors.Length - 1);

			return colors[index];
		}

		public static bool PopupErrors(List<ErrorType> errors)
		{
			var errorMessage = string.Empty;
			errors = errors ?? new List<ErrorType>();

			foreach (var item in errors)
			{
				switch (item)
				{
					case ErrorType.EmptyPublisher:
						{
							errorMessage += FieldText.ErrorEmptyPublisher;
							break;
						}

					case ErrorType.EmptySubscriber:
						{
							errorMessage += FieldText.ErrorEmptySubsriber;
							break;
						}

					case ErrorType.EmptyMessage:
						{
							errorMessage += FieldText.ErrorEmptyMessage;
							break;
						}
				}

				errorMessage += Environment.NewLine;
			}

			MessageBox.Show(errorMessage, FieldText.Errors);
			return true;
		}

		public static void WriteItemsSafe(ComboBox sender, string text, bool isAdding)
		{
			if (sender.InvokeRequired)
			{
				Action safeWrite = delegate { WriteItemsSafe(sender, text, isAdding); };
				sender.Invoke(safeWrite);
			}
			else if (isAdding)
			{
				sender.Items.Add(text);
			}
			else
			{
				sender.Items.Remove(text);
			}
		}

		public static bool WriteTextSafe(Control sender, string text)
		{
			if (sender.InvokeRequired)
			{
				Action safeWrite = delegate { WriteTextSafe(sender, text); };
				sender.Invoke(safeWrite);
			}
			else
			{
				sender.Text = text;
			}

			return true;
		}
	}
}
