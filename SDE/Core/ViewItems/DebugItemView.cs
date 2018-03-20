using ErrorManager;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;
using TokeiLibrary;

namespace SDE.Core.ViewItems
{
    /// <summary>
    /// Item to be showed in the error console
    /// </summary>
    public class DebugItemView {
		private static readonly Regex _debugItemRegex = new Regex(@"(([^,\r\n ]+): ([^,\r\n]+))", RegexOptions.Compiled);
		public Exception FullException;

		public DebugItemView(Exception err, int errorNumber, string exception, ErrorLevel errorLevel) {
			if (exception == null) throw new ArgumentNullException("exception");
			if (errorNumber < 0) throw new ArgumentOutOfRangeException("errorNumber");

			OriginalException = exception;
			FullException = err;
			ErrorNumber = errorNumber;
			Exception = exception;

			foreach (Match match in _debugItemRegex.Matches(exception)) {
				if (match.Groups.Count > 3) {
					string matchGroup = match.Groups[2].Value;
					string matchValue = match.Groups[3].Value;

					if (matchGroup == "file") {
						FilePath = matchValue.Trim('\'');
						FileName = Path.GetFileName(FilePath);
					}
					else if (matchGroup == "line") {
						Line = matchValue;
					}
					else if (matchGroup == "ID") {
						Id = matchValue;
					}
					else if (matchGroup == "exception") {
						Exception = matchValue.Trim('\'');
						break;
					}

					Exception = Exception.Replace(matchGroup + ": " + matchValue + ", ", "");
					Exception = Exception.Replace(matchGroup + ": " + matchValue, "");
				}
			}

			switch(errorLevel) {
				case ErrorLevel.Critical:
					DataImage = ApplicationManager.PreloadResourceImage("error16.png");
					break;
				case ErrorLevel.Low:
					DataImage = ApplicationManager.PreloadResourceImage("validity.png");
					break;
				case ErrorLevel.NotSpecified:
					DataImage = ApplicationManager.PreloadResourceImage("help.png");
					break;
				case ErrorLevel.Warning:
					DataImage = ApplicationManager.PreloadResourceImage("warning16.png");
					break;
			}
		}

		public int ErrorNumber { get; set; }
		public string Line { get; set; }
		public string Exception { get; set; }
		public string OriginalException { get; set; }
		public string FileName { get; set; }
		public string FilePath { get; set; }
		public string Id { get; set; }
		public BitmapSource DataImage { get; set; }

		public bool Default {
			get { return true; }
		}


		public bool CanSelectInTextEditor() {
			return File.Exists(FilePath) && Line != null;
		}

		public override string ToString() {
			return OriginalException;
		}

		public void Copy() {
			if (FullException == null) {
				MessageBox.Show("No exception has been loaded.");
				return;
			}

			Clipboard.SetDataObject(OriginalException + "\r\n\r\n" + ErrorHandler.GenerateOutput(FullException));
			MessageBox.Show("The exception has been copied to the clipboard.");
		}
	}
}