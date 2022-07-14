using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolerSoft.Maui;

static public class NavigationExtensions
{
    /// <summary>
    /// Converts a <see cref="FormattableString"/> to a named value set of parameters.
    /// </summary>
    /// <param name="param">
    /// The <see cref="FormattableString"/> to convert.
    /// </param>
    /// <returns>
    /// The converted parameters.
    /// </returns>
    static private Dictionary<string, object> ToParameters(this FormattableString param)
    {
        // Placeholder for results
        Dictionary<string, object> parameters = new();

        // Split first on comas to get named values
        string[] tuples = param.Format.Split(',');

        // Process and add each comma
        foreach (string tuple in tuples)
        {
            // Get name and value
            string[] namedValue = tuple.Split('=');

            // Get name
            string name = namedValue[0].Trim();

            // Get value index
            int index = int.Parse(namedValue[1].Trim(' ', '{', '}'));

            // Add
            parameters[name] = param.GetArgument(index);
        }

        // Done!
        return parameters;
    }

    /// <summary>
    /// Automatically creates a navigation state dictionary and completes navigation.
    /// </summary>
    /// <param name="shell">
    /// The <see cref="Shell"/> where navigation will occur.
    /// </param>
    /// <param name="state">
    /// The <see cref="ShellNavigationState"/> that indicates where to navigate.
    /// </param>
    /// <param name="param">
    /// A <see cref="FormattableString"/> that will be converted to a state dictionary.
    /// </param>
    /// <returns>
    /// The navigation <see cref="Task"/>.
    /// </returns>
    static public Task GoToAsync(this Shell shell, ShellNavigationState state, FormattableString param)
    {
        // Convert and navigate with parameters
        return shell.GoToAsync(state, param.ToParameters());
    }
}
