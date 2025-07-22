namespace SqlToElasticSearchConverter.Helpers;

[CommandLineArguments(CaseSensitive = false)]
public class AppArguments
{
    [Argument(ArgumentType.AtMostOnce, HelpText = "Port", DefaultValue = -1, LongName = "Port", ShortName = "p")]
    public int Port;
}

