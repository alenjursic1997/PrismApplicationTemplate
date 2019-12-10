using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismApplicationTemplate.Commands
{
	public class ApplicationCommands : IApplicationCommands
	{
		private CompositeCommand _saveCommand = new CompositeCommand();
		public CompositeCommand SaveCommand
		{
			get { return _saveCommand; }
		}
	}
}
