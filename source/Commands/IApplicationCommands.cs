using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismApplicationTemplate.Commands
{
	public interface IApplicationCommands
	{
		CompositeCommand SaveCommand { get; }
	}
}
