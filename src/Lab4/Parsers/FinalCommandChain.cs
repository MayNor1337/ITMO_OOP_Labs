using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class FinalCommandChain : ChainCommandBase
{
    private string _referenceCommand;
    private IBuilder _referenceBuilder;

    public FinalCommandChain(string referenceCommand, IBuilder referenceBuilder)
    {
        _referenceCommand = referenceCommand;
        _referenceBuilder = referenceBuilder;
    }

    protected IArgumentParser? ArgumentParser { get; private set; }

    public FinalCommandChain AddNextArgumentParser(IArgumentParser command)
    {
        if (ArgumentParser is null)
        {
            ArgumentParser = command;
        }
        else
        {
            ArgumentParser.AddNext(command);
        }

        return this;
    }

    public override ResultParsingCommand Handle(StringIterator command)
    {
        if (command.GetCurrentString() == _referenceCommand)
        {
            IEnumerable<string> data = Array.Empty<string>();

            if (ArgumentParser is not null)
                data = ArgumentParser.Handle(command.Next());

            BuildResult result = _referenceBuilder.TakeArgumentList(data).Build();

            if (result is BuildResult.Successfully resultWithCommand)
                return new ResultParsingCommand.CommandReceived(resultWithCommand.Command);
        }

        if (command.GetCurrentString() != _referenceCommand && Next is not null)
            return Next.Handle(command);

        return new ResultParsingCommand.UnknownCommand();
    }
}